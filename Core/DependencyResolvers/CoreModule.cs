using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DependencyResolvers
{
    public class CoreModule : ICoreModule //servis bagımlıklarımızı çözümlediğimiz yer 
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddMemoryCache(); //cache servisini eklemek memorycache karsılıgını verdik 
            serviceCollection.AddSingleton<IHttpContextAccessor,HttpContextAccessor>();  
            serviceCollection.AddSingleton<ICacheManager,MemoryCacheManager>(); //biri senden  ıcachemanager isterse memorycachemanager ver //memorycachemanager daki ınterface bagımlılıgını burada çözdük 
        }
    }
}
