using Microsoft.Extensions.DependencyInjection;
using NjordinSight.BusinessLogic.Functions;
using NjordinSight.BusinessLogic.MarketFeed;
using NjordinSight.EntityModel;
using NjordinSight.EntityModel.Context;
using NjordinSight.Web.Controllers;
using NjordinSight.Web.Controllers.Abstractions;
using NjordinSight.Web.Services;
using NjordinSight.Web.Data;
using System;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Ichosys.DataModel.Expressions;
using Ichosys.DataModel;
using NjordinSight.Messaging;
using NjordinSight.UserInterface;
using Ichosys.Blazor.Ionicons;

namespace NjordinSight.Web
{
    /// <summary>
    /// Container for <see cref="IServiceCollection"/> extension methods that handle 
    /// registering web layer services for use with dependency injection.
    /// </summary>
    public static class DependencyInjectionWebExt
    {
        /// <summary>
        /// Database or database store name for the core application entity model.
        /// </summary>
        private const string app_db_name = "NjordWorks";

        /// <summary>
        /// Database or database store for the web identity management entity model.
        /// </summary>
        private const string identity_db_name = "NjordIdentity";

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

        /// <summary>
        /// Adds auxiliary business logic services to this service collection.
        /// </summary>
        /// <param name="services"></param>
        /// <exception cref="NotImplementedException"></exception>
        public static void AddAuxiliaryServices(this IServiceCollection services)
        {
            services
                // Caclulator and dashboard services.
                .AddTransient<IFinancialCalculator, FinancialCalculator>()
                .AddTransient<IStatisticsCalculator, StatisticsCalculator>()
                .AddTransient<IWatchlist, Watchlist>()

                // Add metadata, search, and message services.
                .AddSingleton<IModelMetadataService, ModelMetadataService>()
                .AddSingleton(typeof(ITypedMetadataService<>), typeof(TypedMetadataService<>))
                .AddSingleton<IExpressionBuilder, ExpressionBuilder>()

                .AddTransient(typeof(ISearchService<>), typeof(SearchService<>))
                .AddSingleton<IMessageService, MessageService>()

                // View helper services
                .AddSingleton(ISvgHelper.Create());
        }

        /// <summary>
        /// Configures the <see cref="FinanceDbContext"/> and <see cref="IdentityDbContext"/> 
        /// factory services.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="databaseProvider">The string name identifying the database provide.</param>
        /// <exception cref="NotSupportedException"></exception>
        public static void ConfigureDbContextFactories(
            this WebApplicationBuilder builder, string databaseProvider)
        {
            // Add database service.
            builder.Services.AddDbContextFactory<FinanceDbContext>(options =>
            {

                if (string.IsNullOrEmpty(databaseProvider) && builder.Environment.IsDevelopment())
                    options.UseInMemoryDatabase(app_db_name);

                else if (databaseProvider == "SQL_SERVER")
                    options.UseSqlServer(
                        connectionString: $"Name=ConnectionStrings:{app_db_name}",
                        sqlServerOptionsAction: x => x.MigrationsAssembly("NjordinSight.EntityMigration"));
                else
                    throw new NotSupportedException();
            });


            // Add identity management database service
            builder.Services.AddDbContext<IdentityDbContext>(options =>
            {
                if (string.IsNullOrEmpty(databaseProvider) && builder.Environment.IsDevelopment())
                    options.UseInMemoryDatabase(identity_db_name);

                else if (databaseProvider == "SQL_SERVER")
                    options.UseSqlServer(
                        connectionString: $"Name=ConnectionStrings:{identity_db_name}");
                else
                    throw new NotSupportedException();
            });

            if (builder.Environment.IsDevelopment() && string.IsNullOrEmpty(databaseProvider))
            {
                SeedInMemoryDatabase();
            }
        }

        /// <summary>
        /// Recreates the 'NjordWorks' database, but takes no action on the 'NjordIdentity' database.
        /// Call only once during start-up to seed data for an in-memory data store.
        /// Only for use in development/demonstration purposes.
        /// </summary>
        private static void SeedInMemoryDatabase()
        {
            var optionsBuild = new DbContextOptionsBuilder<FinanceDbContext>();
            optionsBuild.UseInMemoryDatabase(app_db_name);

            using var context = new FinanceDbContext(optionsBuild.Options);

            context.Database.EnsureCreated();
        }
    }

    /// <summary>
    /// Enumerate the supported database providers.
    /// </summary>
    public enum DatabaseProvider
    {
        /// <summary>
        /// Represents an in-memory DB provider. Not for use in production.
        /// </summary>
        [EnumMember(Value = "IN_MEMORY")]
        InMemory = 0,

        /// <summary>
        /// Represents a SQL Server relational database.
        /// </summary>
        [EnumMember(Value = "SQL_SERVER")]
        SqlService = 1
    }
}
