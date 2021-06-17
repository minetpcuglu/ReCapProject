using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Core.Utilities.Interceptors
{
    //ne işe yarar ? clasın  attributlerini  oku metodun atributlerini oku (log,cache, yetkilendirme, validate ) ve onları bul ve listele calısma sırasını oncelik değerine göre sırala 
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>
                (true).ToList();
            var methodAttributes = type.GetMethod(method.Name)
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            classAttributes.AddRange(methodAttributes);

            //classAttributes.Add(new ExceptionLogAspect(typeof(FileLogger))); //otomatik  olarak sistemdeki tüm metotları ,verileri loga dönüştür

            return classAttributes.OrderBy(x => x.Priority).ToArray();
        }
    }
}
