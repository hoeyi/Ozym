using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Formatting.Compact;
using System;

namespace EulerFinancial.Blazor
{
    public class Program
    {
        public static int Main(string[] args)
        {
            try
            {
                Log.Logger = new LoggerConfiguration()
                    .Enrich.FromLogContext()
                    .MinimumLevel.Information()
                    .WriteTo.File(
                        path: $"{Configuration.AssemblyInfoHelper.ExecutingAssemblyPath}\\logs\\.log",
                        rollingInterval: RollingInterval.Day,
                        shared: true)
                    .WriteTo.File(
                        formatter: new RenderedCompactJsonFormatter(),
                        path: $"{Configuration.AssemblyInfoHelper.ExecutingAssemblyPath}\\logs\\.json",
                        rollingInterval: RollingInterval.Day,
                        shared: true)
                    .CreateLogger();

                Log.Information("Start-up initialized.");
                CreateHostBuilder(args).Build().Run();
                return 0;
            }
            catch(Exception e)
            {
                Log.Fatal(e, ResourceString.Exception.Application_UnhandledException);
                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                //.ConfigureLogging(l => l.AddSerilog(Log.Logger))
                //.UseSerilog(logger: Log.Logger)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
