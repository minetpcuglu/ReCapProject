using Core.Utilities.IoC;
using Microsoft.Extensions.Caching.Memory;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;

namespace Core.CrossCuttingConcerns.Caching.Microsoft
{
    //adapter pattern
    //sadece microsoft degil farklı bir cache sisteminde patlamamk için kendimize uyarlıyoruz 
    public class MemoryCacheManager : ICacheManager
    {

        IMemoryCache _memoryCache; //interface çözülmesi için ctor enjekte edip calısma olmaz neden aspect bagımlılıgın içinde değil

        public MemoryCacheManager()
        {
            _memoryCache = ServiceTool.ServiceProvider.GetService<IMemoryCache>();
        }

        public void Add(string key, object value, int duration)
        {
            _memoryCache.Set(key, value, TimeSpan.FromMinutes(duration));  //timespan ne kadar sure verirsek okadar sürede cache sistemden atılcak
        }

        public T Get<T>(string key)
        {
            return _memoryCache.Get<T>(key);
        }

        public object Get(string key)
        {
            return _memoryCache.Get(key);
        }

        public bool IsAdd(string key)  //bellkekte cache var mı 
        {
            return _memoryCache.TryGetValue(key , out _);  //control   //geriye döndürmek istemiyoruz data istemiyoruz out _
        }

        public void Remove(string key)
        {
            _memoryCache.Remove(key);
        }

        //çalışma anında müdahele (reflection) crud işlemlerini 
        public void RemoveByPattern(string pattern) //ona verilen bir pattern göre  çalışma anında bellekten silme işlemi
        {
            var cacheEntriesCollectionDefinition = typeof(MemoryCache).GetProperty("EntriesCollection", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance); //bellekte memorycache türünde olan entries collection bul
            var cacheEntriesCollection = cacheEntriesCollectionDefinition.GetValue(_memoryCache) as dynamic;
            List<ICacheEntry> cacheCollectionValues = new List<ICacheEntry>();

            foreach (var cacheItem in cacheEntriesCollection)
            {
                ICacheEntry cacheItemValue = cacheItem.GetType().GetProperty("Value").GetValue(cacheItem, null);
                cacheCollectionValues.Add(cacheItemValue);
            }

            var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase); //pattern olusturma 
            var keysToRemove = cacheCollectionValues.Where(d => regex.IsMatch(d.Key.ToString())).Select(d => d.Key).ToList();

            foreach (var key in keysToRemove)
            {
                _memoryCache.Remove(key);
            }

        }
    }
}
