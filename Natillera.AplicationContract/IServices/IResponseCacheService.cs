﻿namespace Natillera.AplicationContract.IServices
{
    using System;
    using System.Threading.Tasks;

    public interface IResponseCacheService
    {
        Task CacheResponseAsync(string cacheKey, object response, TimeSpan timeTimeLive);

        Task<string> GetCacheResponseAsync(string cacheKey);

        Task RemoveCacheResponseAsync(string cacheKey);
    }
}