using Ozym;
using Ozym.Web.Areas.Identity;
using Ozym.Web.Areas.Identity.Data;
using Ozym.Web.Data;
using Ozym.Messaging;
using Ichosys.DataModel;
using Ichosys.DataModel.Expressions;
using Ichosys.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Extensions.Logging;
using Serilog.Formatting.Compact;
using ILogger = Microsoft.Extensions.Logging.ILogger;
using Ichosys.Blazor.Ionicons;
using Ozym.Web;
using Ozym.EntityModel.Context;
using System;
using Microsoft.AspNetCore.Hosting;
using Ozym.UserInterface;
using Ozym.Web.Services;
using Ozym.BusinessLogic.Functions;
using System.Reflection;
using System.Linq;
using Microsoft.AspNetCore.Connections.Features;
using System.Runtime.InteropServices;
using System.Threading;
using Microsoft.Extensions.Logging;

namespace Ozym.Web
{
    public partial class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Register services for dependency injection
            #region Configuration, Logger, Helper services
            var logger = ConvertFromSerilogILogger(logger: BuildLogger());
            AppDomain.CurrentDomain.UnhandledException += (sender, eventArgs) =>
            {
                logger?.Log(
                    logLevel: LogLevel.Critical, 
                    message: "Unhandled exception encountered.\n{Exception}", 
                    eventArgs.ExceptionObject as Exception);
                Console.WriteLine("Application terminating: {0}", eventArgs.IsTerminating);

            };

            var config = BuildConfiguration(builder.Environment.EnvironmentName, args);
            builder.Configuration.AddConfiguration(config);

            builder.Services.AddSingleton(implementationInstance: logger);
            builder.Services.AddSingleton(implementationInstance: config);
            
            #endregion

            #region Authentication configuration

            builder.Services.AddDefaultIdentity<WebAppUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<IdentityDbContext>();

            builder.Services
                .AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<WebAppUser>>();

            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddCascadingAuthenticationState();

            #endregion

            // Data access services
            var databaseProvider = config["DATABASE_PROVIDER"];
            builder.AddIdentityContextFactoryService(databaseProvider);
            
            builder.Services.AddDataAccessServices(
                databaseProvider: databaseProvider,
                developerMode: builder.Environment.IsDevelopment());

            // Blazor app services
            builder.Services.AddBlazorPageServices();

            builder.Services.AddRazorPages(options =>
            {
                options.Conventions.AuthorizeAreaFolder("Identity", "/");
                options.Conventions.AllowAnonymousToAreaPage("Identity", "/Account/Login");
            });

            builder.Services.AddServerSideBlazor();

            builder.Services.AddHttpServices();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            // Configure to use authentication/authorization.
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.Run();
        }
    }

    public partial class Program
    {
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
                    path: $"{Configuration.AssemblyInfo.ExecutingAssemblyPath}\\logs\\.log",
                    rollingInterval: RollingInterval.Day,
                    shared: true)
                .WriteTo.File(
                    formatter: new RenderedCompactJsonFormatter(),
                    path: $"{Configuration.AssemblyInfo.ExecutingAssemblyPath}\\logs\\.json",
                    rollingInterval: RollingInterval.Day,
                    shared: true)
                .CreateLogger();

            return Log.Logger;
        }

        /// <summary>
        /// Builds the application <see cref="IConfiguration"/> instance.
        /// </summary>
        /// <param name="environment">The application environment. One of: Development, Staging, Production.</param>
        /// <param name="args">Command line arguments to include in configuration.</param>
        /// <returns>An <see cref="IConfiguration"/>.</returns>
        private static IConfigurationRoot BuildConfiguration(
            string environment,
            string[] args)
        {
            if (string.IsNullOrEmpty(environment))
                throw new ArgumentNullException(paramName: nameof(environment));

            var configBuilder = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .AddJsonWritable(
                    path: $"appsettings.{environment}.json",
                    optional: false,
                    reloadOnChange: true);

            if(environment == "Development")
                configBuilder.AddUserSecrets<Program>(optional: true);

            if (args is not null && args.Length > 0)
                configBuilder.AddCommandLine(args);

            IConfigurationRoot config = configBuilder.Build();

            config.InitializeConfiguration();
            
            return config;
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
