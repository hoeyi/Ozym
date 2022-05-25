using NjordFinance.Context;
using Microsoft.EntityFrameworkCore;
using NjordFinance.Test.Configuration;

namespace NjordFinance.Test.ModelService
{
    /// <summary>
    /// Implements <see cref="IDbContextFactory{TContext}"/> for testing model services.
    /// </summary>
    internal sealed class TestDbContextFactory : IDbContextFactory<FinanceDbContext>
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
        public FinanceDbContext CreateDbContext() => new(
                new DbContextOptionsBuilder<FinanceDbContext>()
                    .UseSqlServer(TestUtility.Configuration["ConnectionStrings:NjordFinance"])
                    .EnableSensitiveDataLogging()
                    .Options);

        private static FinanceDbContext InitializeTestDbContext() => new(
            options: new DbContextOptionsBuilder<FinanceDbContext>()
                    .UseSqlServer(TestUtility.Configuration["ConnectionStrings:NjordFinance"])
                    .EnableSensitiveDataLogging()
                    .Options,
            seedData: new ModelServiceTestDataModel());

        /// <summary>
        /// Resets the test database to its initial state.
        /// </summary>
        public static void ResetTestDatabase()
        {
            lock(_lock)
            {
                using var context = InitializeTestDbContext();

                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                _databaseInitialized = true;
            }
        }
    }
}
