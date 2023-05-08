using NjordinSight.EntityModel.Context;
using Microsoft.EntityFrameworkCore;
using NjordinSight.Test.EntityModelService.Configuration;
using System;

namespace NjordinSight.Test.EntityModelService
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
        public FinanceDbContext CreateDbContext() => new(options: ContextOptionsBuilder().Options);

        private static FinanceDbContext InitializeTestDbContext() => new(
            options: ContextOptionsBuilder().Options,
            seedData: new ModelServiceTestDataModel());

        /// <summary>
        /// Resets the test database to its state before seeding test data.
        /// </summary>
        public static void ResetTestDatabase()
        {
            lock(_lock)
            {
                using var context = new FinanceDbContext(options: ContextOptionsBuilder().Options);

                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                _databaseInitialized = true;
            }
        }

        private static DbContextOptionsBuilder<FinanceDbContext> ContextOptionsBuilder()
        {
            if(Environment.GetEnvironmentVariable("DATABASE_PROVIDER") == "SQL_SERVER")
                return new DbContextOptionsBuilder<FinanceDbContext>()
                    .UseSqlServer(TestUtility.Configuration["ConnectionStrings:NjordWorks"])
                    .EnableSensitiveDataLogging();
            else
                return new DbContextOptionsBuilder<FinanceDbContext>()
                    .UseInMemoryDatabase("NjordWorks")
                    .EnableSensitiveDataLogging();
        }
    }
}
