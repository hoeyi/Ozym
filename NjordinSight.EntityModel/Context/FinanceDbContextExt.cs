using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using NjordinSight.EntityModel.Context.DefaultConfiguration;
using NjordinSight.EntityModel.Context.Configurations;

namespace NjordinSight.EntityModel.Context
{
    /// <summary>
    /// <see cref="DbContext"/>-derived class for the 'FinanceApp' schema in the data store.
    /// </summary>
    public partial class FinanceDbContext : DbContext
    {
        
        /// <summary>
        /// Returns true if this context is to be configured for SQL Server, else false.
        /// </summary>
        protected bool UseRelationalDatabase => 
            Database?.ProviderName == "Microsoft.EntityFrameworkCore.SqlServer";

        /// <summary>
        /// Handles additional configuration steps for the <see cref="FinanceDbContext"/> 
        /// model. Called at the end of the <see cref="OnModelCreating(ModelBuilder)"/> method.
        /// </summary>
        /// <param name="modelBuilder"></param>
#pragma warning disable CA1822 // Mark members as static
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
#pragma warning restore CA1822 // Mark members as static
        {
            IConfigurationCollection defaultConfig = IConfigurationCollection.GetBuiltInEntities();

            foreach (var action in defaultConfig)
            {
                action.Invoke(modelBuilder);
            }
        }

        /// <inheritdoc/>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase("NjordWorks");
            }
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

        /// <summary>
        /// Adds seed data for entity type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The entity type.</typeparam>
        /// <param name="modelBuilder"></param>
        /// <param name="records">The <typeparamref name="T"/> records to insert.</param>
        /// <returns>This <see cref="ModelBuilder"/> instance so that calls may be chained.</returns>
        internal static ModelBuilder HasInitialRecords<T>(
            this ModelBuilder modelBuilder, params T[] records)
            where T : class, new()
        {
            var nonNulLRecords = records?.Where(x => x is not null);

            if(nonNulLRecords?.Any() ?? false)
                modelBuilder.Entity<T>().HasData(nonNulLRecords);

            return modelBuilder;
        }
    }
} 
