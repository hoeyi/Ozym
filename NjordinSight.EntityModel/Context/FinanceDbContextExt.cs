using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using NjordinSight.EntityModel.Context.TestConfiguration;
using NjordinSight.EntityModel.Context.DefaultConfiguration;
using System.Diagnostics;

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
        /// model.
        /// </summary>
        /// <param name="modelBuilder"></param>
#pragma warning disable CA1822 // Mark members as static
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
#pragma warning restore CA1822 // Mark members as static
        {
            modelBuilder.ConfigureInitialRecords();
        }

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
        /// Configures the initial records of the database, populating the following types of 
        /// reference data:
        /// <list type="bullet">
        /// <item><see cref="BrokerTransactionCode"/></item>
        /// <item><see cref="BrokerTransactionCodeAttributeMemberEntry"/></item>
        /// <item><see cref="Country"/></item>
        /// <item><see cref="MarketHoliday"/></item>
        /// <item><see cref="MarketHolidayObservance"/></item>
        /// <item><see cref="ModelAttribute"/></item>
        /// <item><see cref="ModelAttributeMember"/></item>
        /// <item><see cref="ModelAttributeScope"/></item>
        /// <item><see cref="SecurityTypeGroup"/></item>
        /// <item><see cref="SecurityType"/></item>
        /// </list>
        /// </summary>
        /// <param name="modelBuilder"></param>
        internal static void ConfigureInitialRecords(this ModelBuilder modelBuilder)
        {
            IDefaultConfiguration defaultConfig = new DefaultConfiguration.DefaultConfiguration();
            modelBuilder
                .HasInitialRecords(defaultConfig.BrokerTransactionCodes)
                .HasInitialRecords(defaultConfig.BrokerTransactionCodeAttributes)
                .HasInitialRecords(defaultConfig.Countries)
                .HasInitialRecords(defaultConfig.MarketHolidays)
                .HasInitialRecords(defaultConfig.MarketHolidayObservances)
                .HasInitialRecords(defaultConfig.ModelAttributes)
                .HasInitialRecords(defaultConfig.ModelAttributeScopes)
                .HasInitialRecords(defaultConfig.ModelAttributeMembers)
                .HasInitialRecords(defaultConfig.Securities)
                .HasInitialRecords(defaultConfig.SecurityTypeGroups)
                .HasInitialRecords(defaultConfig.SecurityTypes)
                .HasInitialRecords(defaultConfig.SecuritySymbolTypes);
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
