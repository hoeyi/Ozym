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
            services
                .AddScoped<ICollectionController<AccountCustodian>, ModelCollectionController<AccountCustodian>>()
                .AddScoped<ICollectionController<AccountWallet, int>, ModelCollectionController<AccountWallet, int>>()
                .AddScoped<ICollectionController<BankTransaction, int>, ModelCollectionController<BankTransaction, int>>()
                .AddScoped<IBrokerTransactionController, BrokerTransactionController>()

                .AddScoped<ICollectionController<InvestmentPerformanceAttributeMemberEntry, (AccountObject, ModelAttributeMember)>,
                    ModelCollectionController<InvestmentPerformanceAttributeMemberEntry, (AccountObject, ModelAttributeMember)>>()

                .AddScoped<ICollectionController<InvestmentPerformanceEntry, int>, ModelCollectionController<InvestmentPerformanceEntry, int>>()

                .AddScoped<ICollectionController<MarketHolidayObservance>, ModelCollectionController<MarketHolidayObservance>>()
                .AddScoped<ICollectionController<MarketIndexPrice>, ModelCollectionController<MarketIndexPrice>>()
                .AddScoped<ICollectionController<SecurityExchange>, ModelCollectionController<SecurityExchange>>()
                .AddScoped<ICollectionController<SecurityPrice>, ModelCollectionController<SecurityPrice>>();
        }
    }
}
