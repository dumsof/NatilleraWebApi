namespace NatilleraWebApi
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Hosting;

    //DUM: como instalar la aplicacion iis : https://docs.microsoft.com/es-es/aspnet/core/host-and-deploy/aspnet-core-module?view=aspnetcore-3.1

#pragma warning disable CS1591
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>()
                      .UseUrls("https://localhost:44335");
                });
    }
#pragma warning restore CS1591
}
