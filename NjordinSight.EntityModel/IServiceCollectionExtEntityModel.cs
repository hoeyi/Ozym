﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using NjordinSight.EntityModel.Context;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

[assembly: InternalsVisibleTo("NjordinSight.DAL.Test")]

namespace NjordinSight.EntityModel
{
    public static class IServiceCollectionExtEntityModel
    {
        /// <summary>
        /// Database or database store name for the core application entity model.
        /// </summary>
        internal const string app_db_name = "NjordWorks";

        public static IServiceCollection AddDbContextFactoryServices(
            this IServiceCollection services, DatabaseProvider dbProvider, bool developerMode = false)
        {
            services.AddDbContextFactory<FinanceDbContext>(options =>
            {
                switch (dbProvider)
                {
                    case DatabaseProvider.InMemory:
                        if (developerMode)
                        {
                            options.UseInMemoryDatabase(app_db_name);
                            SeedInMemoryDatabase();
                        }
                        else
                        {
                            throw new InvalidOperationException();
                        }
                        break;
                    case DatabaseProvider.SqlServer:
                        options.UseSqlServer(
                            connectionString: $"Name=ConnectionStrings:{app_db_name}",
                            sqlServerOptionsAction: x => x.MigrationsAssembly("NjordinSight.EntityMigration"));
                        break;
                    default:
                        throw new NotSupportedException(
                            message: $"{nameof(DatabaseProvider)}: {dbProvider}");
                }
            });
            
            return services;
        }

        /// <summary>
        /// Recreates the 'NjordWorks' database in memory. Call only once during start-up to seed 
        /// data for an in-memory data store. Not for production use.
        /// </summary>
        private static void SeedInMemoryDatabase()
        {
            var optionsBuild = new DbContextOptionsBuilder<FinanceDbContext>();
            optionsBuild.UseInMemoryDatabase(app_db_name);

            using var context = new FinanceDbContext(optionsBuild.Options);

            context.Database.EnsureCreated();
        }
    }

    /// <summary>
    /// Enumerate the supported database providers.
    /// </summary>
    public enum DatabaseProvider
    {
        /// <summary>
        /// Represents an in-memory DB provider. Not for use in production.
        /// </summary>
        [EnumMember(Value = "")]
        InMemory = 0,

        /// <summary>
        /// Represents a SQL Server relational database.
        /// </summary>
        [EnumMember(Value = "SQL_SERVER")]
        SqlServer = 1
    }
}
