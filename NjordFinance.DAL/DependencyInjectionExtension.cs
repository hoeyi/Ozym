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
            services.AddScoped<IReferenceDataService, ReferenceDataService>();

            services
                .AddScoped<IModelService<Account>, AccountService>()
                .AddScoped<IModelBatchService<AccountAttributeMemberEntry>, AccountAttributeMemberService>()
                .AddScoped<IModelService<AccountComposite>, AccountCompositeService>()
                .AddScoped<IModelBatchService<AccountCompositeMember>, AccountCompositeMemberService>()
                .AddScoped<IModelService<AccountCustodian>, AccountCustodianService>()

                .AddScoped<IModelBatchService<AccountCustodian>, AccountCustodianBatchService>()
                .AddScoped<IModelBatchService<Country>, CountryBatchService>()

                .AddScoped<IModelBatchService<AccountWallet>, AccountWalletService>()
                .AddScoped<IModelBatchService<BankTransactionCodeAttributeMemberEntry>, BankTransactionCodeAttributeService>()
                .AddScoped<IModelService<BankTransactionCode>, BankTransactionCodeService>()
                .AddScoped<IModelBatchService<BankTransaction>, BankTransactionService>()
                .AddScoped<IModelBatchService<BrokerTransactionCodeAttributeMemberEntry>, BrokerTransactionCodeAttributeService>()
                .AddScoped<IModelService<BrokerTransactionCode>, BrokerTransactionCodeService>()
                .AddScoped<IModelBatchService<BrokerTransaction>, BrokerTransactionService>()
                .AddScoped<IModelBatchService<CountryAttributeMemberEntry>, CountryAttributeService>()
                .AddScoped<IModelService<Country>, CountryService>()
                .AddScoped<IModelBatchService<InvestmentPerformanceAttributeMemberEntry>, InvestmentPerformanceAttributeService>()
                .AddScoped<IModelBatchService<InvestmentPerformanceEntry>, InvestmentPerformanceService>()
                .AddScoped<IModelService<InvestmentStrategy>, InvestmentStrategyService>()
                .AddScoped<IModelBatchService<InvestmentStrategyTarget>, InvestmentStrategyTargetService>()
                .AddScoped<IModelBatchService<MarketHolidayObservance>, MarketHolidayObservanceService>()
                .AddScoped<IModelService<MarketHoliday>, MarketHolidayService>()
                .AddScoped<IModelBatchService<MarketIndexPrice>, MarketIndexPriceService>()
                .AddScoped<IModelService<MarketIndex>, MarketIndexService>()
                .AddScoped<IModelService<ModelAttribute>, ModelAttributeService>()
                .AddScoped<IModelBatchService<ModelAttributeMember>, ModelAttributeMemberService>()
                .AddScoped<IModelService<ReportConfiguration>, ReportConfigurationService>()
                .AddScoped<IModelService<ReportStyleSheet>, ReportStyleSheetService>()
                .AddScoped<IModelService<ResourceImage>, ResourceImageService>()
                .AddScoped<IModelBatchService<SecurityAttributeMemberEntry>, SecurityAttributeService>()
                .AddScoped<IModelService<SecurityExchange>, SecurityExchangeService>()
                .AddScoped<IModelBatchService<SecurityPrice>, SecurityPriceService>()
                .AddScoped<IModelService<Security>, SecurityService>()
                .AddScoped<IModelBatchService<SecuritySymbol>, SecuritySymbolService>()
                .AddScoped<IModelService<SecuritySymbolType>, SecuritySymbolTypeService>()
                .AddScoped<IModelService<SecurityTypeGroup>, SecurityTypeGroupService>()
                .AddScoped<IModelService<SecurityType>, SecurityTypeService>();
        }

        /// <summary>
        /// Adds the controllers to the collection.
        /// </summary>
        /// <param name="services"></param>
        public static void AddModelControllers(this IServiceCollection services)
        {
            services
                .AddScoped<IController<Account>, ModelController<Account>>()
                .AddScoped<IBatchController<AccountAttributeMemberEntry>, ModelBatchController<AccountAttributeMemberEntry>>()
                .AddScoped<IController<AccountComposite>, ModelController<AccountComposite>>()
                .AddScoped<IBatchController<AccountCompositeMember>, ModelBatchController<AccountCompositeMember>>()
                .AddScoped<IController<AccountCustodian>, ModelController<AccountCustodian>>()

                .AddScoped<IBatchController<AccountCustodian>, ModelBatchController<AccountCustodian>>()
                .AddScoped<IBatchController<Country>, ModelBatchController<Country>>()

                .AddScoped<IBatchController<AccountWallet>, ModelBatchController<AccountWallet>>()
                .AddScoped<IBatchController<BankTransactionCodeAttributeMemberEntry>, ModelBatchController<BankTransactionCodeAttributeMemberEntry>>()
                .AddScoped<IController<BankTransactionCode>, ModelController<BankTransactionCode>>()
                .AddScoped<IBatchController<BankTransaction>, ModelBatchController<BankTransaction>>()
                .AddScoped<IBatchController<BrokerTransactionCodeAttributeMemberEntry>, ModelBatchController<BrokerTransactionCodeAttributeMemberEntry>>()
                .AddScoped<IController<BrokerTransactionCode>, ModelController<BrokerTransactionCode>>()
                .AddScoped<IBatchController<BrokerTransaction>, ModelBatchController<BrokerTransaction>>()
                .AddScoped<IBatchController<CountryAttributeMemberEntry>, ModelBatchController<CountryAttributeMemberEntry>>()
                .AddScoped<IController<Country>, ModelController<Country>>()
                .AddScoped<IBatchController<InvestmentPerformanceAttributeMemberEntry>, ModelBatchController<InvestmentPerformanceAttributeMemberEntry>>()
                .AddScoped<IBatchController<InvestmentPerformanceEntry>, ModelBatchController<InvestmentPerformanceEntry>>()
                .AddScoped<IController<InvestmentStrategy>, ModelController<InvestmentStrategy>>()
                .AddScoped<IBatchController<InvestmentStrategyTarget>, ModelBatchController<InvestmentStrategyTarget>>()
                .AddScoped<IBatchController<MarketHolidayObservance>, ModelBatchController<MarketHolidayObservance>>()
                .AddScoped<IController<MarketHoliday>, ModelController<MarketHoliday>>()
                .AddScoped<IBatchController<MarketIndexPrice>, ModelBatchController<MarketIndexPrice>>()
                .AddScoped<IController<MarketIndex>, ModelController<MarketIndex>>()
                .AddScoped<IController<ModelAttribute>, ModelController<ModelAttribute>>()
                .AddScoped<IBatchController<ModelAttributeMember>, ModelBatchController<ModelAttributeMember>>()
                .AddScoped<IController<ReportConfiguration>, ModelController<ReportConfiguration>>()
                .AddScoped<IController<ReportStyleSheet>, ModelController<ReportStyleSheet>>()
                .AddScoped<IController<ResourceImage>, ModelController<ResourceImage>>()
                .AddScoped<IBatchController<SecurityAttributeMemberEntry>, ModelBatchController<SecurityAttributeMemberEntry>>()
                .AddScoped<IController<SecurityExchange>, ModelController<SecurityExchange>>()
                .AddScoped<IBatchController<SecurityPrice>, ModelBatchController<SecurityPrice>>()
                .AddScoped<IController<Security>, ModelController<Security>>()
                .AddScoped<IBatchController<SecuritySymbol>, ModelBatchController<SecuritySymbol>>()
                .AddScoped<IController<SecuritySymbolType>, ModelController<SecuritySymbolType>>()
                .AddScoped<IController<SecurityTypeGroup>, ModelController<SecurityTypeGroup>>()
                .AddScoped<IController<SecurityType>, ModelController<SecurityType>>();
        }
    }
}
