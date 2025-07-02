using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quantaventis.Trading.Shared.Abstractions.Caching;
namespace Quantaventis.Trading.Shared.Infrastructure.Caching
{
    internal class InMemoryCache<TKey, TValue> : ICache<TKey, TValue>
    {
        private readonly ConcurrentDictionary<TKey, TValue> _cache = new();

        public InMemoryCache() { 
        
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            return _cache.TryGetValue(key, out value);
        }

        public void Add(TKey key, TValue value)
        {
            _cache.TryAdd(key, value);
        }
    }
}
