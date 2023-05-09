using NjordinSight;
using NjordinSight.Web.Areas.Identity;
using NjordinSight.Web.Areas.Identity.Data;
using NjordinSight.Web.Data;
using NjordinSight.Messaging;
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
using NjordinSight.Web;
using NjordinSight.EntityModel.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region Configuration, Logger, Helper services

var databaseProvider = System.Environment.GetEnvironmentVariable("DATABASE_PROVIDER");
var logger = ConvertFromSerilogILogger(logger: BuildLogger());
var config = BuildConfiguration(logger, databaseProvider == "SQL_SERVER");

builder.Services.AddSingleton(implementationInstance: logger);
builder.Services.AddSingleton(implementationInstance: config);

builder.Services.AddSingleton(ISvgHelper.Create());

#endregion

#region Authentication configuration

// Add identity management database
builder.Services.AddDbContext<IdentityDbContext>(options =>
{
    if(builder.Environment.IsDevelopment())
    {
        if (string.IsNullOrEmpty(databaseProvider))
            options.UseInMemoryDatabase("NjordIdentity");

        else if(databaseProvider == "SQL_SERVER")
            options.UseSqlServer("Name=ConnectionStrings:NjordIdentity");
    }
});

builder.Services.AddDefaultIdentity<WebAppUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<IdentityDbContext>();

builder.Services
    .AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<WebAppUser>>();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

#endregion

#region Data-access service configuration

// Add metadata, search, and message services.
builder.Services.AddSingleton<IExpressionBuilder, ExpressionBuilder>();
builder.Services.AddSingleton<IModelMetadataService, ModelMetadataService>();
builder.Services.AddSingleton<IMessageService, MessageService>();

// Add database service.
builder.Services.AddDbContextFactory<FinanceDbContext>(options =>
    {
        if (builder.Environment.IsDevelopment())
        {
            if (string.IsNullOrEmpty(databaseProvider))
               options.UseInMemoryDatabase("NjordWorks");

            else if (databaseProvider == "SQL_SERVER")
                options.UseSqlServer("Name=ConnectionStrings:NjordWorks");
        }
    });

if(builder.Environment.IsDevelopment() && string.IsNullOrEmpty(databaseProvider))
{
    SeedInMemoryDatabase();
}

// Register model services and controllers.
builder.Services.AddModelServices();
builder.Services.AddModelControllers();

#endregion

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

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

partial class Program
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
                path: $"{NjordinSight.Configuration.AssemblyInfo.ExecutingAssemblyPath}\\logs\\.log",
                rollingInterval: RollingInterval.Day,
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
    /// Builds the application <see cref="IConfiguration"/> instance.
    /// </summary>
    /// <param name="logger">The <see cref="ILogger"/> to use.</param>
    /// <returns>An <see cref="IConfiguration"/>.</returns>
    private static IConfigurationRoot BuildConfiguration(ILogger logger, bool configureSecureJson = true)
    {
        IConfigurationRoot config;
        if(configureSecureJson)
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
            config["ConnectionStrings:NjordIdentity"] = config["ConnectionStrings:NjordIdentity"];
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
    /// Converts a <see cref="Serilog.ILogger"/> instance to a <see cref="ILogger"/> instance.
    /// </summary>
    /// <param name="logger"></param>
    /// <returns>A <see cref="ILogger"/>.</returns>
    private static ILogger ConvertFromSerilogILogger(Serilog.ILogger logger)
    {
        return new SerilogLoggerFactory(logger).CreateLogger(nameof(Program));
    }

    /// <summary>
    /// Recreates the 'NjordWorks' database, but takes no action on the 'NjordIdentity' database.
    /// Call only once during start-up to seed data for an in-memory data store.
    /// </summary>
    private static void SeedInMemoryDatabase()
    {
        var optionsBuild = new DbContextOptionsBuilder<FinanceDbContext>();
        optionsBuild.UseInMemoryDatabase("NjordWorks");
            
        using var context = new FinanceDbContext(optionsBuild.Options);

        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
    }
}