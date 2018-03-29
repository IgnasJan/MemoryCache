using System;

namespace MemoryCache
{
    public class CachedItem<T> where T : ICacheable
    {
        public T Content { get; }
        public DateTime ExpiryTime { get; }

        public CachedItem(T content)
        {
            Content = content;
            ExpiryTime = DateTime.Now.AddMinutes(1);
        }
    }
}
