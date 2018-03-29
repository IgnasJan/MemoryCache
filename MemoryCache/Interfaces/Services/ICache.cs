using System;

namespace MemoryCache.Interfaces.Services
{
    public interface ICache
    {
        ICacheable CreateCache(string key, ICacheable content);
        //ICacheable GetContent(string key, Func<ICacheable, string> item);
        void RemoveOldCache();
        ICacheable GetContent(string id, Func<string, ICacheable> p);
    }
}
