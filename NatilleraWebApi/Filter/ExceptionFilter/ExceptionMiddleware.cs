namespace NatilleraWebApi.Filter.ExceptionFilter
{
    using LoggerService;
    using Microsoft.AspNetCore.Http;
    using NatilleraWebApi.Models;
    using System;
    using System.Net;
    using System.Threading.Tasks;

    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerManager _logger;

        public ExceptionMiddleware(RequestDelegate next, ILoggerManager logger)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error Interno: {ex}");
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            return context.Response.WriteAsync(new MensajeExeption()
            {
                codigo = context.Response.StatusCode,
                Mensaje = $"Error interno en el servidor : {exception.Message} ",
                Exception = exception.ToString()

            }.ToString());
        }
    }
}
