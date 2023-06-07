using NjordinSight.EntityModel;
using NjordinSight.EntityModelService;
using NjordinSight.EntityModelService.Query;
using Microsoft.Extensions.DependencyInjection;
using NjordinSight.EntityModelService.Abstractions;

namespace NjordinSight
{
    /// <summary>
    /// Container for <see cref="IServiceCollection"/> extension methods that handle 
    /// registering data access layer services for use with dependency injection.
    /// </summary>
    public static class DependencyInjectionDataAccessExt
    {
        /// <summary>
        /// Adds the model services to the collection.
        /// </summary>
        /// <param name="services"></param>
        public static void AddModelServices(this IServiceCollection services)
        {
            // Add reference data service for querying lookup lists.
            services.AddSingleton<IQueryService, QueryService>();

            // Add single-entity services.
            services
                .AddScoped<IModelService<Account>, AccountService>()
                .AddScoped<IModelService<AccountComposite>, AccountCompositeService>()
                .AddScoped<IModelService<AccountCustodian>, AccountCustodianService>()
                .AddScoped<IModelService<BankTransactionCode>, BankTransactionCodeService>()
                .AddScoped<IModelService<BrokerTransactionCode>, BrokerTransactionCodeService>()
                .AddScoped<IModelService<Country>, CountryService>()
                .AddScoped<IModelService<InvestmentStrategy>, InvestmentStrategyService>()
                .AddScoped<IModelService<MarketHoliday>, MarketHolidayService>()
                .AddScoped<IModelService<MarketIndex>, MarketIndexService>()
                .AddScoped<IModelService<ModelAttribute>, ModelAttributeService>()
                .AddScoped<IModelService<ReportConfiguration>, ReportConfigurationService>()
                .AddScoped<IModelService<ReportStyleSheet>, ReportStyleSheetService>()
                .AddScoped<IModelService<ResourceImage>, ResourceImageService>()
                .AddScoped<IModelService<SecurityExchange>, SecurityExchangeService>()
                .AddScoped<IModelService<Security>, SecurityService>()
                .AddScoped<IModelService<SecurityTypeGroup>, SecurityTypeGroupService>()
                .AddScoped<IModelService<SecurityType>, SecurityTypeService>()

                .AddScoped<IModelService<SecurityPrice>, SecurityPriceService>();

            // Add batch services.
            services
                .AddScoped<IModelBatchService<AccountCustodian>, AccountCustodianBatchService>()
                .AddScoped<IModelBatchService<AccountWallet>, AccountWalletService>()
                .AddScoped<IModelCollectionService<BankTransaction>, BankTransactionService>()
                .AddScoped<IModelBatchService<BrokerTransaction>, BrokerTransactionService>()
                .AddScoped<IModelBatchService<InvestmentPerformanceAttributeMemberEntry>, InvestmentPerformanceAttributeService>()
                .AddScoped<IModelBatchService<InvestmentPerformanceEntry>, InvestmentPerformanceService>()
                .AddScoped<IModelBatchService<MarketHolidayObservance>, MarketHolidayObservanceService>()
                .AddScoped<IModelBatchService<MarketIndexPrice>, MarketIndexPriceBatchService>()
                .AddScoped<IModelBatchService<SecurityExchange>, SecurityExchangeBatchService>()
                .AddScoped<IModelBatchService<SecurityPrice>, SecurityPriceBatchService>();
        }
    }
}
