namespace NatilleraWebApi.Filter.Cache
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.Extensions.DependencyInjection;
    using Natillera.AplicationContract.IServices;
    using Natillera.AplicationContract.Models.RedisCache;
    using System;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CachedAttribute : Attribute, IAsyncActionFilter
    {
        private readonly int timeToLiveSeconds;


        public CachedAttribute(int timeToLiveSeconds)
        {
            this.timeToLiveSeconds = timeToLiveSeconds;

        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {

            var cacheSettings = context.HttpContext.RequestServices.GetRequiredService<RedisCacheSettings>();

            if (!cacheSettings.Enabled)
            {
                await next();
                return;
            }

            //DUM: se realiza una inyeción manual y no por constructor.
            var cacheService = context.HttpContext.RequestServices.GetRequiredService<IResponseCacheService>();
            //DUM: se obtiene la url para generar la key de cache donde se guardar la información del servicio actual.
            var cacheKey = GenerateCacheKeyFromRequest(context.HttpContext.Request);
            var cachedResponse = await cacheService.GetCacheResponseAsync(cacheKey);

            //DUM: si no hay guardado nada en cache el sistema lo crea sino lo obtiene y lo devuelve.
            if (!string.IsNullOrEmpty(cachedResponse))
            {
                context.Result = new ContentResult
                {
                    Content = cachedResponse,
                    ContentType = "application/json",
                    StatusCode = StatusCodes.Status200OK
                };

                return;
            }

            var executedContext = await next();
            if (executedContext.Result is OkObjectResult okObjectResult)
            {
                await cacheService.CacheResponseAsync(cacheKey, okObjectResult.Value, TimeSpan.FromSeconds(this.timeToLiveSeconds));
            }
        }

        private string GenerateCacheKeyFromRequest(HttpRequest request)
        {
            var keyBulder = new StringBuilder();

            keyBulder.Append($"{request.Path}");

            foreach (var (key, value) in request.Query.OrderBy(x => x.Key))
            {
                keyBulder.Append($"{key}--{value}");
            }
            //var result = request.Query.OrderBy(x => x.Key).Select(s => keyBulder.Append($"{s.Key}--{s.Value}"));

            return keyBulder.ToString();
        }
    }
}
