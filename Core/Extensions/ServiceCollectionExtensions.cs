using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Extensions
{
   public static class ServiceCollectionExtensions
    {
        //butun katmanlarda eklencek butun bagımlıkları bır arada topladık
        public static IServiceCollection AddDependencyResolvers  
            (this IServiceCollection serviceCollection,ICoreModule[] modules)   //Apimizdeki servis bagımlılıklarını eklediğimiz ya da araya girmesini istediğimiz servisdir
        {
            foreach (var module in modules)
            {
                module.Load(serviceCollection);
            }
            return ServiceTool.Create(serviceCollection);
        }
            
   }
}
