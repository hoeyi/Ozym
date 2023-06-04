using Microsoft.Extensions.DependencyInjection;
using NjordinSight.EntityModel;
using NjordinSight.Web.Controllers;
using NjordinSight.Web.Controllers.Abstractions;

namespace NjordinSight.Web
{
    /// <summary>
    /// Container for <see cref="IServiceCollection"/> extension methods that handle 
    /// registering web layer services for use with dependency injection.
    /// </summary>
    public static class DependencyInjectionWebExt
    {
        /// <summary>
        /// Adds the controllers to the collection.
        /// </summary>
        /// <param name="services"></param>
        public static void AddModelControllers(this IServiceCollection services)
        {
            // Add single-entity controllers.
            services
                .AddScoped<IController<Account>, ModelController<Account>>()
                .AddScoped<IController<AccountComposite>, ModelController<AccountComposite>>()
                .AddScoped<IController<AccountCustodian>, ModelController<AccountCustodian>>()
                .AddScoped<IController<BankTransactionCode>, ModelController<BankTransactionCode>>()
                .AddScoped<IController<BrokerTransactionCode>, ModelController<BrokerTransactionCode>>()
                .AddScoped<IController<Country>, ModelController<Country>>()
                .AddScoped<IController<InvestmentStrategy>, ModelController<InvestmentStrategy>>()
                .AddScoped<IController<MarketHoliday>, ModelController<MarketHoliday>>()
                .AddScoped<IController<MarketIndex>, ModelController<MarketIndex>>()
                .AddScoped<IController<ModelAttribute>, ModelController<ModelAttribute>>()
                .AddScoped<IController<ReportConfiguration>, ModelController<ReportConfiguration>>()
                .AddScoped<IController<ReportStyleSheet>, ModelController<ReportStyleSheet>>()
                .AddScoped<IController<ResourceImage>, ModelController<ResourceImage>>()
                .AddScoped<IController<SecurityExchange>, ModelController<SecurityExchange>>()
                .AddScoped<IController<Security>, ModelController<Security>>()
                .AddScoped<IController<SecurityTypeGroup>, ModelController<SecurityTypeGroup>>()
                .AddScoped<IController<SecurityType>, ModelController<SecurityType>>()

                .AddScoped<IController<SecurityPrice>, ModelController<SecurityPrice>>();

            // Add batch controllers.
            // These should probably be transient, else changes one page may be retained 
            // (even if unsaved) on the next page, e.g., delete records without saving, cancel changes, 
            // then make different changes. Pending changes from both actions will still be in the context.
            // Alternative is to expose a cancel changes method so that the context can revert to its
            // original state.
            services
                .AddScoped<IBatchController<AccountCustodian>, ModelBatchController<AccountCustodian>>()
                .AddScoped<IBatchController<AccountWallet>, ModelBatchController<AccountWallet>>()
                .AddScoped<IBatchController<BankTransaction>, ModelBatchController<BankTransaction>>()
                .AddScoped<IBrokerTransactionController, BrokerTransactionController>()
                .AddScoped<IBatchController<InvestmentPerformanceAttributeMemberEntry>, ModelBatchController<InvestmentPerformanceAttributeMemberEntry>>()
                .AddScoped<IBatchController<InvestmentPerformanceEntry>, ModelBatchController<InvestmentPerformanceEntry>>()
                .AddScoped<IBatchController<MarketHolidayObservance>, ModelBatchController<MarketHolidayObservance>>()
                .AddScoped<IBatchController<MarketIndexPrice>, ModelBatchController<MarketIndexPrice>>()
                .AddScoped<IBatchController<SecurityExchange>, ModelBatchController<SecurityExchange>>()
                .AddScoped<IBatchController<SecurityPrice>, ModelBatchController<SecurityPrice>>();
        }
    }
}
