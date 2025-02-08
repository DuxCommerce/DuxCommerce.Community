using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OrchardCore.Logging;

namespace DuxCommerce.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder(args)
                .ConfigureLogging(logging => logging.ClearProviders())
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseNLogWeb();
                    webBuilder.UseStartup<Startup>();
                });
    }
}
