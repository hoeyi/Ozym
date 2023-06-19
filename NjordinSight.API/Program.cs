using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ILogger = Microsoft.Extensions.Logging.ILogger;
using Serilog.Formatting.Compact;
using Serilog;
using Ichosys.Extensions.Configuration;
using Serilog.Extensions.Logging;
using NjordinSight;

namespace NjordinSight.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var databaseProvider = builder.Configuration["DATABASE_PROVIDER"];

            var logger = ConvertFromSerilogILogger(logger: BuildLogger());
            var config = BuildConfiguration(logger, databaseProvider == "SQL_SERVER");

            // Add services to DI container
            builder.Services.AddSingleton(implementationInstance: logger);
            builder.Services.AddSingleton(implementationInstance: config);

            builder.Services.AddDataAccessServices(
                databaseProvider: databaseProvider,
                developerMode: builder.Environment.IsDevelopment());

            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddApiVersioning(setupAction =>
            {
                setupAction.AssumeDefaultVersionWhenUnspecified = true;
                setupAction.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
                setupAction.ReportApiVersions = true;
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }

        /// <summary>
        /// Builds the application <see cref="IConfiguration"/> instance.
        /// </summary>
        /// <param name="logger">The <see cref="ILogger"/> to use.</param>
        /// <returns>An <see cref="IConfiguration"/>.</returns>
        private static IConfigurationRoot BuildConfiguration(
            ILogger logger, bool configureSecureJson = true)
        {
            IConfigurationRoot config;
            if (configureSecureJson)
            {
                config = new ConfigurationBuilder()
                    .AddSecureJsonWritable(
                        path: "appsettings.Development.json",
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

                config["ConnectionStrings:NjordWorks"] = config["ConnectionStrings:NjordWorks"];
                config.Commit();
            }
            else
            {
                config = new ConfigurationBuilder()
                    .AddJsonWritable(
                        path: "appsettings.Development.json",
                        optional: false,
                        reloadOnChange: true)
                    .Build();
            }

            return config;
        }

        /// <summary>
        /// Builds the application <see cref="ILogger"/> instance.
        /// </summary>
        /// <returns>A <see cref="Serilog.ILogger"/>.</returns>
        private static Serilog.ILogger BuildLogger()
        {
            // Define logger settings.
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .MinimumLevel.Information()
                .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Information)
                .WriteTo.File(
                    path: $"{NjordinSight.Configuration.AssemblyInfo.ExecutingAssemblyPath}\\logs\\.log",
                    rollingInterval: Serilog.RollingInterval.Day,
                    shared: true)
                .WriteTo.File(
                    formatter: new RenderedCompactJsonFormatter(),
                    path: $"{NjordinSight.Configuration.AssemblyInfo.ExecutingAssemblyPath}\\logs\\.json",
                    rollingInterval: RollingInterval.Day,
                    shared: true)
                .CreateLogger();

            return Log.Logger;
        }

        /// <summary>
        /// Converts a <see cref="Serilog.ILogger"/> instance to a <see cref="ILogger"/> instance.
        /// </summary>
        /// <param name="logger"></param>
        /// <returns>A <see cref="ILogger"/>.</returns>
        private static ILogger ConvertFromSerilogILogger(Serilog.ILogger logger)
        {
            return new SerilogLoggerFactory(logger).CreateLogger(nameof(Program));
        }
    }
}