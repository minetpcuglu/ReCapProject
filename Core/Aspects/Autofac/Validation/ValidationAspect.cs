using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType) //Atributlere tip leri type ile atarnır 
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType)) //Managerdaki kodlar burada yazılır 
            {
                throw new System.Exception("Bu bir dogrulama sınıfı değildir");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)                   //ınvocation metot demek 
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);  //reflector calısma anında bir seyi calısmayı saglar 
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];     //ardından tipinin calısma veri tipini bul  (brand vs vs )
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);  //ve tipine esit olan parametlerini bul  
            foreach (var entity in entities)                                       //gez ve validation tool kullanarak validate yap 
            {
                ValidationTool.Validate(validator, entity);                        //managerda yazdıgımızı merkezi noktaya aldık 
            }
        }
    }
}
