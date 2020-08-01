namespace Natillera.Aplication.IoC
{
    using LoggerService;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Natillera.Aplication.Services;
    using Natillera.AplicationContract.IServices;
    using Natillera.DataAccess;
    using Natillera.DataAccess.Repositories;
    using Natillera.DataAccessContract.IRepositories; 
    using Microsoft.Extensions.Configuration;
    using Microsoft.AspNetCore.Identity;

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

        public static void ConfigureAddIdentityService(this IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<NatilleraDBContext>()
            .AddDefaultTokenProviders();
        }


        public static void ConfigureAddDbContextService(this IServiceCollection services, IConfiguration configuration)
        {
            //singleton, creara un servicio cada vez que se necesite y luego cada solicitud posterior estara llamada la misma instancia.
            services.AddDbContext<NatilleraDBContext>(options => options.UseSqlServer(configuration.GetConnectionString("DataBaseConexion")));
        }

        public static IServiceCollection AddResgistro(this IServiceCollection services)
        {
            AddResgistroServices(services);
            AddResgistroRepositorio(services);
            return services;
        }

        private static IServiceCollection AddResgistroServices(this IServiceCollection services)
        {
            services.AddTransient<IAuntentificacionService, AuntentificacionService>();
            services.AddTransient<INatilleraServices, NatilleraServices>();
            services.AddTransient<IUsuarioServices, UsuarioServices>();
            services.AddTransient<ISociosService, SociosService>();
            services.AddTransient<IRolesServices, RolesServices>();
            services.AddTransient<ITokensService, TokensService>();

            return services;
        }

        private static IServiceCollection AddResgistroRepositorio(this IServiceCollection services)
        {
            services.AddScoped<IRepositorioContenedor, RepositorioContenedor>();
            services.AddTransient<INatilleraRepositorie, NatilleraRepositorio>();
            services.AddTransient<IUsuarioRepositorie, UsuarioRepositorio>();
            services.AddTransient<ISocioRepositorie, SocioRepositorio>();
            services.AddTransient<IRolesRepositorio, RolesRepositorio>();
            services.AddTransient<ITokensRepositorio, TokensRepositorio>();

            return services;
        }
    }
}
