using Microsoft.EntityFrameworkCore;
using NjordinSight.EntityModel.Context.Configurations;

namespace NjordinSight.EntityModel.Context
{
    /// <summary>
    /// Derived from <see cref="FinanceDbContext"/> and initializes in the same way, but includes
    /// additional seed data for running integration tests.
    /// </summary>
    public partial class FinanceDbIntegrationTestContext : FinanceDbContext
    {
        private readonly IDbContextInitialRecordCollection _seedData;

        /// <summary>
        /// Initializes a new <see cref="FinanceDbIntegrationTestContext"/> instance populated with the 
        /// given seed data.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="seedData"></param>
        internal FinanceDbIntegrationTestContext(
            DbContextOptions<FinanceDbContext> options,
            IDbContextInitialRecordCollection seedData)
            : base(options)
        {
            _seedData = seedData;
        }

        public FinanceDbIntegrationTestContext()
        {
        }

        public FinanceDbIntegrationTestContext(DbContextOptions<FinanceDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Handles additional configuration steps for the <see cref="FinanceDbContext"/> 
        /// model.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            if (_seedData is not null) 
            {
                modelBuilder
                    // Seed reference tables first.
                    .HasInitialRecords(_seedData.AccountCustodians)
                    .HasInitialRecords(_seedData.BankTransactionCodes)
                    .HasInitialRecords(_seedData.BrokerTransactionCodes)
                    .HasInitialRecords(_seedData.Countries)
                    .HasInitialRecords(_seedData.InvestmentStrategies)
                    .HasInitialRecords(_seedData.MarketHolidays)
                    .HasInitialRecords(_seedData.MarketHolidayObservances)
                    .HasInitialRecords(_seedData.ModelAttributes)
                    .HasInitialRecords(_seedData.ModelAttributeScopes)
                    .HasInitialRecords(_seedData.ModelAttributeMembers)
                    .HasInitialRecords(_seedData.ReportConfigurations)
                    .HasInitialRecords(_seedData.ReportStyleSheets)
                    .HasInitialRecords(_seedData.ResourceImages)
                    .HasInitialRecords(_seedData.SecurityExchanges)
                    .HasInitialRecords(_seedData.SecurityTypeGroups)
                    .HasInitialRecords(_seedData.SecurityTypes)
                    .HasInitialRecords(_seedData.SecuritySymbolTypes)
                    .HasInitialRecords(_seedData.MarketIndices)

                    // Seed parent objects and other objects that are referenced by foreign keys.
                    .HasInitialRecords(_seedData.AccountObjects)
                    .HasInitialRecords(_seedData.Accounts)
                    .HasInitialRecords(_seedData.AccountWallets)
                    .HasInitialRecords(_seedData.AccountComposites)
                    .HasInitialRecords(_seedData.AccountCompositeMembers)
                    .HasInitialRecords(_seedData.Securities)
                    .HasInitialRecords(_seedData.SecuritySymbols)

                    // Seed non-attribute-specific transactional data.
                    .HasInitialRecords(_seedData.BankTransactions)
                    .HasInitialRecords(_seedData.BrokerTransactions)
                    .HasInitialRecords(_seedData.InvestmentPerformanceEntries)
                    .HasInitialRecords(_seedData.MarketIndexPrices)
                    .HasInitialRecords(_seedData.SecurityPrices)
                    // Seed attributes for applicable objects.

                    .HasInitialRecords(_seedData.AccountAttributes)
                    .HasInitialRecords(_seedData.BankTransactionCodeAttributes)
                    .HasInitialRecords(_seedData.BrokerTransactionCodeAttributes)
                    .HasInitialRecords(_seedData.CountryAttributes)
                    .HasInitialRecords(_seedData.SecurityAttributes)

                    // Seed attribute-specific transactional data.
                    .HasInitialRecords(_seedData.InvestmentStrategyTargets)
                    .HasInitialRecords(_seedData.InvestmentPerformanceAttributeEntries);
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase("NjordWorks");
            }
        }

    }
}
