namespace Natillera.Aplication.IoC
{
    using LoggerService;
    using Microsoft.Extensions.DependencyInjection;
    using Natillera.Aplication.Services;
    using Natillera.AplicationContract.IServices;
    using Natillera.DataAccess.Repositories;
    using Natillera.DataAccessContract.IRepositories;

    /// <summary>
    /// clase que permite inyectar el servicio de registrar log
    /// </summary>
    public static class ServiceExtensions
    {
        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            //singleton, creara un servicio cada vez que se necesite y luego cada solicitud posterior estara llamada la misma instancia.
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }

        public static IServiceCollection AddResgistro(this IServiceCollection services)
        {
            AddResgistroServices(services);
            AddResgistroRepositorio(services);
            return services;
        }

        private static IServiceCollection AddResgistroServices(this IServiceCollection services)
        {
            services.AddTransient<INatilleraServices, NatilleraServices>();
            return services;
        }

        private static IServiceCollection AddResgistroRepositorio(this IServiceCollection services)
        {
            services.AddScoped<IRepositorioContenedor, RepositorioContenedor>();
            services.AddTransient<NatilleraRepositorio, NatilleraRepositorio>();
            return services;
        }
    }
}
