using MemoryCache.Interfaces.Model;

namespace MemoryCache.Interfaces.Services
{
    public interface ICacheService
    {
        ICache CreateCache(string key, string content);
        ICache GetCache(string key);
        void RemoveOldCache();
    }
}
