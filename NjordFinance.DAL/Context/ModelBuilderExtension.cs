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

            modelBuilder.SeedEntityData(defaultReferenceModel.ModelAttributes);

            modelBuilder.SeedEntityData(defaultReferenceModel.ModelAttributeScopes);

            modelBuilder.SeedEntityData(defaultReferenceModel.ModelAttributeMembers);

            modelBuilder.SeedEntityData(defaultReferenceModel.SecurityTypeGroups);

            modelBuilder.SeedEntityData(defaultReferenceModel.SecurityTypes);

            modelBuilder.SeedEntityData(defaultReferenceModel.SecuritySymbolTypes);

            return modelBuilder;
        }

        public static ModelBuilder SeedInitialData(
            this ModelBuilder modelBuilder, ISeedData seedData)
        {
            modelBuilder.SeedEntityData(seedData.AccountCustodians);

            modelBuilder.SeedEntityData(seedData.AccountObjects);

            modelBuilder.SeedEntityData(seedData.Accounts);

            modelBuilder.SeedEntityData(seedData.BankTransactionCodes);

            modelBuilder.SeedEntityData(seedData.Countries);

            modelBuilder.SeedEntityData(seedData.Securities);

            modelBuilder.SeedEntityData(seedData.SecurityExchanges);

            modelBuilder.SeedEntityData(seedData.SecuritySymbols);

            return modelBuilder;
        }
        /// <summary>
        /// Seeds this <see cref="ModelBuilder"/> with the given <typeparamref name="T"/> entries.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="modelBuilder"></param>
        /// <param name="data">The collection of <typeparamref name="T"/> models to 
        /// insert.</param>
        public static void SeedEntityData<T>(
            this ModelBuilder modelBuilder,
            params T[] data)
            where T : class, new()
        {
            modelBuilder.Entity<T>().HasData(data);
        }
    }
}
