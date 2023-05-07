using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using NjordFinance.EntityModel.Context.Configuration;

namespace NjordFinance.EntityModel.Context
{
    public partial class FinanceDbContext : DbContext
    {
        private readonly ISeedData _seedData;
        private readonly bool _configureForSqlServer;

        /// <summary>
        /// Initializes a new <see cref="FinanceDbContext"/> instance populated with the 
        /// given seed data.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="seedData"></param>
        internal FinanceDbContext(
            DbContextOptions<FinanceDbContext> options,
            ISeedData seedData)
            : base(options)
        {
            _seedData = seedData;
            ConfigureForSqlServer = Environment
                .GetEnvironmentVariable("DATABASE_PROVIDER") == "SQL_SERVER";
        }

        /// <summary>
        /// Returns true if this context is to be configured for SQL Server, else false.
        /// </summary>
        public bool ConfigureForSqlServer { get; }

        /// <summary>
        /// Handles additional configuration steps for the <see cref="FinanceDbContext"/> 
        /// model.
        /// </summary>
        /// <param name="modelBuilder"></param>
#pragma warning disable CA1822 // Mark members as static
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
#pragma warning restore CA1822 // Mark members as static
        {
            modelBuilder.SeedDefaultReferenceData();

            if(_seedData is not null)
                modelBuilder.SeedInitialData(_seedData);
        }
    }

    public static class FinanceDbContextExtension
    {
        /// <summary>
        /// Begins a database transaction if supported by the configured database provider.
        /// </summary>
        /// <param name="database"></param>
        /// <returns>An object instance implementing <see cref="IDbContextTransaction"/> if 
        /// supported by the provider, else null.</returns>
#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        public static async Task<IDbContextTransaction?> BeginTransactionIfSupportedAsync(
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
            this DatabaseFacade database)
        {
            if (database.IsSqlServer())
                return await database.BeginTransactionAsync();
            else
                return null;
        }
    }
} 
