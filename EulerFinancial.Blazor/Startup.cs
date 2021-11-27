using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using EulerFinancial.Controllers;
using EulerFinancial.Reference;
using EulerFinancial.ModelService;
using EulerFinancial.Model;
using EulerFinancial.Blazor.Controllers;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Sinks.File;
using Serilog.Formatting.Compact;
using Serilog.Events;

namespace EulerFinancial.Blazor
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();

            services.AddSingleton(Serilog.Log.Logger);

            services.AddDbContext<Context.EulerFinancialContext>(options =>
                options.UseSqlServer("Name=ConnectionStrings:EulerFinancial"));

            services.AddScoped<IReferenceDataService, ReferenceDataService>();

            services.AddScoped<IModelService<Account>, AccountService>();
            services.AddScoped<IController<Account>, AccountsController>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            SetLoggerConfiguration(env);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
        private static void SetLoggerConfiguration(IWebHostEnvironment env)
        {
            var loggerConfig = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.File(
                    path: $"{EulerFinancial.Configuration.AssemblyInfoHelper.ExecutingAssemblyPath}\\.log",
                    rollingInterval: RollingInterval.Day,
                    shared: true);

            if (env.IsDevelopment())
            {
                Log.Logger = loggerConfig.MinimumLevel.Debug().CreateLogger();
            }
            else
            {
                Log.Logger = loggerConfig.MinimumLevel.Information().CreateLogger();
            }
        }
    }
}
