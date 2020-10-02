using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace BandApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            //this is used for regenerate the db to the initial 
            //using (var scope = host.Services.CreateScope())
            //{
            //    try
            //    {
            //        var context = scope.ServiceProvider.GetService<BandAlbumContext>();
            //        context.Database.EnsureDeleted();
            //        context.Database.Migrate();
            //    }
            //    catch (Exception ex)
            //    {
            //        var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
            //        logger.LogError(ex, "An error occured while migration was in progress");
            //    }
            //}
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
