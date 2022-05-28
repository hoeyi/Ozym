using Microsoft.EntityFrameworkCore;
using NjordFinance.Model;
using NjordFinance.Context.Configuration;

namespace NjordFinance.Context
{
    /// <summary>
    /// Extension methods for the <see cref="ModelBuilder"/> class. Members are typcially used 
    /// to populate default reference and/or test data.
    /// </summary>
    internal static class ModelBuilderExtension
    {
        /// <summary>
        /// Seeds this <see cref="ModelBuilder"/> with the default entries for reference data.
        /// </summary>
        /// <param name="modelBuilder"></param>
        public static ModelBuilder SeedDefaultReferenceData(this ModelBuilder modelBuilder)
        {
            DefaultReferenceDataModel defaultReferenceModel = new();

            modelBuilder
                .SeedEntityData(defaultReferenceModel.BrokerTransactionCodes)
                .SeedEntityData(defaultReferenceModel.ModelAttributes)
                .SeedEntityData(defaultReferenceModel.ModelAttributeScopes)
                .SeedEntityData(defaultReferenceModel.ModelAttributeMembers)
                .SeedEntityData(defaultReferenceModel.SecurityTypeGroups)
                .SeedEntityData(defaultReferenceModel.SecurityTypes)
                .SeedEntityData(defaultReferenceModel.SecuritySymbolTypes);

            return modelBuilder;
        }

        public static ModelBuilder SeedInitialData(
            this ModelBuilder modelBuilder, ISeedData seedData)
        {
            modelBuilder
                .SeedEntityData(seedData.AccountCustodians)
                .SeedEntityData(seedData.AccountObjects)
                .SeedEntityData(seedData.Accounts)
                .SeedEntityData(seedData.AccountComposites)
                .SeedEntityData(seedData.BankTransactionCodes)
                .SeedEntityData(seedData.BrokerTransactionCodes)
                .SeedEntityData(seedData.Countries)
                .SeedEntityData(seedData.InvestmentStrategies)
                .SeedEntityData(seedData.MarketHolidays)
                .SeedEntityData(seedData.MarketIndices)
                .SeedEntityData(seedData.ModelAttributes)
                .SeedEntityData(seedData.ModelAttributeMembers)
                .SeedEntityData(seedData.ReportConfigurations)
                .SeedEntityData(seedData.ReportStyleSheets)
                .SeedEntityData(seedData.ResourceImages)
                .SeedEntityData(seedData.SecurityExchanges)
                .SeedEntityData(seedData.SecurityTypeGroups)
                .SeedEntityData(seedData.SecurityTypes)
                .SeedEntityData(seedData.SecuritySymbolTypes)
                .SeedEntityData(seedData.Securities)
                .SeedEntityData(seedData.SecuritySymbols)
                .SeedEntityData(seedData.AccountWallets);

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
            if (data is null || data.Length == 0)
                return modelBuilder;

            modelBuilder.Entity<T>().HasData(data);

            return modelBuilder;
        }
    }
}
