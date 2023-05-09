using Microsoft.EntityFrameworkCore;
using NjordinSight.Web.Data;

namespace NjordinSight.Web.Test.Identity
{
    /// <summary>
    /// Implements <see cref="IDbContextFactory{TContext}"/> for testing model services.
    /// </summary>
    internal sealed class TestDbContextFactory : IDbContextFactory<IdentityDbContext>
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
        /// Creates a new <see cref="IdentityDbContext"/> instance for unit-testing.
        /// </summary>
        /// <inheritdoc/>
        public IdentityDbContext CreateDbContext() => new(
            options: ContextOptionsBuilder().Options);

        private static IdentityDbContext InitializeTestDbContext() => new(
            options: ContextOptionsBuilder().Options);
            //seedData: new ModelServiceTestDataModel());

        /// <summary>
        /// Resets the test database to its state before seeding test data.
        /// </summary>
        public static void ResetTestDatabase()
        {
            lock(_lock)
            {
                using var context = new IdentityDbContext(ContextOptionsBuilder().Options);

                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                _databaseInitialized = true;
            }
        }

        private static DbContextOptionsBuilder<IdentityDbContext> ContextOptionsBuilder() =>
            new DbContextOptionsBuilder<IdentityDbContext>()
                .UseSqlServer(connectionString: TestUtility.Configuration["ConnectionStrings:NjordIdentity"] ?? string.Empty)
                .EnableSensitiveDataLogging();
    }
}
