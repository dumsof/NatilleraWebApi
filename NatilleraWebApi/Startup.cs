namespace NatilleraWebApi
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;
    using System.Text;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.IdentityModel.Logging;
    using Microsoft.IdentityModel.Tokens;
    using Microsoft.OpenApi.Models;
    using Natillera.Aplication.IoC;
    using Natillera.DataAccess;
    using NatilleraWebApi.Extensions;
    using NLog;
    using Microsoft.AspNetCore.Cors;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            //se utiliza nlog para crear un archivo de log, Install-Package NLog -Version 4.6.7.
            //linea que permite optener la configuracion para nlog, por ejemplo ruta archivo nombre archivo.
            LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
            Configuration = configuration;
        }

        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.WithOrigins("http://localhost:4200",
                                        "http://www.contoso.com");
                });
            });



            //Dum: se agrega la inyeccion para el logger
            //services.AddSingleton<ILoggerManager, LoggerManager>();
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
                    ValidIssuers = new List<string> { "yourdomain.com" },
                    ValidAudience = "yourdomain.com",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["va_clave_super_secreta"])),
                    ClockSkew = TimeSpan.Zero
                });
            //fin json web token

            //se instala el swagger: Install-Package Swashbuckle.AspNetCore -Version 5.0.0-rc2
            // Register the Swagger generator, defining 1 or more Swagger documents
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(configuracion =>
            {
                configuracion.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "ToDo API",
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

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                configuracion.IncludeXmlComments(xmlPath);

                //configurar ventana para pedir token en openapi
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
            app.UseStaticFiles();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            if (env.IsDevelopment())
            {
                //mostrar error mas detallado en el api.
                IdentityModelEventSource.ShowPII = true;
                app.UseDeveloperExceptionPage();
            }
            //Dum : se agrega permiso de cors para la peticion de una url especifica.
            app.UseCors(MyAllowSpecificOrigins);

            //Dum: se realiza el llamado del middleware del manejo de exception global.
            app.ConfigureCustomExceptionMiddleware();

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
