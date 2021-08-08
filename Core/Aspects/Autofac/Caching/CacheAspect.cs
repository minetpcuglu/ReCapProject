using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspects.Autofac.Caching
{
    public class CacheAspect : MethodInterception
    {
        private int _duration;
        private ICacheManager _cacheManager;

        public CacheAspect(int duration = 60) //60 dk sonra sistem bellekten atar
        {
            _duration = duration;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>(); //hangi cache manager kullanıyorsun ? 
        }

        public override void Intercept(IInvocation invocation )
        { 
            //reflectedtype namespace al demek 
        
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");
            var arguments = invocation.Arguments.ToList(); //metodun parametleleri varsa list cevır
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})"; //?? parametre  varsa bunu yoksa bunu demek 
            if (_cacheManager.IsAdd(key)) //cache içinde varsa if metodu calisir 
            {
                invocation.ReturnValue = _cacheManager.Get(key); //metodun return degeri (ınnocation) cachedeki data olsun demek 
                return;
            }
            invocation.Proceed(); //yoksa proceed eder

            _cacheManager.Add(key, invocation.ReturnValue, _duration); //yoksa eklenır 
        }
    }
}
