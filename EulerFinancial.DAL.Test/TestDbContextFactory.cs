using System.Linq;
using EulerFinancial.Context;
using Microsoft.EntityFrameworkCore;
using EulerFinancial.Model;
using EulerFinancial.ModelMetadata;

namespace EulerFinancial.UnitTest.ModelService
{
    /// <summary>
    /// Implements <see cref="IDbContextFactory{TContext}"/> for testing model services.
    /// </summary>
    internal class TestDbContextFactory : IDbContextFactory<EulerDbContext>
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
                        context.Database.EnsureDeleted();
                        context.Database.EnsureCreated();
                    }

                    _databaseInitialized = true;
                }
            }
        }

        /// <summary>
        /// Creates a new <see cref="EulerDbContext"/> instance for unit-testing.
        /// </summary>
        /// <inheritdoc/>
        public EulerDbContext CreateDbContext() => new EulerDbContext(
                new DbContextOptionsBuilder<EulerDbContext>()
                    .UseSqlServer(UnitTest.Configuration["Connectionstrings:EulerFinancial-DEV"])
                    .Options)
                .WithSeedData();

        /// <summary>
        /// Creates a new <see cref="EulerDbContext"/> instance for unit-testing.
        /// </summary>
        /// <returns>A new instance.</returns>
#pragma warning disable CA1822 // Mark members as static
        public EulerDbContext CreateDbContextNoSeed() => new(
                new DbContextOptionsBuilder<EulerDbContext>()
                    .UseSqlServer(UnitTest.Configuration["Connectionstrings:EulerFinancial-DEV"])
                    .Options);

#pragma warning restore CA1822 // Mark members as static
    }

    /// <summary>
    /// Extension class for initial data seed of a test <see cref="EulerDbContext"/>.
    /// </summary>
    internal static class ContextExtensions
    {
        internal static EulerDbContext WithSeedData(this EulerDbContext context)
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
        /// <returns>The <see cref="EulerDbContext"/> instance, updated but not saved.</returns>
        internal static EulerDbContext SeedSingleAccount(this EulerDbContext context)
        {
            if(!context.Accounts.Any(a => a.AccountNavigation.AccountObjectCode == "TEST000_SEED"))
            {
                context.Accounts.Add(new()
                {
                    AccountNavigation = new()
                    {
                        AccountObjectCode = "TEST000_SEED",
                        ObjectType = AccountObjectType.Account.ConvertToStringCode(),
                        ObjectDisplayName = "TEST ACCOUNT #000",
                        ObjectDescription = "Account used for testing purposes."
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
        /// <returns>The <see cref="EulerDbContext"/> instance, updated but not saved.</returns>
        internal static EulerDbContext SeedSingleAccountCustodian(
            this EulerDbContext context)
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
