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
            var cacheItem = new CachedItem<ICacheable>(content); // TODO FIX factory?
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
            if (_cachedItems.ContainsKey(id))
            {
                return _cachedItems[id].Content;
            }
            return p(id);
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
