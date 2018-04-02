using MemoryCache.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace MemoryCache.Services
{
    public class Cache : ICache
    {
        private readonly IDictionary<string, CachedItem<ICacheable>> _cachedItems = new Dictionary<string, CachedItem<ICacheable>>();

        public ICacheable CreateCache(string key, ICacheable content)
        {
            var cacheItem = new CachedItem<ICacheable>(content);
            RemoveOldCache(key);
            _cachedItems.Add(key, cacheItem);
            return cacheItem.Content;
        }


        public ICacheable GetCache(string key, Func<ICacheable> item) // T
        {
            if (_cachedItems.ContainsKey(key))
            {
                return _cachedItems[key].Content;
            }
            
            return item.Invoke();
        }

        public ICacheable GetContent(string id, Func<string, ICacheable> p)
        {
            if (_cachedItems.ContainsKey(id) && _cachedItems[id].ExpiryTime > DateTime.Now)
            {
#if DEBUG
                Console.WriteLine("From cache"); //testing
#endif
                return _cachedItems[id].Content;
            }
            var item = p(id);
            CreateCache(id, item); //parse to Student?
            return item;
        }

        public void RemoveOldCache(string key)
        {
            _cachedItems.Remove(key);
        }

        public void RemoveOldCache()
        {
            var removeCachedKeys = new List<string>();
            foreach (var cache in _cachedItems)
            {
                if (cache.Value.ExpiryTime < DateTime.Now)
                {
                    removeCachedKeys.Add(cache.Key);
                }
            }

            foreach (var cache in removeCachedKeys)
            {
                _cachedItems.Remove(cache);
            }
        }
    }
}
