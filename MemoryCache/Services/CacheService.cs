using MemoryCache.Interfaces.Model;
using MemoryCache.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace MemoryCache.Services
{
    public class CacheService : ICacheService
    {
        private IDictionary<string, ICache> _cachedItems { get; }

        public CacheService()
        {
            _cachedItems = new Dictionary<string, ICache>();
            //IoC
        }

        public ICache CreateCache(string key, string content)
        {
            var cacheItem = new CachedItem(content); // TODO FIX factory?
            _cachedItems.Add(key, cacheItem);
            return cacheItem;
        }


        public ICache GetCache(string key)
        {
            if (_cachedItems.ContainsKey(key))
            {
                return _cachedItems[key];
            }
            return null;
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
