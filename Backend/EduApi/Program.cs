using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
namespace EduApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                          .ConfigureLogging(builder => builder.AddFile(
                              options =>
                              {
                                  options.FileName = "log-"; // The log file prefixes
                                  options.LogDirectory = "Log"; // The directory to write the logs
                                  options.FileSizeLimit = 20 * 1024 * 1024; // The maximum log file size (20MB here)
                                  options.RetainedFileCountLimit = 90;
                              })).UseStartup<Startup>();
        }
    }
}
