﻿using Microsoft.Extensions.Caching.Distributed;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CacheService.Tests.Doubles
{
    internal class DummyDistributedCache : Dictionary<string, byte[]>, IDistributedCache
    {
        public byte[]? Get(string key)
            => TryGetValue(key, out var result) ? result : default;

        public Task<byte[]?> GetAsync(string key, CancellationToken token = default)
            => Task.FromResult(Get(key));

        public void Refresh(string key)
        {
        }

        public Task RefreshAsync(string key, CancellationToken token = default)
            => Task.CompletedTask;

        public Task RemoveAsync(string key, CancellationToken token = default)
        {
            Remove(key);
            return Task.CompletedTask;
        }

        public void Set(string key, byte[] value, DistributedCacheEntryOptions options)
            => Add(key, value);

        public Task SetAsync(string key, byte[] value, DistributedCacheEntryOptions options, CancellationToken token = default)
        {
            Set(key, value, options);
            return Task.CompletedTask;
        }

        void IDistributedCache.Remove(string key)
            => base.Remove(key);
    }
}
