using NjordFinance.EntityModel;
using NjordFinance.EntityModelService;
using NjordFinance.EntityModelService.Query;
using Microsoft.Extensions.DependencyInjection;

namespace NjordFinance
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
                .AddScoped<IModelService<SecuritySymbolType>, SecuritySymbolTypeService>()
                .AddScoped<IModelService<SecurityTypeGroup>, SecurityTypeGroupService>()
                .AddScoped<IModelService<SecurityType>, SecurityTypeService>();

            // Add batch services.
            services
                .AddScoped<IModelBatchService<AccountAttributeMemberEntry>, AccountAttributeMemberService>()
                .AddScoped<IModelBatchService<AccountCompositeMember>, AccountCompositeMemberService>()
                .AddScoped<IModelBatchService<AccountCustodian>, AccountCustodianBatchService>()
                .AddScoped<IModelBatchService<AccountWallet>, AccountWalletService>()
                .AddScoped<IModelBatchService<BankTransaction>, BankTransactionService>()
                .AddScoped<IModelBatchService<BankTransactionCode>, BankTransactionCodeBatchService>()
                .AddScoped<IModelBatchService<BankTransactionCodeAttributeMemberEntry>, BankTransactionCodeAttributeService>()
                .AddScoped<IModelBatchService<BrokerTransaction>, BrokerTransactionService>()
                .AddScoped<IModelBatchService<BrokerTransactionCode>, BrokerTransactionCodeBatchService>()
                .AddScoped<IModelBatchService<BrokerTransactionCodeAttributeMemberEntry>, BrokerTransactionCodeAttributeService>()
                .AddScoped<IModelBatchService<CountryAttributeMemberEntry>, CountryAttributeService>()
                .AddScoped<IModelBatchService<InvestmentPerformanceAttributeMemberEntry>, InvestmentPerformanceAttributeService>()
                .AddScoped<IModelBatchService<InvestmentPerformanceEntry>, InvestmentPerformanceService>()
                .AddScoped<IModelBatchService<InvestmentStrategyTarget>, InvestmentStrategyTargetService>()
                .AddScoped<IModelBatchService<MarketHolidayObservance>, MarketHolidayObservanceService>()
                .AddScoped<IModelBatchService<MarketIndexPrice>, MarketIndexPriceBatchService>()
                .AddScoped<IModelBatchService<ModelAttributeMember>, ModelAttributeMemberService>()
                .AddScoped<IModelBatchService<SecurityAttributeMemberEntry>, SecurityAttributeService>()
                .AddScoped<IModelBatchService<SecurityExchange>, SecurityExchangeBatchService>()
                .AddScoped<IModelBatchService<SecurityPrice>, SecurityPriceService>()
                .AddScoped<IModelBatchService<SecuritySymbol>, SecuritySymbolService>();
        }
    }
}
