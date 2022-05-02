using System.Linq;
using NjordFinance.Context;
using Microsoft.EntityFrameworkCore;
using NjordFinance.Model;
using NjordFinance.ModelMetadata;
using System;

namespace NjordFinance.UnitTest.ModelService
{
    /// <summary>
    /// Implements <see cref="IDbContextFactory{TContext}"/> for testing model services.
    /// </summary>
    internal class TestDbContextFactory : IDbContextFactory<FinanceDbContext>
    {
        private static readonly object _lock = new();
        private static bool _databaseInitialized;

        /// <summary>
        /// Initializes a new instance of the<see cref="TestDbContextFactory"/> class.
        /// </summary>
        public TestDbContextFactory()
        {
            lock (_lock)
            {
                if (!_databaseInitialized)
                {
                    using (var context = CreateDbContext())
                    {
                        //context.Database.EnsureDeleted();
                        context.Database.EnsureCreated();
                    }

                    _databaseInitialized = true;
                }
            }
        }

        /// <summary>
        /// Creates a new <see cref="FinanceDbContext"/> instance for unit-testing.
        /// </summary>
        /// <inheritdoc/>
        public FinanceDbContext CreateDbContext() => new(
                new DbContextOptionsBuilder<FinanceDbContext>()
                    .UseSqlServer(UnitTest.Configuration["Connectionstrings:NjordFinance"])
                    .Options);
    }

    /// <summary>
    /// Extension class for initial data seed of a test <see cref="FinanceDbContext"/>.
    /// </summary>
    internal static class ContextExtensions
    {
        /// <summary>
        /// Refreshes the context by deleting test data and then disposing of itself.
        /// </summary>
        internal static void RefreshDbContext(this TestDbContextFactory factory)
        {
            using var tmpContext = factory.CreateDbContext().WithSeedData();

            tmpContext?.Dispose();
        }

        internal static FinanceDbContext WithSeedData(this FinanceDbContext context)
        {
            context
                .SeedSingleAccount()
                .SeedSingleAccountCustodian();

            context.SaveChanges();

            return context;
        }

        /// <summary>
        /// Adds the test <see cref="Account"/> instance, if it is does not exist.
        /// </summary>
        /// <param name="context"></param>
        /// <returns>The <see cref="FinanceDbContext"/> instance, updated but not saved.</returns>
        internal static FinanceDbContext SeedSingleAccount(this FinanceDbContext context)
        {
            var testAccounts = context.Accounts.Where(a => a.AccountId > 0);
            var testAccountObjects = context.AccountObjects.Where(a => a.AccountObjectId > 0);

            context.Accounts.RemoveRange(testAccounts);
            context.SaveChanges();

            context.AccountObjects.RemoveRange(testAccountObjects);
            context.SaveChanges();

            Random random = new();

            if(!context.Accounts.Any(a => a.AccountNavigation.AccountObjectCode == "TESTSEED"))
            {
                context.Accounts.Add(new()
                {
                    AccountNavigation = new()
                    {
                        AccountObjectCode = "TESTSEED",
                        ObjectType = AccountObjectType.Account.ConvertToStringCode(),
                        ObjectDisplayName = "TEST ACCOUNT #000",
                        ObjectDescription = "Account used for testing purposes.",
                        StartDate = new DateTime(
                            random.Next(1975, 2022), random.Next(1,12), random.Next(1,28))
                    },
                    AccountNumber = "0000-0000-00"
                });

            }

            return context;
        }

        /// <summary>
        /// Adds the test <see cref="AccountCustodian"/> instance, if it is does not exist.
        /// </summary>
        /// <param name="context"></param>
        /// <returns>The <see cref="FinanceDbContext"/> instance, updated but not saved.</returns>
        internal static FinanceDbContext SeedSingleAccountCustodian(
            this FinanceDbContext context)
        {
            if(!context.AccountCustodians.Any(a => a.CustodianCode == "SCHWAB"))
            {
                context.AccountCustodians.Add(new()
                {
                    CustodianCode = "SCHWAB",
                    DisplayName = "Charles Schwab"
                });
            }

            return context;
        }
    }
}
