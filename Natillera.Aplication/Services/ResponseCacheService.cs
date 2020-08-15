namespace Natillera.Aplication.Services
{
    using Microsoft.Extensions.Caching.Distributed;
    using Natillera.AplicationContract.IServices;
    using Newtonsoft.Json;
    using System;
    using System.Threading.Tasks;

    public class ResponseCacheService : IResponseCacheService
    {
        private readonly IDistributedCache distributedCache;

        public ResponseCacheService(IDistributedCache distributedCache)
        {
            this.distributedCache = distributedCache;
        }

        public async Task CacheResponseAsync(string cacheKey, object response, TimeSpan timeTimeLive)
        {
            if (response == null)
            {
                return;
            }

            var serializeResponse = JsonConvert.SerializeObject(response);

            await this.distributedCache.SetStringAsync(cacheKey, serializeResponse, new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = timeTimeLive
            });
        }

        public async Task<string> GetCacheResponseAsync(string cacheKey)
        {
            var cachedResponse = await this.distributedCache.GetStringAsync(cacheKey);

            return string.IsNullOrEmpty(cachedResponse) ? null : cachedResponse;
        }

        public async Task RemoveCacheResponseAsync(string cacheKey)
        {
            await this.distributedCache.RemoveAsync(cacheKey);
        }
    }
}
