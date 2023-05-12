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
using System;
using Microsoft.AspNetCore.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Register services for dependency injection
#region Configuration, Logger, Helper services

var databaseProvider = builder.Configuration["DATABASE_PROVIDER"];

var logger = ConvertFromSerilogILogger(logger: BuildLogger());
var config = BuildConfiguration(logger, databaseProvider == "SQL_SERVER");

builder.Services.AddSingleton(implementationInstance: logger);
builder.Services.AddSingleton(implementationInstance: config);

builder.Services.AddSingleton(ISvgHelper.Create());

#endregion

#region Add database contexts

// Add database service.
builder.Services.AddDbContextFactory<FinanceDbContext>(options =>
{

    if (string.IsNullOrEmpty(databaseProvider) && builder.Environment.IsDevelopment())
        options.UseInMemoryDatabase(app_db_name);

    else if (databaseProvider == "SQL_SERVER")
        options.UseSqlServer(
            connectionString: $"Name=ConnectionStrings:{app_db_name}");
    //sqlServerOptionsAction: x => x.MigrationsAssembly("NjordinSight.EntityMigration"));
    else
        throw new NotSupportedException();
});

// Add identity management database service
builder.Services.AddDbContext<IdentityDbContext>(options =>
{
    if (string.IsNullOrEmpty(databaseProvider) && builder.Environment.IsDevelopment())
        options.UseInMemoryDatabase(identity_db_name);

    else if (databaseProvider == "SQL_SERVER")
        options.UseSqlServer(
            connectionString: $"Name=ConnectionStrings:{identity_db_name}");
    else
        throw new NotSupportedException();
});

if(builder.Environment.IsDevelopment() && string.IsNullOrEmpty(databaseProvider))
{
    SeedInMemoryDatabase();
}

#endregion

#region Authentication configuration

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
    /// Database or database store name for the core application entity model.
    /// </summary>
    private const string app_db_name = "NjordWorks";

    /// <summary>
    /// Database or database store for the web identity management entity model.
    /// </summary>
    private const string identity_db_name = "NjordIdentity";

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
    /// Only for use in development/demonstration purposes.
    /// </summary>
    private static void SeedInMemoryDatabase()
    {
        var optionsBuild = new DbContextOptionsBuilder<FinanceDbContext>();
        optionsBuild.UseInMemoryDatabase(app_db_name);
            
        using var context = new FinanceDbContext(optionsBuild.Options);

        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
    }
}