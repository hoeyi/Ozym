using NjordinSight.EntityModel.Context;
using Microsoft.EntityFrameworkCore;
using NjordinSight.Test.EntityModelService.Configuration;
using System;
using Microsoft.IdentityModel.Tokens;

namespace NjordinSight.Test.EntityModelService
{
    /// <summary>
    /// Implements <see cref="IDbContextFactory{TContext}"/> for testing model services.
    /// </summary>
    internal sealed class TestDbContextFactory : IDbContextFactory<FinanceDbContext>
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
                        context.Database.EnsureDeleted();
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
        public FinanceDbContext CreateDbContext() => new(options: GetDbContextOptions());

        private static FinanceDbContext InitializeTestDbContext() => new(
            options: GetDbContextOptions(),
            seedData: new ModelServiceTestDataModel());

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

        private static FinanceDbContext GetFinanceDbContext()
        {
            return _database_provider switch
            {
                "SQL_SERVER" => new FinanceDbContext(options: GetDbContextOptions()),

                _ => new FinanceDbContext(options: GetDbContextOptions())
            };
        }

        private static DbContextOptions<FinanceDbContext> GetDbContextOptions()
        {
            return _database_provider switch
            {
                "SQL_SERVER" => (new DbContextOptionsBuilder<FinanceDbContext>()
                    .UseSqlServer(TestUtility.Configuration["ConnectionStrings:NjordWorks"])
                    .EnableSensitiveDataLogging()).Options,

                _ => (new DbContextOptionsBuilder<FinanceDbContext>()
                        .UseInMemoryDatabase("NjordWorks")
                        .EnableSensitiveDataLogging()).Options
            };
        }
    }
}
