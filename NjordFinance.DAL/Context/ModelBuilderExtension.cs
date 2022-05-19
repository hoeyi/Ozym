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
        public static void SeedDefaultReferenceData(this ModelBuilder modelBuilder)
        {
            DefaultReferenceDataModel defaultReferenceModel = new();

            modelBuilder.Entity<ModelAttribute>()
                .HasData(defaultReferenceModel.ModelAttributes);

            modelBuilder.Entity<ModelAttributeScope>()
                .HasData(defaultReferenceModel.ModelAttributeScopes);

            modelBuilder.Entity<ModelAttributeMember>()
                .HasData(defaultReferenceModel.ModelAttributeMembers);

            modelBuilder.Entity<SecurityTypeGroup>()
                .HasData(defaultReferenceModel.SecurityTypeGroups);

            modelBuilder.Entity<SecurityType>()
                .HasData(defaultReferenceModel.SecurityTypes);

            modelBuilder.Entity<SecuritySymbolType>()
                .HasData(defaultReferenceModel.SecuritySymbolTypes);
        }

        /// <summary>
        /// Seeds this <see cref="ModelBuilder"/> with the test entries for accounts and 
        /// related models.
        /// </summary>
        /// <param name="modelBuilder"></param>
        public static void SeedTestAccountData(this ModelBuilder modelBuilder)
        {
            TestAccountDataModel testAccountDataModel = new();
            
            modelBuilder.Entity<AccountCustodian>()
                .HasData(testAccountDataModel.AccountCustodians);

            modelBuilder.Entity<AccountObject>()
                .HasData(testAccountDataModel.AccountObjects);

            modelBuilder.Entity<Account>()
                .HasData(testAccountDataModel.Accounts);
        }

        /// <summary>
        /// Seeds this <see cref="ModelBuilder"/> with the test entries for reference data.
        /// </summary>
        /// <param name="modelBuilder"></param>
        public static void SeedTestReferenceData(this ModelBuilder modelBuilder)
        {
            TestReferenceDataModel testReferenceDataModel = new();

            modelBuilder.Entity<Country>().HasData(testReferenceDataModel.Countries);
        }

        /// <summary>
        /// Seeds this <see cref="ModelBuilder"/> with the test entries for securities and 
        /// related models.
        /// </summary>
        /// <param name="modelBuilder"></param>
        public static void SeedTestSecurityData(this ModelBuilder modelBuilder)
        {
            TestSecurityDataModel testSecurityDataModel = new();

            modelBuilder.Entity<SecurityExchange>()
                .HasData(testSecurityDataModel.SecurityExchanges);

            modelBuilder.Entity<Security>().HasData(testSecurityDataModel.Securities);

            modelBuilder.Entity<SecuritySymbol>().HasData(testSecurityDataModel.SecuritySymbols);
        }
    }
}
