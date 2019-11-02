namespace NatilleraWebApi.Extensions
{
  
    using Microsoft.AspNetCore.Builder;   
    using NatilleraWebApi.Filter.ExceptionFilter;    

    public static class ExceptionMiddlewareExtensions
    {
        /// <summary>
        /// se usa para tener una llamado de metodo y capturar las exception.
        /// DUM: este metodo se utiliza para manejar la exception en un metodo incorporado 
        /// que se configura en el archivo setup.cs app.ConfigureExceptionHandler(logger);
        /// </summary>
        /// <param name="app"></param>
        /// <param name="logger"></param>
        /*
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILoggerManager logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        logger.LogError($"Something went wrong: {contextFeature.Error}");

                        await context.Response.WriteAsync(new MensajeExeption()
                        {
                            codigo = context.Response.StatusCode,
                            Mensaje = "Error Interno en el Servidor.",
                            Exception = contextFeature.Error.ToString()

                        }.ToString());
                    }
                });
            });
        }*/

        /// <summary>
        /// metodo que se extiende de IApplicationBuilder, para poder agrregar el middleware de la exception.
        /// </summary>
        /// <param name="app"></param>
        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
