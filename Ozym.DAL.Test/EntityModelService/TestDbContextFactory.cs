using Ozym.EntityModel.Context;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.Extensions.Logging;
using Ozym.EntityModel.Context.IntegrationTest;

namespace Ozym.Test.EntityModelService
{
    /// <summary>
    /// Implements <see cref="IDbContextFactory{TContext}"/> for testing model services.
    /// </summary>
    internal class TestDbContextFactory : IDbContextFactory<FinanceDbContext>
    {
        private static readonly object _lock = new();
        private static bool _databaseInitialized;
        private readonly static string _database_provider = TestUtility.Configuration["DATABASE_PROVIDER"];

        /// <summary>
        /// Initializes a new instance of the<see cref="TestDbContextFactory"/> class.
        /// </summary>
        public TestDbContextFactory()
        {
            lock (_lock)
            {
                if (!_databaseInitialized)
                {
                    using (var context = InitializeTestDbContext())
                    {
                        try
                        {
                            context.Database.EnsureDeleted();
                            context.Database.EnsureCreated();
                        }
                        catch(Exception e)
                        {
                            TestUtility.Logger.LogError(e, "Exception raised when re-creating database.");
                            throw;
                        }
                    }
                    _databaseInitialized = true;
                }
            }
        }

        /// <summary>
        /// Creates a new <see cref="FinanceDbIntegrationTestContext"/> instance for unit-testing.
        /// </summary>
        /// <inheritdoc/>
        public FinanceDbContext CreateDbContext() => 
            new FinanceDbIntegrationTestContext(options: GetDbContextOptions());

        private static FinanceDbContext InitializeTestDbContext() =>
            new FinanceDbIntegrationTestContext(options: GetDbContextOptions());

        /// <summary>
        /// Resets the test database to its state before seeding test data.
        /// </summary>
        public static void ResetTestDatabase()
        {
            lock(_lock)
            {
                using var context = GetFinanceDbContext();

                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                _databaseInitialized = true;
            }
        }

        private static FinanceDbContext GetFinanceDbContext() =>
            new FinanceDbIntegrationTestContext(options: GetDbContextOptions());

        private static DbContextOptions<FinanceDbContext> GetDbContextOptions()
        {
            return _database_provider switch
            {
                "SQL_SERVER" => (new DbContextOptionsBuilder<FinanceDbContext>()
                    .UseSqlServer(TestUtility.Configuration["ConnectionStrings:OzymWorksIntegrationTest"])
                    .EnableSensitiveDataLogging()).Options,

                _ => (new DbContextOptionsBuilder<FinanceDbContext>()
                    .UseInMemoryDatabase("OzymWorks")
                    .EnableSensitiveDataLogging()).Options
            };
        }
    }
}
