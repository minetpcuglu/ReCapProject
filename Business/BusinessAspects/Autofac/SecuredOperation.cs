using Business.Constants;
using Castle.DynamicProxy;
using Core.Extensions;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.BusinessAspects.Autofac
{
    //SecuredOperation JWT için
    public class SecuredOperation : MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor; //? jwt istegi yapıldında her istek için httpcontext olusturur

        public SecuredOperation(string roles)  //rolleri , ile ayırarak (atribut oldugu için bu şekilde) ver 
        {
            _roles = roles.Split(',');        //metni belirlediğim , karakterine göre array atar
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();   //windows formda apileri autofac kullanmak için service tool(injection alt yapıyı okumaya yarayan araç) yazılır 
            //servicetool core/utilities/IoC
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))
                {
                    return;
                }
            }
            throw new Exception(Messages.AuthorizationDenied);
        }
    }
}
