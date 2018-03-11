using System;

namespace MemoryCache
{
    public class CachedItem
    {
        public string Key { set; get; }
        public string Content { get; }
        public DateTime ExpiryTime { get; }

        public CachedItem(string key, string content)
        {
            Key = key;
            Content = content;
            ExpiryTime = DateTime.Now.AddMinutes(1);
        }
    }
}
