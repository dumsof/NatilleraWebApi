﻿namespace Natillera.AplicationContract.Models.RedisCache
{
    public class RedisCacheSettings
    {
        public bool Enabled { get; set; }

        public string ConnectionString { get; set; }
    }
}