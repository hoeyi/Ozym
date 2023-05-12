using Microsoft.EntityFrameworkCore;
using NjordinSight.EntityModel.Context.TestConfiguration;

namespace NjordinSight.EntityModel.Context
{
    /// <summary>
    /// Extension methods for the <see cref="ModelBuilder"/> class. Members are typcially used 
    /// to populate default reference and/or test data.
    /// </summary>
    internal static class ModelBuilderExtension
    {
        public static ModelBuilder SeedInitialData(
            this ModelBuilder modelBuilder, ISeedData seedData)
        {
            modelBuilder
                // Seed reference tables first.
                .SeedEntityData(seedData.AccountCustodians)
                .SeedEntityData(seedData.BankTransactionCodes)
                .SeedEntityData(seedData.BrokerTransactionCodes)
                .SeedEntityData(seedData.Countries)
                .SeedEntityData(seedData.InvestmentStrategies)
                .SeedEntityData(seedData.MarketHolidays)
                .SeedEntityData(seedData.MarketHolidayObservances)
                .SeedEntityData(seedData.ModelAttributes)
                .SeedEntityData(seedData.ModelAttributeScopes)
                .SeedEntityData(seedData.ModelAttributeMembers)
                .SeedEntityData(seedData.ReportConfigurations)
                .SeedEntityData(seedData.ReportStyleSheets)
                .SeedEntityData(seedData.ResourceImages)
                .SeedEntityData(seedData.SecurityExchanges)
                .SeedEntityData(seedData.SecurityTypeGroups)
                .SeedEntityData(seedData.SecurityTypes)
                .SeedEntityData(seedData.SecuritySymbolTypes)
                .SeedEntityData(seedData.MarketIndices)

                // Seed parent objects and other objects that are referenced by foreign keys.
                .SeedEntityData(seedData.AccountObjects)
                .SeedEntityData(seedData.Accounts)
                .SeedEntityData(seedData.AccountWallets)
                .SeedEntityData(seedData.AccountComposites)
                .SeedEntityData(seedData.AccountCompositeMembers)
                .SeedEntityData(seedData.Securities)
                .SeedEntityData(seedData.SecuritySymbols)
                
                // Seed non-attribute-specific transactional data.
                .SeedEntityData(seedData.BankTransactions)
                .SeedEntityData(seedData.BrokerTransactions)
                .SeedEntityData(seedData.InvestmentPerformanceEntries)
                .SeedEntityData(seedData.MarketIndexPrices)
                .SeedEntityData(seedData.SecurityPrices)
                // Seed attributes for applicable objects.

                .SeedEntityData(seedData.AccountAttributes)
                .SeedEntityData(seedData.BankTransactionCodeAttributes)
                .SeedEntityData(seedData.BrokerTransactionCodeAttributes)
                .SeedEntityData(seedData.CountryAttributes)
                .SeedEntityData(seedData.SecurityAttributes)
                
                // Seed attribute-specific transactional data.
                .SeedEntityData(seedData.InvestmentStrategyTargets)
                .SeedEntityData(seedData.InvestmentPerformanceAttributeEntries);
                
            return modelBuilder;
        }

        /// <summary>
        /// Seeds this <see cref="ModelBuilder"/> with the given <typeparamref name="T"/> entries.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="modelBuilder"></param>
        /// <param name="data">The collection of <typeparamref name="T"/> models to 
        /// insert.</param>
        public static ModelBuilder SeedEntityData<T>(
            this ModelBuilder modelBuilder,
            params T[] data)
            where T : class, new()
        {
            T[] nonNullItems = data?.Where(m => m is not null)?.ToArray();

            if (nonNullItems is null || nonNullItems.Length == 0)
                return modelBuilder;

            modelBuilder.Entity<T>().HasData(nonNullItems);

            return modelBuilder;
        }
    }
}
