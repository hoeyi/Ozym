using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Formatting.Compact;
using System;
using Microsoft.Extensions.Configuration;
using Ichosoft.Extensions.Configuration;
using Serilog.Extensions.Logging;
using System.Globalization;

namespace EulerFinancial.Blazor
{
    public class Program
    {
        private static IConfigurationRoot config;
        internal static IConfigurationRoot Configuration
        {
            get{ return config; }
        }

        public static int Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .MinimumLevel.Information()
                .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Information)
                .WriteTo.File(
                    path: $"{EulerFinancial.Configuration.AssemblyInfo.ExecutingAssemblyPath}\\logs\\.log",
                    rollingInterval: RollingInterval.Day,
                    shared: true)
                .WriteTo.File(
                    formatter: new RenderedCompactJsonFormatter(),
                    path: $"{EulerFinancial.Configuration.AssemblyInfo.ExecutingAssemblyPath}\\logs\\.json",
                    rollingInterval: RollingInterval.Day,
                    shared: true)
                .CreateLogger();

            try
            {
                Log.Information("Start-up initialized.");

                config = CreateProtectedConfiguration(logger: 
                    new SerilogLoggerFactory(Log.Logger).CreateLogger(nameof(Program)));

                // Copy UserSecret connection string value to secure configuration.
                config["ConnectionStrings:EulerFinancial"] = config["ConnectionStrings:EulerFinancial"];
                config.Commit();

                CultureInfo.CurrentCulture = new CultureInfo("de-DE");
                CultureInfo.CurrentUICulture = CultureInfo.CurrentCulture;
                CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.CurrentCulture;

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
                    //webBuilder.UseConfiguration(config);
                    webBuilder.UseStartup<Startup>();
                })
                .UseSerilog(logger: Log.Logger);

        private static IConfiguration CreateConfiguration() =>
            new ConfigurationBuilder()
                .AddJsonWritable(
                    path: "appsettings.json",
                    optional: false,
                    reloadOnChange: true)
                .AddUserSecrets<Program>()
                .Build();
        
        private static IConfigurationRoot CreateProtectedConfiguration(
            Microsoft.Extensions.Logging.ILogger logger)
        {
            var config = new ConfigurationBuilder()
                .AddSecureJsonWritable(
                    path: "appsettings.protected.json",
                    logger: logger,
                    optional: false,
                    reloadOnChange: true)
                .AddUserSecrets<Program>()
                .Build();
             
            string rsaKeyAddress = "_file:RsaKeyContainer";
            if (config[rsaKeyAddress] is null)
            {
                config[rsaKeyAddress] = $"E1EB57FA-8D2C-41CF-912A-DDBC39534A39";
                config.Commit();
            }
            return config;
        }
    }
}
