using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ozym.EntityModel
{
    /// <summary>
    /// Provides extension methods for database migrations.
    /// </summary>
    public static class MigrationExtensions
    {
        /// <summary>
        /// Adds user-defined functions to the migration.
        /// </summary>
        /// <param name="builder">The migration builder.</param>
        public static void AddUserDefinedFunctions(this MigrationBuilder builder)
        {
            builder.Sql(sql: GetRoutineSql("fAccountAttributes.sql"));
            builder.Sql(sql: GetRoutineSql("fBankAccountBalance.sql"));
            builder.Sql(sql: GetRoutineSql("fBankTransactionAttributes.sql"));
            builder.Sql(sql: GetRoutineSql("pReportBankTransactions.sql"));
        }

        /// <summary>
        /// Drops user-defined functions from the migration.
        /// </summary>
        /// <param name="builder">The migration builder.</param>
        public static void DropUserDefinedFunctions(this MigrationBuilder builder)
        {
            builder.Sql(@"DROP FUNCTION IF EXISTS [FinanceApp].[fAccountAttributes];");
            builder.Sql(@"DROP FUNCTION IF EXISTS [FinanceApp].[fBankAccountBalance];");
            builder.Sql(@"DROP FUNCTION IF EXISTS [FinanceApp].[fBankTransationAttributes];");
            builder.Sql(@"DROP PROCEDURE IF EXISTS [FinanceApp].[pReportBankTransactions];");
        }

        private static string GetRoutineSql(string resourceName)
        {
            var assembly = typeof(MigrationExtensions).Assembly;
            using var stream = 
                assembly.GetManifestResourceStream($"Ozym.EntityModel.Routines.{resourceName}") ?? 
                throw new ArgumentException($"Resource '{resourceName}' not found.");

            using var reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }
    }
}
