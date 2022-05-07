using NjordFinance.Controllers;
using NjordFinance.Model;
using NjordFinance.ModelService;
using NjordFinance.Reference;
using Microsoft.Extensions.DependencyInjection;
using NjordFinance.ModelService.Abstractions;

namespace NjordFinance
{
    public static class DependencyInjectionExtension
    {
        /// <summary>
        /// Adds the model context services to the collection.
        /// </summary>
        /// <param name="services"></param>
        public static void AddModelServices(this IServiceCollection services)
        {
            // Add reference data service for querying lookup lists.
            services.AddScoped<IReferenceDataService, ReferenceDataService>();

            services.AddScoped<IModelServiceSingle<Account>, AccountService>();
            services.AddScoped<IModelServiceMultiple<AccountWallet>, AccountWalletService>();
        }

        /// <summary>
        /// Adds the component controllers to the collection.
        /// </summary>
        /// <param name="services"></param>
        public static void AddModelControllers(this IServiceCollection services)
        {
            services.AddScoped<IController<Account>, AccountsController>();
            services.AddScoped<IBatchController<AccountWallet>, AccountWalletsController>();
        }
    }
}
