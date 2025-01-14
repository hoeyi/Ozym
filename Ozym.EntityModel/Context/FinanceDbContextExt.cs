﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Ozym.EntityModel.Context.Configurations;

namespace Ozym.EntityModel.Context
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
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            // Get the base configuration collection.
            var configurationCollection = IConfigurationCollection.GetBuiltInDataConfiguration();

            // Apply additional configuration steps, if defined.
            ApplyConfigurationModifications(configurationCollection);

            if (!configurationCollection.IsValid(out IEnumerable<string> messages))
                throw new InvalidOperationException(string.Join("\n", messages));

            // Loop through configuration actions and apply them to the model builder.
            foreach(var configAction in configurationCollection)
            {
                configAction.Invoke(modelBuilder);
            }

            modelBuilder.MapUserDefinedFunctions();
        }

        /// <summary>
        /// Base method that performs no action. Defined to be overridden to specifiy additional 
        /// entity configurations to include in the build. This method is called before the build 
        /// actions are invoked in <see cref="OnModelCreatingPartial(ModelBuilder)"/>.
        /// </summary>
        /// <param name="targetCollection">The <see cref="IConfigurationCollection"/> to which 
        /// additional configuration steps are applied.</param>
        protected virtual void ApplyConfigurationModifications(IConfigurationCollection targetCollection)
        {
            targetCollection
                .WithSample_ModelAttributeGraph()
                .WithSample_CountryAttributeEntries()
                .WithSample_MarketIndexGraph()
                .WithSample_InvestmentStrategyGraph()
                .WithSample_SecurityGraph()
                .WithSample_ReportConfiguration()
                .WithSample_ReportStyleSheet()
                .WithSample_BankTransactionCodeGraph()
                .WithSample_AccountGraph()
                .WithSample_BankTransactionEntries()
                .WithSample_BrokerTransactionEntries()
                .WithSample_InvestmentPerformanceEntries();
        }

        /// <inheritdoc/>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase(IServiceCollectionExtEntityModel.app_db_name);
            }
        }

        /// <summary>
        /// Returns the net balance of the given bank account as of the given date.
        /// </summary>
        /// <param name="accountId">The account identifer.</param>
        /// <param name="date">The balance date.</param>
        /// <returns>A <see cref="float"/> giving the balance.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public double? BankBalance(int accountId, DateTime date) =>
            throw new NotImplementedException();
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

        public static void MapUserDefinedFunctions(this ModelBuilder modelBuilder)
        {
            modelBuilder.HasDbFunction(
                typeof(FinanceDbContext)
                .GetMethod(nameof(FinanceDbContext.BankBalance), [typeof(int), typeof(DateTime)]))
               .HasName("fBankAccountBalance")
               .HasSchema("FinanceApp");
        }
    }
} 
