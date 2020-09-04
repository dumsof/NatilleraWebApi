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
    using AutoMapper;
    using Natillera.BusinessContract.IBusiness;
    using Natillera.Business.Business;
    using Natillera.Business.Mapper;

    /// <summary>
    /// clase que permite inyectar el servicio de registrar log
    /// </summary>
    public static class ServiceExtensions
    {
        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            //singleton, creara un servicio cada vez que se necesite y luego cada solicitud posterior estara llamada la misma instancia.
            services.AddSingleton<ILoggerManager, LoggerManager>();

            //DUM: configuración automapper, clase que tiene las posibles conversiones de tipos de clase entre capas
            services.AddAutoMapper(c => c.AddProfile<BusinessDataAccessMapper>(), typeof(ServiceExtensions));
            services.AddAutoMapper(typeof(ServiceExtensions));
            //services.AddControllersWithViews();
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
            AddResgistroBusiness(services);
            AddResgistroRepositorio(services);
            return services;
        }

        private static IServiceCollection AddResgistroServices(this IServiceCollection services)
        {
            services.AddTransient<IAuntentificacionService, AuntentificacionService>();
            services.AddTransient<INatilleraService, NatilleraService>();
            services.AddTransient<IUsuarioService, UsuarioService>();
            services.AddTransient<ISociosService, SociosService>();
            services.AddTransient<IRolesService, RolesService>();
            services.AddTransient<ITokensService, TokensService>();
            services.AddTransient<ITipoDocumentoService, TipoDocumentoService>();
            services.AddTransient<IUploadFileService, AdministracionArchivoService>();

            return services;
        }

        private static IServiceCollection AddResgistroBusiness(this IServiceCollection services)
        {
            services.AddTransient<INatilleraBusiness, NatilleraBusiness>();
            services.AddTransient<IRolBusiness, RolBusiness>();
            services.AddTransient<ISocioBusiness, SocioBusiness>();
            services.AddTransient<IUsuarioBusiness, UsuarioBusiness>();
            services.AddTransient<ITipoDocumentoBusiness, TipoDocumentoBusiness>();
            services.AddTransient<IUploadFileBusiness, UploadFileBusiness>();

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
            services.AddTransient<ITipoDocumentoRepositorio, TipoDocumentoRepositorio>();

            return services;
        }
    }
}
