namespace Natillera.Aplication.Installer
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Natillera.Aplication.Services;
    using Natillera.AplicationContract.IServices;
    using Natillera.AplicationContract.Models.RedisCache;

    public class CacheInstaller
    {


        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            //Leer la configuracion que contiene el archivo de configuracion de json y mapear los datos en la clase.
            var redisCacheSetting = new RedisCacheSettings();
            configuration.GetSection(nameof(RedisCacheSettings)).Bind(redisCacheSetting);
            services.AddSingleton(redisCacheSetting);

            if (!redisCacheSetting.Enabled)
            {
                return;
            }

            services.AddStackExchangeRedisCache(options => options.Configuration = redisCacheSetting.ConexionString);
            services.AddSingleton<IResponseCacheService, ResponseCacheService>();

        }
    }
}
