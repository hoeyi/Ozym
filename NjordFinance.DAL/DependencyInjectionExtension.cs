using NjordFinance.Controllers;
using NjordFinance.Controllers.Abstractions;
using NjordFinance.Model;
using NjordFinance.ModelService;
using Microsoft.Extensions.DependencyInjection;

namespace NjordFinance
{
    /// <summary>
    /// Container for service registration extension methods to support 
    /// depedency injection for external projects.
    /// </summary>
    public static class DependencyInjectionExtension
    {
        /// <summary>
        /// Adds the model services to the collection.
        /// </summary>
        /// <param name="services"></param>
        public static void AddModelServices(this IServiceCollection services)
        {
            // Add reference data service for querying lookup lists.
            services.AddSingleton<IReferenceDataService, ReferenceDataService>();

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
                .AddScoped<IModelBatchService<Country>, CountryBatchService>()
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
                .AddScoped<IController<SecuritySymbolType>, ModelController<SecuritySymbolType>>()
                .AddScoped<IController<SecurityTypeGroup>, ModelController<SecurityTypeGroup>>()
                .AddScoped<IController<SecurityType>, ModelController<SecurityType>>();
            
            // Add batch controllers.
            // These should probably be transient, else changes one page may be retained 
            // (even if unsaved) on the next page, e.g., delete records without saving, cancel changes, 
            // then make different changes. Pending changes from both actions will still be in the context.
            // Alternative is to expose a cancel changes method so that the context can revert to its
            // original state.
            services
                .AddScoped<IBatchController<AccountAttributeMemberEntry>, ModelBatchController<AccountAttributeMemberEntry>>()
                .AddScoped<IBatchController<AccountCompositeMember>, ModelBatchController<AccountCompositeMember>>()
                .AddScoped<IBatchController<AccountCustodian>, ModelBatchController<AccountCustodian>>()
                .AddScoped<IBatchController<Country>, ModelBatchController<Country>>()
                .AddScoped<IBatchController<AccountWallet>, ModelBatchController<AccountWallet>>()
                .AddScoped<IBatchController<BankTransaction>, ModelBatchController<BankTransaction>>()
                .AddScoped<IBatchController<BankTransactionCode>, ModelBatchController<BankTransactionCode>>()
                .AddScoped<IBatchController<BankTransactionCodeAttributeMemberEntry>, ModelBatchController<BankTransactionCodeAttributeMemberEntry>>()
                .AddScoped<IBatchController<BrokerTransaction>, ModelBatchController<BrokerTransaction>>()
                .AddScoped<IBatchController<BrokerTransactionCode>, ModelBatchController<BrokerTransactionCode>>()
                .AddScoped<IBatchController<BrokerTransactionCodeAttributeMemberEntry>, ModelBatchController<BrokerTransactionCodeAttributeMemberEntry>>()
                .AddScoped<IBatchController<CountryAttributeMemberEntry>, ModelBatchController<CountryAttributeMemberEntry>>()
                .AddScoped<IBatchController<InvestmentPerformanceAttributeMemberEntry>, ModelBatchController<InvestmentPerformanceAttributeMemberEntry>>()
                .AddScoped<IBatchController<InvestmentPerformanceEntry>, ModelBatchController<InvestmentPerformanceEntry>>()
                .AddScoped<IBatchController<InvestmentStrategyTarget>, ModelBatchController<InvestmentStrategyTarget>>()
                .AddScoped<IBatchController<MarketHolidayObservance>, ModelBatchController<MarketHolidayObservance>>()
                .AddScoped<IBatchController<MarketIndexPrice>, ModelBatchController<MarketIndexPrice>>()
                .AddScoped<IBatchController<ModelAttributeMember>, ModelBatchController<ModelAttributeMember>>()
                .AddScoped<IBatchController<SecurityAttributeMemberEntry>, ModelBatchController<SecurityAttributeMemberEntry>>()
                .AddScoped<IBatchController<SecurityExchange>, ModelBatchController<SecurityExchange>>()
                .AddScoped<IBatchController<SecurityPrice>, ModelBatchController<SecurityPrice>>()
                .AddScoped<IBatchController<SecuritySymbol>, ModelBatchController<SecuritySymbol>>();
        }
    }
}
