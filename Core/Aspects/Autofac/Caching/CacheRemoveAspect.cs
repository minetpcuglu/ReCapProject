using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Aspects.Autofac.Caching
{
    //ne zaman calısırr ? data bozuldugu zaman ne zaman nozulur ? CRUD işlemlerinde bozulur 
    public class CacheRemoveAspect : MethodInterception
    {
        private string _pattern;
        private ICacheManager _cacheManager;

        public CacheRemoveAspect(string pattern)
        {
            _pattern = pattern;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        protected override void OnSuccess(IInvocation invocation)  //metot basarılı olursa kullanılır ornegin eklenen bir sey varsa calısır 
        {
            _cacheManager.RemoveByPattern(_pattern);
        }
    }
}
