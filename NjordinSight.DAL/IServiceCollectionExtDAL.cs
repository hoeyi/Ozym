﻿using NjordinSight.EntityModel;
using NjordinSight.EntityModelService;
using NjordinSight.EntityModelService.Query;
using Microsoft.Extensions.DependencyInjection;
using NjordinSight.EntityModelService.Abstractions;
using NjordinSight.BusinessLogic.Functions;
using Ichosys.DataModel;
using System.Runtime.CompilerServices;
using NjordinSight.Messaging;
using NjordinSight.BusinessLogic.MarketFeed;
using NjordinSight.UserInterface;
using System.Runtime.Serialization;
using NjordinSight.EntityModel.Context;
using System;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.EntityFrameworkCore;
using NjordinSight.DataTransfer.Profiles;
using AutoMapper;
using System.Reflection;

namespace NjordinSight
{
    /// <summary>
    /// Container for <see cref="IServiceCollection"/> extension methods that handle 
    /// registering data access layer services for use with dependency injection.
    /// </summary>
    public static class IServiceCollectionExtDAL
    {
        /// <summary>
        /// Registers all services required for classes in the <b>NjordinSight.DAL</b>
        /// assembly.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="developerMode">Whether the service registration is for a development 
        /// environment. See remarks.</param>
        /// <returns>A reference to this instance after the operation is completed.</returns>
        /// <remarks>Adds to the DI container:
        /// <list type="bullet">
        /// <item><see cref="ITypedMetadataService{T}"/></item>
        /// <item><see cref="IMapper"/></item>
        /// <item><see cref="IMessageService"/></item>
        /// <item><see cref="IQueryService"/></item>
        /// <item><see cref="IWatchlist"/></item>
        /// </list>
        /// Wraps methods:
        /// <list type="bullet">
        /// <item><see cref="AddCalculatorServices(IServiceCollection)"/></item>
        /// <item><see cref="AddMappingProfiles(IServiceCollection)"/></item>
        /// <item><see cref="AddModelServices(IServiceCollection)"/></item>
        /// </list>
        /// </remarks>
        public static IServiceCollection AddDataAccessServices(
            this IServiceCollection services,
            string databaseProvider,
            bool developerMode = false)
        {
            if (databaseProvider is null)
                throw new ArgumentNullException(paramName: nameof(databaseProvider));

            var dbProvider = databaseProvider.ConvertFromStringCode<DatabaseProvider>() ?? 
                throw new InvalidOperationException();

            services
                .AddSingleton<IModelMetadataService, ModelMetadataService>()
                .AddSingleton<IMessageService, MessageService>()
                .AddSingleton<IQueryService, QueryService>()
                .AddTransient<IWatchlist, Watchlist>()
                .AddCalculatorServices()
                .AddMappingProfiles()
                .AddModelServices()
                .AddDbContextFactoryServices(dbProvider, developerMode);

            return services;
        }

        /// <summary>
        /// Registers all calculator services declared in the <b>NjordinSight.DAL</b>
        /// assembly.
        /// </summary>
        /// <param name="services"></param>
        /// <returns>A reference to this instance after the operation is completed.</returns>
        /// <remarks>Adds to the DI container:
        /// <list type="bullet">
        /// <item><see cref="IFinancialCalculator}"/></item>
        /// <item><see cref="IStatisticsCalculator"/></item>
        /// </list>
        /// </remarks>
        public static IServiceCollection AddCalculatorServices(this IServiceCollection services)
        {
            services
                .AddTransient<IFinancialCalculator, FinancialCalculator>()
                .AddTransient<IStatisticsCalculator, StatisticsCalculator>();

            return services;
        }

        /// <summary>
        /// Registers all entity model services defined in <b>NjordinSight.DAL.EntityModelService</b>.
        /// </summary>
        /// <param name="services"></param>
        /// <returns>A reference to this instance after the operation is completed.</returns>
        public static IServiceCollection AddModelServices(this IServiceCollection services)
        {
            services
                // Add single-entity services.
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
                .AddScoped<IModelService<SecurityPrice>, SecurityPriceService>()

                // Add entity-collection services.
                .AddScoped<IModelCollectionService<AccountCustodian>, AccountCustodianCollectionService>()
                .AddScoped<IModelCollectionService<AccountWallet, int>, AccountWalletService>()
                .AddScoped<IModelCollectionService<BankTransaction, int>, BankTransactionService>()
                .AddScoped<IModelCollectionService<BrokerTransaction, int>, BrokerTransactionService>()
                .AddScoped<IModelCollectionService<
                    InvestmentPerformanceAttributeMemberEntry, (AccountObject, ModelAttributeMember)>, 
                    InvestmentPerformanceAttributeService>()
                .AddScoped<IModelCollectionService<InvestmentPerformanceEntry, int>, InvestmentPerformanceService>()
                .AddScoped<IModelCollectionService<MarketHolidayObservance>, MarketHolidayObservanceService>()
                .AddScoped<IModelCollectionService<MarketIndexPrice>, MarketIndexPriceBatchService>()
                .AddScoped<IModelCollectionService<SecurityExchange>, SecurityExchangeCollectionService>()
                .AddScoped<IModelCollectionService<SecurityPrice>, SecurityPriceBatchService>();

            return services;
        }

        /// <summary>
        /// Registers AutoMapper with all <see cref="Profile"/>-derived classes in the 
        /// <b>NjordinSight.DAL</b> assembly.
        /// </summary>
        /// <param name="services"></param>
        /// <returns>A reference to this instance after the operation is completed.</returns>
        public static IServiceCollection AddMappingProfiles(this IServiceCollection services)
        {
            // Grab all Profile-derived classes defined in the assembly with AccountProfile.
            services.AddAutoMapper(Assembly.GetAssembly(typeof(AccountProfile)));

            return services;
        }
    }
}