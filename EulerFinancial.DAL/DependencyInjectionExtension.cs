using EulerFinancial.Controllers;
using EulerFinancial.Model;
using EulerFinancial.ModelService;
using EulerFinancial.Reference;
using Microsoft.Extensions.DependencyInjection;

namespace EulerFinancial
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

            services.AddScoped<IModelService<Account>, AccountService>();
            services.AddScoped<IBatchModelService<AccountWallet>, AccountWalletService>();
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
