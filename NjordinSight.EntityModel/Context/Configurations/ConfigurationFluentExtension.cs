using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using NjordinSight.EntityModel.ConstraintType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NjordinSight.EntityModel.Context.Configurations
{
    /// <summary>
    ///  Extension method container for method-chaining a <see cref="IConfigurationCollection"/> 
    ///  to seed data and/or configuration migrations.
    /// </summary>
    public static partial class ConfigurationFluentExtension
    {
        /// <summary>
        /// Adds a new <see cref="Action"/> accepting <see cref="ModelBuilder"/> input that applies 
        /// the given <see cref="IEntityConfiguration{TEntity}"/>. The action is invoked by the caller, 
        /// typically be iterating over the <see cref="IConfigurationCollection"/> instance.
        /// </summary>
        /// <<returns>The <see cref="IConfigurationCollection"/> instance for chaining method calls.</returns>
        /// <typeparam name="T"></typeparam>
        /// <param name="configuration"></param>
        /// <exception cref="ArgumentNullException"><paramref name="configuration"/> was null.</exception>
        public static IConfigurationCollection WithConfiguration<T>(
            this IConfigurationCollection collection,
            IEntityConfiguration<T> configuration)
            where T : class
        {
            if (collection is null)
                throw new ArgumentNullException(paramName: nameof(collection));

            collection.AddConfiguration(configuration);

            return collection;
        }

    }

    #region SAMPLE DATA METHODS
    public static partial class ConfigurationFluentExtension
    {
        /// <summary>
        /// Helper method for creating new <see cref="IEntityConfiguration{TEntity}"/> instances.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sourceGuid"></param>
        /// <param name="entries"></param>
        /// <returns><see cref="IEntityConfiguration{TEntity}"/>.</returns>
        private static IEntityConfiguration<T> NewConfiguration<T>(
            string sourceGuid, params T[] entries) where T : class
            => new EntityConfiguration<T>(Guid.Parse(sourceGuid), entries);
        
        /// <summary>
        /// Seeds this <see cref="IConfigurationCollection"/> with sample data for:
        /// <list type="bullet">
        /// <item><see cref="ModelAttribute"/></item>
        /// </list>
        /// </summary>
        /// <param name="configurationcollection"></param>
        /// <returns>The </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IConfigurationCollection WithSample_ModelAttributeGraph(
            this IConfigurationCollection configurationcollection)
        {
            const string sourceGuid = "{B86AD8A7-9A34-40C6-A96C-1A2A577D95D8}";

            var modelAttributes = new ModelAttribute[]
            {
                new()
                {
                    AttributeId = (int)ModelAttributeEnum.AccountType,
                    DisplayName = Strings.ModelAttribute_AccountType
                },
                new()
                {
                    AttributeId = (int)ModelAttributeEnum.BankTransactionGroup,
                    DisplayName = Strings.ModelAttribute_BankTransactionGroup
                },
                new()
                {
                    AttributeId = (int)ModelAttributeEnum.BankTransactionType,
                    DisplayName = Strings.ModelAttribute_BankTransactionType
                }
            };

            var modelAttributescopes = new ModelAttributeScope[]
            {
                new()
                {
                    AttributeId = (int)ModelAttributeEnum.AccountType,
                    ScopeCode = ModelAttributeScopeCode.Account.ConvertToStringCode()
                },
                new()
                {
                    AttributeId = (int)ModelAttributeEnum.BankTransactionGroup,
                    ScopeCode = ModelAttributeScopeCode.BankTransactionCode.ConvertToStringCode()
                },
                new()
                {
                    AttributeId = (int)ModelAttributeEnum.BankTransactionType,
                    ScopeCode = ModelAttributeScopeCode.BankTransactionCode.ConvertToStringCode()
                }
            };

            int accountTypeAttributeId = (int)ModelAttributeEnum.AccountType;
            int bankTransactionTypeAttributeId = (int)ModelAttributeEnum.BankTransactionType;
            int bankTransctionGroupAttributeId = (int)ModelAttributeEnum.BankTransactionGroup;

            var modelAttributeMembers = new ModelAttributeMember[]
            {
                // ACCOUNT TYPE
                new() { AttributeMemberId = -901, AttributeId = accountTypeAttributeId, DisplayName = "Student Loan", DisplayOrder = 0 },
                new() { AttributeMemberId = -902, AttributeId = accountTypeAttributeId, DisplayName = "401(k)", DisplayOrder = 1 },
                new() { AttributeMemberId = -903, AttributeId = accountTypeAttributeId, DisplayName = "Rollover IRA", DisplayOrder = 2 },
                new() { AttributeMemberId = -904, AttributeId = accountTypeAttributeId, DisplayName = "Contributory IRA", DisplayOrder = 3 },
                new() { AttributeMemberId = -905, AttributeId = accountTypeAttributeId, DisplayName = "Brokerage", DisplayOrder = 4 },
                new() { AttributeMemberId = -906, AttributeId = accountTypeAttributeId, DisplayName = "Stock Purchase Plan", DisplayOrder = 5 },
                new() { AttributeMemberId = -907, AttributeId = accountTypeAttributeId, DisplayName = "Checking", DisplayOrder = 6 },
                new() { AttributeMemberId = -908, AttributeId = accountTypeAttributeId, DisplayName = "Savings", DisplayOrder = 7 },
                new() { AttributeMemberId = -909, AttributeId = accountTypeAttributeId, DisplayName = "Credit", DisplayOrder = 8 },
                new() { AttributeMemberId = -910, AttributeId = accountTypeAttributeId, DisplayName = "Health-Savings", DisplayOrder = 9 },
                new() { AttributeMemberId = -911, AttributeId = accountTypeAttributeId, DisplayName = "Roth Contributory IRA", DisplayOrder = 10 },

                // BANK TRANSACTION TYPE
                new() { AttributeMemberId = -920, AttributeId = bankTransactionTypeAttributeId, DisplayName = "Transportation", DisplayOrder = 0 },
                new() { AttributeMemberId = -921, AttributeId = bankTransactionTypeAttributeId, DisplayName = "Utilities", DisplayOrder = 1 },
                new() { AttributeMemberId = -922, AttributeId = bankTransactionTypeAttributeId, DisplayName = "Entertainment", DisplayOrder = 2 },
                new() { AttributeMemberId = -923, AttributeId = bankTransactionTypeAttributeId, DisplayName = "Medical", DisplayOrder = 3 },
                new() { AttributeMemberId = -924, AttributeId = bankTransactionTypeAttributeId, DisplayName = "Housing", DisplayOrder = 4 },
                new() { AttributeMemberId = -925, AttributeId = bankTransactionTypeAttributeId, DisplayName = "Restaurants/Dining", DisplayOrder = 5 },
                new() { AttributeMemberId = -926, AttributeId = bankTransactionTypeAttributeId, DisplayName = "Employment", DisplayOrder = 6 },

                // BANK TRANSACTION GROUP
                new() { AttributeMemberId = -931, AttributeId = bankTransctionGroupAttributeId, DisplayName = "Necessary expense", DisplayOrder = 0 },
                new() { AttributeMemberId = -932, AttributeId = bankTransctionGroupAttributeId, DisplayName = "Discretionary expense", DisplayOrder = 1 },
                new() { AttributeMemberId = -933, AttributeId = bankTransctionGroupAttributeId, DisplayName = "Income", DisplayOrder = 2 }
            };

            configurationcollection
                .WithConfiguration(NewConfiguration(sourceGuid, modelAttributes))
                .WithConfiguration(NewConfiguration(sourceGuid, modelAttributescopes))
                .WithConfiguration(NewConfiguration(sourceGuid, modelAttributeMembers));

            return configurationcollection;
        }

        public static IConfigurationCollection WithSample_AccountGraph(
            this IConfigurationCollection configurationCollection)
        {

            var bankTransactionCodes = new BankTransactionCode[]
            {
                new() { TransactionCodeId = -5, TransactionCode = "electricity", DisplayName = "Electricity Service" },
                new() { TransactionCodeId = -7, TransactionCode = "media", DisplayName = "Entertainment" },
                new() { TransactionCodeId = -9, TransactionCode = "gas", DisplayName = "Gasoline/Fuel" },
                new() { TransactionCodeId = -12, TransactionCode = "medical", DisplayName = "Healthcare/Medical" },
                new() { TransactionCodeId = -15, TransactionCode = "insurance", DisplayName = "Insurance" },
                new() { TransactionCodeId = -16, TransactionCode = "internet", DisplayName = "Internet Service" },
                new() { TransactionCodeId = -21, TransactionCode = "mortgage/rent", DisplayName = "Mortgage/Rent" },
                new() { TransactionCodeId = -23, TransactionCode = "dineout", DisplayName = "Restaurants/Dining" },
                new() { TransactionCodeId = -42, TransactionCode = "salary", DisplayName = "Salary/Wages" }
            };

            return configurationCollection;
        }
    }
    #endregion
}
