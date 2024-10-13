using Ozym.EntityModel.Context;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.Extensions.Logging;
using Ozym.EntityModel.Context.IntegrationTest;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Infrastructure;

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
                    using (var context = new FinanceDbContext(options: GetDbContextOptions()))
                    {
                        context.Database.EnsureDeleted();
                        try
                        {
                            context.Database.Migrate();
                        }
                        catch (Exception e)
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

        /// <summary>
        /// Resets the test database to its state before seeding test data.
        /// </summary>
        public static void ResetTestDatabase()
        {
            lock(_lock)
            {
                using (var context = new FinanceDbContext(options: GetDbContextOptions()))
                {
                    context.Database.EnsureDeleted();
                    try
                    {
                        context.Database.Migrate();
                    }
                    catch (Exception e)
                    {
                        TestUtility.Logger.LogError(e, "Exception raised when re-creating database.");
                        throw;
                    }
                }
                _databaseInitialized = true;
            }
        }

        private static DbContextOptions<FinanceDbContext> GetDbContextOptions()
        {
            return _database_provider switch
            {
                "SQL_SERVER" => new DbContextOptionsBuilder<FinanceDbContext>()
                    .UseSqlServer(
                        connectionString: TestUtility.Configuration["ConnectionStrings:OzymWorksIntegrationTest"],
                        sqlServerOptionsAction: x => x.MigrationsAssembly("Ozym.EntityMigration"))
                    .EnableSensitiveDataLogging().Options,

                _ => new DbContextOptionsBuilder<FinanceDbContext>()
                    .UseInMemoryDatabase("OzymWorks")
                    .EnableSensitiveDataLogging().Options
            };
        }
    }
}
