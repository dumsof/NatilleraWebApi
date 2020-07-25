namespace NatilleraWebApi
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Reflection;
    using System.Text;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Localization;
    using Microsoft.AspNetCore.Localization.Routing;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.IdentityModel.Logging;
    using Microsoft.IdentityModel.Tokens;
    using Microsoft.OpenApi.Any;
    using Microsoft.OpenApi.Models;
    using Natillera.Aplication.IoC;
    using Natillera.DataAccess;
    using NatilleraWebApi.Extensions;
    using NLog;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            //se utiliza nlog para crear un archivo de log, Install-Package NLog -Version 4.6.7.
            //linea que permite optener la configuracion para nlog, por ejemplo ruta archivo nombre archivo.
            LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
            Configuration = configuration;
        }

        readonly string EnableCors = "EnableCORS";

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //DUM: Habilitar CORS esto permite que otras aplicaciones puedan consumir y realizar todos los verbos get, post de la aplicación
            services.AddCors(options =>
            {
                options.AddPolicy(EnableCors, builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().Build();
                });
            });

            //DUM:Formato de fechas y numero.
            services.Configure<RequestLocalizationOptions>(options =>
            {
                string cultura = Configuration.GetValue<string>("Formato:Cultura");
                string culturaIu = Configuration.GetValue<string>("Formato:CulturaIU");
                //DUM: para que el navegador no cambie la cultura.
                options.DefaultRequestCulture = new RequestCulture(culture: cultura, uiCulture: culturaIu);
                //DUM: de forma predeterminada se establecera la cultura en el servidor. 
                options.SupportedCultures = new List<CultureInfo> { new CultureInfo(cultura) };
                //DUM: da formato a las pagina o salida
                options.DefaultRequestCulture.Culture.DateTimeFormat.ShortDatePattern = Configuration.GetValue<string>("Formato:Fecha");
                options.DefaultRequestCulture.Culture.DateTimeFormat.DateSeparator = Configuration.GetValue<string>("Formato:DateSeparator");
            });

            //Dum: se agrega la inyeccion para el logger           
            services.ConfigureLoggerService();

            services.AddDbContext<NatilleraDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DataBaseConexion")));

            services.AddControllers();

            //Dum: manejo del token.
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<NatilleraDBContext>()
            .AddDefaultTokenProviders();

            //Dum: se inyecta el contenedor del repositorio
            //services.ConfiguracionRepositoryContenedor();

            //Dum: se injectan los servicios de las capas de repositorio y servicios.
            ServiceExtensions.AddResgistro(services);

            //json web token configuracion
            //se realiza la validacion para saber si el token enviado es correcto y 
            //poder entrar a la aplicación.
            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(opcion =>
                opcion.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuers = new List<string> { Configuration.GetValue<string>("Token:Issuer") },
                    ValidAudience = Configuration.GetValue<string>("Token:Audience"),
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["va_clave_super_secreta"])),
                    ClockSkew = TimeSpan.Zero
                });
            //fin json web token           

            //se instala el swagger: Install-Package Swashbuckle.AspNetCore -Version 5.0.0-rc2          
            services.AddSwaggerGen(configuracion =>
            {
                configuracion.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API Natillera",
                    Description = "Natillera ASP.NET Core Web API",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Shayne Boyer",
                        Email = string.Empty,
                        Url = new Uri("https://twitter.com/spboyer"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under LICX",
                        Url = new Uri("https://example.com/license"),
                    }
                });

                configuracion.MapType<DateTime>(() => new OpenApiSchema
                {
                    Type = "string",
                    Format = "date",
                    Example = new OpenApiDateTime(DateTime.Now)

                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                configuracion.IncludeXmlComments(xmlPath);

                //configurar ventana para pedir token en OpenApi
                configuracion.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                configuracion.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
                });

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //DUM: Formato de fechas y numero.
            app.UseRequestLocalization();

            app.UseStaticFiles();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                //Dum: solución error no found en IIS "../swagger/v1/swagger.json", 
                //DUM: se debe publicar sin los puntos para azure "/swagger/v1/swagger.json"                
                c.SwaggerEndpoint("../swagger/v1/swagger.json", "Mi Natillera API V1");
            });

            if (env.IsDevelopment())
            {
                //mostrar error mas detallado en el api.
                IdentityModelEventSource.ShowPII = true;
                app.UseDeveloperExceptionPage();
            }

            //Dum : se agrega permiso de cors para la peticion de una url especifica.
            app.UseCors(EnableCors);

            //Dum: se realiza el llamado del middleware del manejo de exception global.
            app.ConfigureCustomExceptionMiddleware();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            //app.UseMvc();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
