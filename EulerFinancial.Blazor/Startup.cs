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
using Serilog;
using Ichosoft.DataModel.Expressions;
using Ichosoft.DataModel;
using System.Globalization;
using Serilog.Extensions.Logging;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

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

            // Add singleton services.
            services.AddSingleton(implementationInstance: Log.Logger);
            services.AddSingleton(implementationInstance: Program.Configuration);
            services.AddSingleton<IExpressionBuilder, ExpressionBuilder>();
            services.AddSingleton<IModelMetadataService, ModelMetadataService>();


            // Add Microsoft.Extensions.Logging.ILogger service
            services.AddSingleton(implementationInstance:
                new SerilogLoggerFactory(Log.Logger).CreateLogger(nameof(Program)));

            services.Configure<OpenIdConnectOptions>(
                OpenIdConnectDefaults.AuthenticationScheme, options =>
                {
                    options.ResponseType = OpenIdConnectResponseType.Code;
                    options.SaveTokens = true;

                    options.Scope.Add("offline_access");
                });


            // Add database service.
            services.AddDbContext<Context.EulerFinancialContext>(
                optionsAction: options => options.UseSqlServer("Name=ConnectionStrings:EulerFinancial"),
                optionsLifetime: ServiceLifetime.Singleton,
                contextLifetime: ServiceLifetime.Transient);

            // Add reference and model services.
            services.AddScoped<IReferenceDataService, ReferenceDataService>();

            services.AddScoped<IModelService<Account>, AccountService>();
            services.AddScoped<IController<Account>, AccountsController>();
            
            //services.AddLocalization(options => options.ResourcesPath = "Resources");
            services.AddLocalization();
            var supportedCultures = new CultureInfo[] { new CultureInfo("en-US"), new CultureInfo("de-DE") };
            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = 
                    new Microsoft.AspNetCore.Localization.RequestCulture(supportedCultures[0]);
                options.SupportedUICultures = supportedCultures;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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
            app.UseRequestLocalization();
            
            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
 