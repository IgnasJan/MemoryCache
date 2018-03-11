using MemoryCache.Interfaces.Model;
using System;

namespace MemoryCache
{
    public class CachedItem : ICache
    {
        public string Content { get; }
        public DateTime ExpiryTime { get; }

        public CachedItem(string content)
        {
            Content = content;
            ExpiryTime = DateTime.Now.AddMinutes(1);
        }
    }
}
