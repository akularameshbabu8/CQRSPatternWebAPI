using Microsoft.AspNetCore;

namespace CQRSPatternWebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                //.UseSerilog()
                .UseStartup<Startup>();
    }
}
