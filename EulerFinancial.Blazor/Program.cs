using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
//using Microsoft.Extensions.Logging;
using Serilog;
using System;

namespace EulerFinancial.Blazor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Log.Information("START-UP SUCCESSFUL");
                CreateHostBuilder(args).Build().Run();
            }
            catch(Exception e)
            {
                Log.Fatal(e, ResourceString.Exception.Application_StartupFailed);
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
