using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ILogger = Microsoft.Extensions.Logging.ILogger;
using Serilog.Formatting.Compact;
using Serilog;
using Ichosys.Extensions.Configuration;
using Serilog.Extensions.Logging;
using Ichosys.DataModel.Expressions;
using System.IO;
using System;
using Asp.Versioning;

namespace Ozym.Api
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
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

            builder.Services.AddSingleton<IExpressionBuilder, ExpressionBuilder>();

            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                var filePath = Path.Combine(AppContext.BaseDirectory, "Ozym.Api.docs.xml");
                c.IncludeXmlComments(filePath);
            });

            builder.Services.AddApiVersioning(setupAction =>
            {
                setupAction.AssumeDefaultVersionWhenUnspecified = true;
                setupAction.DefaultApiVersion = new ApiVersion(1, 0);
                setupAction.ReportApiVersions = true;
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                // TODO: Implement query parameters or ODATA to avoid need for 
                //       suppressing schema definition.
                app.UseSwaggerUI(options => options.DefaultModelsExpandDepth(-1));
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
        /// <param name="configureSecureJson">Whether the application should configuration an 
        /// encrypted JSON configuration provider.</param>
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

                config["ConnectionStrings:OzymWorks"] = config["ConnectionStrings:OzymWorks"];
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
                    path: $"{Ozym.Configuration.AssemblyInfo.ExecutingAssemblyPath}\\logs\\.log",
                    rollingInterval: Serilog.RollingInterval.Day,
                    shared: true)
                .WriteTo.File(
                    formatter: new RenderedCompactJsonFormatter(),
                    path: $"{Ozym.Configuration.AssemblyInfo.ExecutingAssemblyPath}\\logs\\.json",
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
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}