using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Formatting.Compact;
using System;
using Microsoft.Extensions.Configuration;
using Hoeyi.Extensions.Configuration;
using Serilog.Extensions.Logging;

namespace EulerFinancial.Blazor
{
    public class Program
    {
        private readonly static IConfigurationRoot config = CreateConfiguration();
        private static IConfigurationRoot secureConfig;
        internal static IConfigurationRoot SecureConfig
        {
            get{ return secureConfig; }
        }

        public static int Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .MinimumLevel.Information()
                .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Information)
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
            try
            {
                Log.Information("Start-up initialized.");

                secureConfig = CreateProtectedConfiguration(
                    keyContainerName: config["SecureKeyContainer"],
                    logger: new SerilogLoggerFactory(Log.Logger).CreateLogger(nameof(Program)));

                // Copy UserSecret connection string value to secure configuration.
                secureConfig["ConnectionStrings:EulerFinancial"] = config["ConnectionStrings:EulerFinancial"];
                secureConfig.Commit();

                using IHost host = CreateHostBuilder(args).Build();
                host.Run();

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
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseConfiguration(secureConfig);
                    webBuilder.UseStartup<Startup>();
                })
                .UseSerilog(logger: Log.Logger);

        private static IConfigurationRoot CreateConfiguration() =>
            new ConfigurationBuilder()
                .AddJsonWritable(
                    path: "appsettings.json",
                    optional: false,
                    reloadOnChange: true)
                .AddUserSecrets<Program>()
                .Build();

        private static IConfigurationRoot CreateProtectedConfiguration(
            string keyContainerName, Microsoft.Extensions.Logging.ILogger logger)
        {
            return new ConfigurationBuilder()
                .AddSecureJsonWritable(
                    path: "appsettings.protected.json",
                    encryptionKeyContainer: keyContainerName,
                    logger: logger,
                    optional: false,
                    reloadOnChange: true)
                .Build();
        }
    }
}
