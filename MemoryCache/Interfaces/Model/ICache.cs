using System;
using System.Collections.Generic;

namespace MemoryCache.Interfaces.Model
{
    public interface ICache
    {
        string Content { get; }
        DateTime ExpiryTime { get; }
    }
}
