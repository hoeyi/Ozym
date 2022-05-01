using NjordFinance;
using NjordFinance.Web.Areas.Identity;
using NjordFinance.Web.Areas.Identity.Data;
using NjordFinance.Web.Data;
using Ichosoft.DataModel;
using Ichosoft.DataModel.Expressions;
using Ichosoft.Extensions.Configuration;
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
using Ichosoft.Blazor.Ionicons;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region Configuration, Logger, Helper services

var logger = ConvertFromSerilogILogger(logger: BuildLogger());
var config = BuildConfiguration(logger);

// Copy UserSecret connection string value to secure configuration.
config["ConnectionStrings:NjordFinance"] = config["ConnectionStrings:NjordFinance"];
config.Commit();

builder.Services.AddSingleton(implementationInstance: logger);
builder.Services.AddSingleton(implementationInstance: config);

builder.Services.AddSingleton(ISvgHelper.Create());

#endregion

#region Authentication configuration

// Add identity management database
builder.Services.AddDbContext<IdentityDbContext>(options =>
    options.UseSqlServer("Name=ConnectionStrings:NjordFinance"));

builder.Services.AddDefaultIdentity<WebAppUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<IdentityDbContext>();

builder.Services
    .AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<WebAppUser>>();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

#endregion

#region Data-access service configuration

// Add metadata and search services.
builder.Services.AddSingleton<IExpressionBuilder, ExpressionBuilder>();
builder.Services.AddSingleton<IModelMetadataService, ModelMetadataService>();

// Add database service.
builder.Services.AddDbContextFactory<NjordFinance.Context.FinanceDbContext>(options =>
    options.UseSqlServer("Name=ConnectionStrings:NjordFinance"));

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
        Log.Logger = new Serilog.LoggerConfiguration()
            .Enrich.FromLogContext()
            .MinimumLevel.Information()
            .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Information)
            .WriteTo.File(
                path: $"{NjordFinance.Configuration.AssemblyInfo.ExecutingAssemblyPath}\\logs\\.log",
                rollingInterval: RollingInterval.Day,
                shared: true)
            .WriteTo.File(
                formatter: new RenderedCompactJsonFormatter(),
                path: $"{NjordFinance.Configuration.AssemblyInfo.ExecutingAssemblyPath}\\logs\\.json",
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
    private static IConfigurationRoot BuildConfiguration(ILogger logger)
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