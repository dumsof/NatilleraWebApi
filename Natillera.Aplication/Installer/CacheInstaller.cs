namespace Natillera.Aplication.Installer
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Natillera.Aplication.Services;
    using Natillera.AplicationContract.IServices;
    using Natillera.AplicationContract.Models.RedisCache;

    public static class CacheInstaller
    {
        /// <summary>
        /// Metodo que permite obtener los datos de la configuración para redis cache, crea la inyección para el servicio de redis cache.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void InstallServices(this IServiceCollection services, IConfiguration configuration)
        {
            //Leer la configuracion que contiene el archivo de configuracion de json y mapear los datos en la clase.
            var redisCacheSetting = new RedisCacheSettings();
            configuration.GetSection(nameof(RedisCacheSettings)).Bind(redisCacheSetting);
            services.AddSingleton(redisCacheSetting);

            if (!redisCacheSetting.Enabled)
            {
                return;
            }
            //Dum: configura la cadena de conexión de redis cache.
            services.AddStackExchangeRedisCache(options => options.Configuration = redisCacheSetting.ConnectionString);
            services.AddSingleton<IResponseCacheService, ResponseCacheService>();

        }
    }
}
