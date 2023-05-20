using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
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
    ///  to seed data.
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
        /// <item><see cref="ModelAttributeScope"/></item>
        /// <item><see cref="ModelAttributeMember"/></item>
        /// </list>
        /// </summary>
        /// <param name="configurationcollection"></param>
        /// <returns>This <see cref="IConfigurationCollection"/> for method chaining.</returns>
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
                },
                new()
                {
                    AttributeId = (int)ModelAttributeEnum.Economy,
                    DisplayName = Strings.ModelAttribute_Economy
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
                },
                new()
                {
                    AttributeId = (int)ModelAttributeEnum.Economy,
                    ScopeCode = ModelAttributeScopeCode.Country.ConvertToStringCode()
                }
            };

            int accountTypeAttributeId = (int)ModelAttributeEnum.AccountType;
            int bankTransactionTypeAttributeId = (int)ModelAttributeEnum.BankTransactionType;
            int bankTransctionGroupAttributeId = (int)ModelAttributeEnum.BankTransactionGroup;
            int economyAttributeId = (int)ModelAttributeEnum.Economy;

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
                new() { AttributeMemberId = -933, AttributeId = bankTransctionGroupAttributeId, DisplayName = "Income", DisplayOrder = 2 },

                new() { AttributeMemberId = -951, AttributeId = economyAttributeId, DisplayName = "Developed", DisplayOrder = 0 },
                new() { AttributeMemberId = -952, AttributeId = economyAttributeId, DisplayName = "Emerging", DisplayOrder = 1 },
                new() { AttributeMemberId = -953, AttributeId = economyAttributeId, DisplayName = "Frontier", DisplayOrder = 2 }
            };

            configurationcollection
                .WithConfiguration(NewConfiguration(sourceGuid, modelAttributes))
                .WithConfiguration(NewConfiguration(sourceGuid, modelAttributescopes))
                .WithConfiguration(NewConfiguration(sourceGuid, modelAttributeMembers));

            return configurationcollection;
        }

        /// <summary>
        /// Seeds this <see cref="IConfigurationCollection"/> with sample data for:
        /// <list type="bullet">
        /// <item><see cref="CountryAttributeMemberEntry"/></item>
        /// </list>
        /// </summary>
        /// <param name="configurationCollection"></param>
        /// <returns>This <see cref="IConfigurationCollection"/> for method chaining.</returns>
        public static IConfigurationCollection WithSample_CountryAttributeEntries(
            this IConfigurationCollection configurationCollection)
        {
            const string sourceGuid = "{09236F18-7E05-43B3-96E2-6B0AD47D2BE4}";

            var minDate = DateTime.MinValue.Date;
            var countryAttributeMemberEntries = new CountryAttributeMemberEntry[]
            {
                new() { AttributeMemberId = -952, CountryId = -832, EffectiveDate = minDate, Weight = 1M },
                new() { AttributeMemberId = -952, CountryId = -609, EffectiveDate = minDate, Weight = 1M },
                new() { AttributeMemberId = -951, CountryId = -612, EffectiveDate = minDate, Weight = 1M },
                new() { AttributeMemberId = -951, CountryId = -613, EffectiveDate = minDate, Weight = 1M },
                new() { AttributeMemberId = -951, CountryId = -620, EffectiveDate = minDate, Weight = 1M },
                new() { AttributeMemberId = -953, CountryId = -617, EffectiveDate = minDate, Weight = 1M },
                new() { AttributeMemberId = -953, CountryId = -616, EffectiveDate = minDate, Weight = 1M },
                new() { AttributeMemberId = -952, CountryId = -630, EffectiveDate = minDate, Weight = 1M },
                new() { AttributeMemberId = -951, CountryId = -639, EffectiveDate = minDate, Weight = 1M },
                new() { AttributeMemberId = -951, CountryId = -814, EffectiveDate = minDate, Weight = 1M },
                new() { AttributeMemberId = -952, CountryId = -643, EffectiveDate = minDate, Weight = 1M },
                new() { AttributeMemberId = -952, CountryId = -644, EffectiveDate = minDate, Weight = 1M },
                new() { AttributeMemberId = -952, CountryId = -647, EffectiveDate = minDate, Weight = 1M },
                new() { AttributeMemberId = -952, CountryId = -657, EffectiveDate = minDate, Weight = 1M },
                new() { AttributeMemberId = -951, CountryId = -682, EffectiveDate = minDate, Weight = 1M },
                new() { AttributeMemberId = -951, CountryId = -659, EffectiveDate = minDate, Weight = 1M },
                new() { AttributeMemberId = -952, CountryId = -664, EffectiveDate = minDate, Weight = 1M },
                new() { AttributeMemberId = -951, CountryId = -808, EffectiveDate = minDate, Weight = 1M },
                new() { AttributeMemberId = -953, CountryId = -668, EffectiveDate = minDate, Weight = 1M },
                new() { AttributeMemberId = -951, CountryId = -674, EffectiveDate = minDate, Weight = 1M },
                new() { AttributeMemberId = -951, CountryId = -675, EffectiveDate = minDate, Weight = 1M },
                new() { AttributeMemberId = -951, CountryId = -833, EffectiveDate = minDate, Weight = 1M },
                new() { AttributeMemberId = -952, CountryId = -685, EffectiveDate = minDate, Weight = 1M },
                new() { AttributeMemberId = -951, CountryId = -699, EffectiveDate = minDate, Weight = 1M },
                new() { AttributeMemberId = -953, CountryId = -653, EffectiveDate = minDate, Weight = 1M },
                new() { AttributeMemberId = -952, CountryId = -700, EffectiveDate = minDate, Weight = 1M },
                new() { AttributeMemberId = -952, CountryId = -703, EffectiveDate = minDate, Weight = 1M },
                new() { AttributeMemberId = -952, CountryId = -702, EffectiveDate = minDate, Weight = 1M },
                new() { AttributeMemberId = -951, CountryId = -706, EffectiveDate = minDate, Weight = 1M },
                new() { AttributeMemberId = -951, CountryId = -708, EffectiveDate = minDate, Weight = 1M },
                new() { AttributeMemberId = -951, CountryId = -709, EffectiveDate = minDate, Weight = 1M },
                new() { AttributeMemberId = -953, CountryId = -713, EffectiveDate = minDate, Weight = 1M },
                new() { AttributeMemberId = -951, CountryId = -711, EffectiveDate = minDate, Weight = 1M },
                new() { AttributeMemberId = -953, CountryId = -714, EffectiveDate = minDate, Weight = 1M },
                new() { AttributeMemberId = -953, CountryId = -715, EffectiveDate = minDate, Weight = 1M },
                new() { AttributeMemberId = -952, CountryId = -718, EffectiveDate = minDate, Weight = 1M },
                new() { AttributeMemberId = -953, CountryId = -719, EffectiveDate = minDate, Weight = 1M },
                new() { AttributeMemberId = -953, CountryId = -723, EffectiveDate = minDate, Weight = 1M },
                new() { AttributeMemberId = -953, CountryId = -809, EffectiveDate = minDate, Weight = 1M },
                new() { AttributeMemberId = -953, CountryId = -728, EffectiveDate = minDate, Weight = 1M },
                new() { AttributeMemberId = -953, CountryId = -750, EffectiveDate = minDate, Weight = 1M },
                new() { AttributeMemberId = -952, CountryId = -743, EffectiveDate = minDate, Weight = 1M },
                new() { AttributeMemberId = -953, CountryId = -741, EffectiveDate = minDate, Weight = 1M },
                new() { AttributeMemberId = -952, CountryId = -734, EffectiveDate = minDate, Weight = 1M },
                new() { AttributeMemberId = -953, CountryId = -761, EffectiveDate = minDate, Weight = 1M },
                new() { AttributeMemberId = -951, CountryId = -756, EffectiveDate = minDate, Weight = 1M },
                new() { AttributeMemberId = -951, CountryId = -765, EffectiveDate = minDate, Weight = 1M },
                new() { AttributeMemberId = -951, CountryId = -758, EffectiveDate = minDate, Weight = 1M },
                new() { AttributeMemberId = -953, CountryId = -766, EffectiveDate = minDate, Weight = 1M },
                new() { AttributeMemberId = -952, CountryId = -767, EffectiveDate = minDate, Weight = 1M },
                new() { AttributeMemberId = -952, CountryId = -773, EffectiveDate = minDate, Weight = 1M },
                new() { AttributeMemberId = -952, CountryId = -774, EffectiveDate = minDate, Weight = 1M },
                new() { AttributeMemberId = -952, CountryId = -776, EffectiveDate = minDate, Weight = 1M },
                new() { AttributeMemberId = -951, CountryId = -777, EffectiveDate = minDate, Weight = 1M },
                new() { AttributeMemberId = -952, CountryId = -779, EffectiveDate = minDate, Weight = 1M },
                new() { AttributeMemberId = -953, CountryId = -780, EffectiveDate = minDate, Weight = 1M },
                new() { AttributeMemberId = -952, CountryId = -781, EffectiveDate = minDate, Weight = 1M },
                new() { AttributeMemberId = -952, CountryId = -794, EffectiveDate = minDate, Weight = 1M },
                new() { AttributeMemberId = -951, CountryId = -799, EffectiveDate = minDate, Weight = 1M },
                new() { AttributeMemberId = -953, CountryId = -796, EffectiveDate = minDate, Weight = 1M },
                new() { AttributeMemberId = -953, CountryId = -802, EffectiveDate = minDate, Weight = 1M },
                new() { AttributeMemberId = -951, CountryId = -813, EffectiveDate = minDate, Weight = 1M },
                new() { AttributeMemberId = -952, CountryId = -819, EffectiveDate = minDate, Weight = 1M },
                new() { AttributeMemberId = -953, CountryId = -825, EffectiveDate = minDate, Weight = 1M },
                new() { AttributeMemberId = -952, CountryId = -826, EffectiveDate = minDate, Weight = 1M },
                new() { AttributeMemberId = -952, CountryId = -816, EffectiveDate = minDate, Weight = 1M },
                new() { AttributeMemberId = -951, CountryId = -835, EffectiveDate = minDate, Weight = 1M },
                new() { AttributeMemberId = -953, CountryId = -840, EffectiveDate = minDate, Weight = 1M },
                new() { AttributeMemberId = -952, CountryId = -805, EffectiveDate = minDate, Weight = 1M }
            };

            configurationCollection
                .WithConfiguration(NewConfiguration(sourceGuid, countryAttributeMemberEntries));

            return configurationCollection;
        }

        /// <summary>
        /// Seeds this <see cref="IConfigurationCollection"/> with sample data for:
        /// <list type="bullet">
        /// <item><see cref="MarketIndex"/></item>
        /// <item><see cref="MarketIndexPrice"/></item>
        /// </list>
        /// </summary>
        /// <param name="configurationCollection"></param>
        /// <returns>This <see cref="IConfigurationCollection"/> for method chaining.</returns>
        public static IConfigurationCollection WithSample_MarketIndexGraph(
            this IConfigurationCollection configurationCollection)
        {
            const string sourceGuid = "{D38E2D00-A04B-45F5-B911-743739E79EA2}";

            var marketIndices = new MarketIndex[]
            {
                new() { IndexId = -2, IndexCode = "SPX", IndexDescription = "S&P 500" },
                new() { IndexId = -3, IndexCode = "DJIA", IndexDescription = "Dow Jones Industrial Average" },
                new() { IndexId = -4, IndexCode = "NASDAQ", IndexDescription = "NASDAQ Composite" }
            };

            string priceCode = MarketIndexPriceCode.PriceReturn.ConvertToStringCode();

            var marketIndexRates = new MarketIndexPrice[]
            {
                new(){ IndexPriceId = -1, MarketIndexId = -3, PriceDate = new DateTime(2023, 1, 3), PriceCode = priceCode },
                new(){ IndexPriceId = -2, MarketIndexId = -4, PriceDate = new DateTime(2023, 1, 3), PriceCode = priceCode },
                new(){ IndexPriceId = -3, MarketIndexId = -2, PriceDate = new DateTime(2023, 1, 3), PriceCode = priceCode },
                new(){ IndexPriceId = -4, MarketIndexId = -3, PriceDate = new DateTime(2023, 1, 4), PriceCode = priceCode },
                new(){ IndexPriceId = -5, MarketIndexId = -4, PriceDate = new DateTime(2023, 1, 4), PriceCode = priceCode },
                new(){ IndexPriceId = -6, MarketIndexId = -2, PriceDate = new DateTime(2023, 1, 4), PriceCode = priceCode },
                new(){ IndexPriceId = -7, MarketIndexId = -3, PriceDate = new DateTime(2023, 1, 5), PriceCode = priceCode },
                new(){ IndexPriceId = -8, MarketIndexId = -4, PriceDate = new DateTime(2023, 1, 5), PriceCode = priceCode },
                new(){ IndexPriceId = -9, MarketIndexId = -2, PriceDate = new DateTime(2023, 1, 5), PriceCode = priceCode },
                new(){ IndexPriceId = -10, MarketIndexId = -3, PriceDate = new DateTime(2023, 1, 6), PriceCode = priceCode },
                new(){ IndexPriceId = -11, MarketIndexId = -4, PriceDate = new DateTime(2023, 1, 6), PriceCode = priceCode },
                new(){ IndexPriceId = -12, MarketIndexId = -2, PriceDate = new DateTime(2023, 1, 6), PriceCode = priceCode },
                new(){ IndexPriceId = -13, MarketIndexId = -3, PriceDate = new DateTime(2023, 1, 9), PriceCode = priceCode },
                new(){ IndexPriceId = -14, MarketIndexId = -4, PriceDate = new DateTime(2023, 1, 9), PriceCode = priceCode },
                new(){ IndexPriceId = -15, MarketIndexId = -2, PriceDate = new DateTime(2023, 1, 9), PriceCode = priceCode },
                new(){ IndexPriceId = -16, MarketIndexId = -3, PriceDate = new DateTime(2023, 1, 10), PriceCode = priceCode },
                new(){ IndexPriceId = -17, MarketIndexId = -4, PriceDate = new DateTime(2023, 1, 10), PriceCode = priceCode },
                new(){ IndexPriceId = -18, MarketIndexId = -2, PriceDate = new DateTime(2023, 1, 10), PriceCode = priceCode },
                new(){ IndexPriceId = -19, MarketIndexId = -3, PriceDate = new DateTime(2023, 1, 11), PriceCode = priceCode },
                new(){ IndexPriceId = -20, MarketIndexId = -4, PriceDate = new DateTime(2023, 1, 11), PriceCode = priceCode },
                new(){ IndexPriceId = -21, MarketIndexId = -2, PriceDate = new DateTime(2023, 1, 11), PriceCode = priceCode },
                new(){ IndexPriceId = -22, MarketIndexId = -3, PriceDate = new DateTime(2023, 1, 12), PriceCode = priceCode },
                new(){ IndexPriceId = -23, MarketIndexId = -4, PriceDate = new DateTime(2023, 1, 12), PriceCode = priceCode },
                new(){ IndexPriceId = -24, MarketIndexId = -2, PriceDate = new DateTime(2023, 1, 12), PriceCode = priceCode },
                new(){ IndexPriceId = -25, MarketIndexId = -3, PriceDate = new DateTime(2023, 1, 13), PriceCode = priceCode },
                new(){ IndexPriceId = -26, MarketIndexId = -4, PriceDate = new DateTime(2023, 1, 13), PriceCode = priceCode },
                new(){ IndexPriceId = -27, MarketIndexId = -2, PriceDate = new DateTime(2023, 1, 13), PriceCode = priceCode },
                new(){ IndexPriceId = -28, MarketIndexId = -3, PriceDate = new DateTime(2023, 1, 17), PriceCode = priceCode },
                new(){ IndexPriceId = -29, MarketIndexId = -4, PriceDate = new DateTime(2023, 1, 17), PriceCode = priceCode },
                new(){ IndexPriceId = -30, MarketIndexId = -2, PriceDate = new DateTime(2023, 1, 17), PriceCode = priceCode },
                new(){ IndexPriceId = -31, MarketIndexId = -3, PriceDate = new DateTime(2023, 1, 18), PriceCode = priceCode },
                new(){ IndexPriceId = -32, MarketIndexId = -4, PriceDate = new DateTime(2023, 1, 18), PriceCode = priceCode },
                new(){ IndexPriceId = -33, MarketIndexId = -2, PriceDate = new DateTime(2023, 1, 18), PriceCode = priceCode },
                new(){ IndexPriceId = -34, MarketIndexId = -3, PriceDate = new DateTime(2023, 1, 19), PriceCode = priceCode },
                new(){ IndexPriceId = -35, MarketIndexId = -4, PriceDate = new DateTime(2023, 1, 19), PriceCode = priceCode },
                new(){ IndexPriceId = -36, MarketIndexId = -2, PriceDate = new DateTime(2023, 1, 19), PriceCode = priceCode },
                new(){ IndexPriceId = -37, MarketIndexId = -3, PriceDate = new DateTime(2023, 1, 20), PriceCode = priceCode },
                new(){ IndexPriceId = -38, MarketIndexId = -4, PriceDate = new DateTime(2023, 1, 20), PriceCode = priceCode },
                new(){ IndexPriceId = -39, MarketIndexId = -2, PriceDate = new DateTime(2023, 1, 20), PriceCode = priceCode },
                new(){ IndexPriceId = -40, MarketIndexId = -3, PriceDate = new DateTime(2023, 1, 23), PriceCode = priceCode },
                new(){ IndexPriceId = -41, MarketIndexId = -4, PriceDate = new DateTime(2023, 1, 23), PriceCode = priceCode },
                new(){ IndexPriceId = -42, MarketIndexId = -2, PriceDate = new DateTime(2023, 1, 23), PriceCode = priceCode },
                new(){ IndexPriceId = -43, MarketIndexId = -3, PriceDate = new DateTime(2023, 1, 24), PriceCode = priceCode },
                new(){ IndexPriceId = -44, MarketIndexId = -4, PriceDate = new DateTime(2023, 1, 24), PriceCode = priceCode },
                new(){ IndexPriceId = -45, MarketIndexId = -2, PriceDate = new DateTime(2023, 1, 24), PriceCode = priceCode },
                new(){ IndexPriceId = -46, MarketIndexId = -3, PriceDate = new DateTime(2023, 1, 25), PriceCode = priceCode },
                new(){ IndexPriceId = -47, MarketIndexId = -4, PriceDate = new DateTime(2023, 1, 25), PriceCode = priceCode },
                new(){ IndexPriceId = -48, MarketIndexId = -2, PriceDate = new DateTime(2023, 1, 25), PriceCode = priceCode },
                new(){ IndexPriceId = -49, MarketIndexId = -3, PriceDate = new DateTime(2023, 1, 26), PriceCode = priceCode },
                new(){ IndexPriceId = -50, MarketIndexId = -4, PriceDate = new DateTime(2023, 1, 26), PriceCode = priceCode },
                new(){ IndexPriceId = -51, MarketIndexId = -2, PriceDate = new DateTime(2023, 1, 26), PriceCode = priceCode },
                new(){ IndexPriceId = -52, MarketIndexId = -3, PriceDate = new DateTime(2023, 1, 27), PriceCode = priceCode },
                new(){ IndexPriceId = -53, MarketIndexId = -4, PriceDate = new DateTime(2023, 1, 27), PriceCode = priceCode },
                new(){ IndexPriceId = -54, MarketIndexId = -2, PriceDate = new DateTime(2023, 1, 27), PriceCode = priceCode },
                new(){ IndexPriceId = -55, MarketIndexId = -3, PriceDate = new DateTime(2023, 1, 30), PriceCode = priceCode },
                new(){ IndexPriceId = -56, MarketIndexId = -4, PriceDate = new DateTime(2023, 1, 30), PriceCode = priceCode },
                new(){ IndexPriceId = -57, MarketIndexId = -2, PriceDate = new DateTime(2023, 1, 30), PriceCode = priceCode },
                new(){ IndexPriceId = -58, MarketIndexId = -3, PriceDate = new DateTime(2023, 1, 31), PriceCode = priceCode },
                new(){ IndexPriceId = -59, MarketIndexId = -4, PriceDate = new DateTime(2023, 1, 31), PriceCode = priceCode },
                new(){ IndexPriceId = -60, MarketIndexId = -2, PriceDate = new DateTime(2023, 1, 31), PriceCode = priceCode },
                new(){ IndexPriceId = -61, MarketIndexId = -3, PriceDate = new DateTime(2023, 2, 1), PriceCode = priceCode },
                new(){ IndexPriceId = -62, MarketIndexId = -4, PriceDate = new DateTime(2023, 2, 1), PriceCode = priceCode },
                new(){ IndexPriceId = -63, MarketIndexId = -2, PriceDate = new DateTime(2023, 2, 1), PriceCode = priceCode },
                new(){ IndexPriceId = -64, MarketIndexId = -3, PriceDate = new DateTime(2023, 2, 2), PriceCode = priceCode },
                new(){ IndexPriceId = -65, MarketIndexId = -4, PriceDate = new DateTime(2023, 2, 2), PriceCode = priceCode },
                new(){ IndexPriceId = -66, MarketIndexId = -2, PriceDate = new DateTime(2023, 2, 2), PriceCode = priceCode },
                new(){ IndexPriceId = -67, MarketIndexId = -3, PriceDate = new DateTime(2023, 2, 3), PriceCode = priceCode },
                new(){ IndexPriceId = -68, MarketIndexId = -4, PriceDate = new DateTime(2023, 2, 3), PriceCode = priceCode },
                new(){ IndexPriceId = -69, MarketIndexId = -2, PriceDate = new DateTime(2023, 2, 3), PriceCode = priceCode },
                new(){ IndexPriceId = -70, MarketIndexId = -3, PriceDate = new DateTime(2023, 2, 6), PriceCode = priceCode },
                new(){ IndexPriceId = -71, MarketIndexId = -4, PriceDate = new DateTime(2023, 2, 6), PriceCode = priceCode },
                new(){ IndexPriceId = -72, MarketIndexId = -2, PriceDate = new DateTime(2023, 2, 6), PriceCode = priceCode },
                new(){ IndexPriceId = -73, MarketIndexId = -3, PriceDate = new DateTime(2023, 2, 7), PriceCode = priceCode },
                new(){ IndexPriceId = -74, MarketIndexId = -4, PriceDate = new DateTime(2023, 2, 7), PriceCode = priceCode },
                new(){ IndexPriceId = -75, MarketIndexId = -2, PriceDate = new DateTime(2023, 2, 7), PriceCode = priceCode },
                new(){ IndexPriceId = -76, MarketIndexId = -3, PriceDate = new DateTime(2023, 2, 8), PriceCode = priceCode },
                new(){ IndexPriceId = -77, MarketIndexId = -4, PriceDate = new DateTime(2023, 2, 8), PriceCode = priceCode },
                new(){ IndexPriceId = -78, MarketIndexId = -2, PriceDate = new DateTime(2023, 2, 8), PriceCode = priceCode },
                new(){ IndexPriceId = -79, MarketIndexId = -3, PriceDate = new DateTime(2023, 2, 9), PriceCode = priceCode },
                new(){ IndexPriceId = -80, MarketIndexId = -4, PriceDate = new DateTime(2023, 2, 9), PriceCode = priceCode },
                new(){ IndexPriceId = -81, MarketIndexId = -2, PriceDate = new DateTime(2023, 2, 9), PriceCode = priceCode },
                new(){ IndexPriceId = -82, MarketIndexId = -3, PriceDate = new DateTime(2023, 2, 10), PriceCode = priceCode },
                new(){ IndexPriceId = -83, MarketIndexId = -4, PriceDate = new DateTime(2023, 2, 10), PriceCode = priceCode },
                new(){ IndexPriceId = -84, MarketIndexId = -2, PriceDate = new DateTime(2023, 2, 10), PriceCode = priceCode },
                new(){ IndexPriceId = -85, MarketIndexId = -3, PriceDate = new DateTime(2023, 2, 13), PriceCode = priceCode },
                new(){ IndexPriceId = -86, MarketIndexId = -4, PriceDate = new DateTime(2023, 2, 13), PriceCode = priceCode },
                new(){ IndexPriceId = -87, MarketIndexId = -2, PriceDate = new DateTime(2023, 2, 13), PriceCode = priceCode },
                new(){ IndexPriceId = -88, MarketIndexId = -3, PriceDate = new DateTime(2023, 2, 14), PriceCode = priceCode },
                new(){ IndexPriceId = -89, MarketIndexId = -4, PriceDate = new DateTime(2023, 2, 14), PriceCode = priceCode },
                new(){ IndexPriceId = -90, MarketIndexId = -2, PriceDate = new DateTime(2023, 2, 14), PriceCode = priceCode },
                new(){ IndexPriceId = -91, MarketIndexId = -3, PriceDate = new DateTime(2023, 2, 15), PriceCode = priceCode },
                new(){ IndexPriceId = -92, MarketIndexId = -4, PriceDate = new DateTime(2023, 2, 15), PriceCode = priceCode },
                new(){ IndexPriceId = -93, MarketIndexId = -2, PriceDate = new DateTime(2023, 2, 15), PriceCode = priceCode },
                new(){ IndexPriceId = -94, MarketIndexId = -3, PriceDate = new DateTime(2023, 2, 16), PriceCode = priceCode },
                new(){ IndexPriceId = -95, MarketIndexId = -4, PriceDate = new DateTime(2023, 2, 16), PriceCode = priceCode },
                new(){ IndexPriceId = -96, MarketIndexId = -2, PriceDate = new DateTime(2023, 2, 16), PriceCode = priceCode },
                new(){ IndexPriceId = -97, MarketIndexId = -3, PriceDate = new DateTime(2023, 2, 17), PriceCode = priceCode },
                new(){ IndexPriceId = -98, MarketIndexId = -4, PriceDate = new DateTime(2023, 2, 17), PriceCode = priceCode },
                new(){ IndexPriceId = -99, MarketIndexId = -2, PriceDate = new DateTime(2023, 2, 17), PriceCode = priceCode },
                new(){ IndexPriceId = -100, MarketIndexId = -3, PriceDate = new DateTime(2023, 2, 21), PriceCode = priceCode },
                new(){ IndexPriceId = -101, MarketIndexId = -4, PriceDate = new DateTime(2023, 2, 21), PriceCode = priceCode },
                new(){ IndexPriceId = -102, MarketIndexId = -2, PriceDate = new DateTime(2023, 2, 21), PriceCode = priceCode },
                new(){ IndexPriceId = -103, MarketIndexId = -3, PriceDate = new DateTime(2023, 2, 22), PriceCode = priceCode },
                new(){ IndexPriceId = -104, MarketIndexId = -4, PriceDate = new DateTime(2023, 2, 22), PriceCode = priceCode },
                new(){ IndexPriceId = -105, MarketIndexId = -2, PriceDate = new DateTime(2023, 2, 22), PriceCode = priceCode },
                new(){ IndexPriceId = -106, MarketIndexId = -3, PriceDate = new DateTime(2023, 2, 23), PriceCode = priceCode },
                new(){ IndexPriceId = -107, MarketIndexId = -4, PriceDate = new DateTime(2023, 2, 23), PriceCode = priceCode },
                new(){ IndexPriceId = -108, MarketIndexId = -2, PriceDate = new DateTime(2023, 2, 23), PriceCode = priceCode },
                new(){ IndexPriceId = -109, MarketIndexId = -3, PriceDate = new DateTime(2023, 2, 24), PriceCode = priceCode },
                new(){ IndexPriceId = -110, MarketIndexId = -4, PriceDate = new DateTime(2023, 2, 24), PriceCode = priceCode },
                new(){ IndexPriceId = -111, MarketIndexId = -2, PriceDate = new DateTime(2023, 2, 24), PriceCode = priceCode },
                new(){ IndexPriceId = -112, MarketIndexId = -3, PriceDate = new DateTime(2023, 2, 27), PriceCode = priceCode },
                new(){ IndexPriceId = -113, MarketIndexId = -4, PriceDate = new DateTime(2023, 2, 27), PriceCode = priceCode },
                new(){ IndexPriceId = -114, MarketIndexId = -2, PriceDate = new DateTime(2023, 2, 27), PriceCode = priceCode },
                new(){ IndexPriceId = -115, MarketIndexId = -3, PriceDate = new DateTime(2023, 2, 28), PriceCode = priceCode },
                new(){ IndexPriceId = -116, MarketIndexId = -4, PriceDate = new DateTime(2023, 2, 28), PriceCode = priceCode },
                new(){ IndexPriceId = -117, MarketIndexId = -2, PriceDate = new DateTime(2023, 2, 28), PriceCode = priceCode },
                new(){ IndexPriceId = -118, MarketIndexId = -3, PriceDate = new DateTime(2023, 3, 1), PriceCode = priceCode },
                new(){ IndexPriceId = -119, MarketIndexId = -4, PriceDate = new DateTime(2023, 3, 1), PriceCode = priceCode },
                new(){ IndexPriceId = -120, MarketIndexId = -2, PriceDate = new DateTime(2023, 3, 1), PriceCode = priceCode },
                new(){ IndexPriceId = -121, MarketIndexId = -3, PriceDate = new DateTime(2023, 3, 2), PriceCode = priceCode },
                new(){ IndexPriceId = -122, MarketIndexId = -4, PriceDate = new DateTime(2023, 3, 2), PriceCode = priceCode },
                new(){ IndexPriceId = -123, MarketIndexId = -2, PriceDate = new DateTime(2023, 3, 2), PriceCode = priceCode },
                new(){ IndexPriceId = -124, MarketIndexId = -3, PriceDate = new DateTime(2023, 3, 3), PriceCode = priceCode },
                new(){ IndexPriceId = -125, MarketIndexId = -4, PriceDate = new DateTime(2023, 3, 3), PriceCode = priceCode },
                new(){ IndexPriceId = -126, MarketIndexId = -2, PriceDate = new DateTime(2023, 3, 3), PriceCode = priceCode },
                new(){ IndexPriceId = -127, MarketIndexId = -3, PriceDate = new DateTime(2023, 3, 6), PriceCode = priceCode },
                new(){ IndexPriceId = -128, MarketIndexId = -4, PriceDate = new DateTime(2023, 3, 6), PriceCode = priceCode },
                new(){ IndexPriceId = -129, MarketIndexId = -2, PriceDate = new DateTime(2023, 3, 6), PriceCode = priceCode },
                new(){ IndexPriceId = -130, MarketIndexId = -3, PriceDate = new DateTime(2023, 3, 7), PriceCode = priceCode },
                new(){ IndexPriceId = -131, MarketIndexId = -4, PriceDate = new DateTime(2023, 3, 7), PriceCode = priceCode },
                new(){ IndexPriceId = -132, MarketIndexId = -2, PriceDate = new DateTime(2023, 3, 7), PriceCode = priceCode },
                new(){ IndexPriceId = -133, MarketIndexId = -3, PriceDate = new DateTime(2023, 3, 8), PriceCode = priceCode },
                new(){ IndexPriceId = -134, MarketIndexId = -4, PriceDate = new DateTime(2023, 3, 8), PriceCode = priceCode },
                new(){ IndexPriceId = -135, MarketIndexId = -2, PriceDate = new DateTime(2023, 3, 8), PriceCode = priceCode },
                new(){ IndexPriceId = -136, MarketIndexId = -3, PriceDate = new DateTime(2023, 3, 9), PriceCode = priceCode },
                new(){ IndexPriceId = -137, MarketIndexId = -4, PriceDate = new DateTime(2023, 3, 9), PriceCode = priceCode },
                new(){ IndexPriceId = -138, MarketIndexId = -2, PriceDate = new DateTime(2023, 3, 9), PriceCode = priceCode },
                new(){ IndexPriceId = -139, MarketIndexId = -3, PriceDate = new DateTime(2023, 3, 10), PriceCode = priceCode },
                new(){ IndexPriceId = -140, MarketIndexId = -4, PriceDate = new DateTime(2023, 3, 10), PriceCode = priceCode },
                new(){ IndexPriceId = -141, MarketIndexId = -2, PriceDate = new DateTime(2023, 3, 10), PriceCode = priceCode },
                new(){ IndexPriceId = -142, MarketIndexId = -3, PriceDate = new DateTime(2023, 3, 13), PriceCode = priceCode },
                new(){ IndexPriceId = -143, MarketIndexId = -4, PriceDate = new DateTime(2023, 3, 13), PriceCode = priceCode },
                new(){ IndexPriceId = -144, MarketIndexId = -2, PriceDate = new DateTime(2023, 3, 13), PriceCode = priceCode },
                new(){ IndexPriceId = -145, MarketIndexId = -3, PriceDate = new DateTime(2023, 3, 14), PriceCode = priceCode },
                new(){ IndexPriceId = -146, MarketIndexId = -4, PriceDate = new DateTime(2023, 3, 14), PriceCode = priceCode },
                new(){ IndexPriceId = -147, MarketIndexId = -2, PriceDate = new DateTime(2023, 3, 14), PriceCode = priceCode },
                new(){ IndexPriceId = -148, MarketIndexId = -3, PriceDate = new DateTime(2023, 3, 15), PriceCode = priceCode },
                new(){ IndexPriceId = -149, MarketIndexId = -4, PriceDate = new DateTime(2023, 3, 15), PriceCode = priceCode },
                new(){ IndexPriceId = -150, MarketIndexId = -2, PriceDate = new DateTime(2023, 3, 15), PriceCode = priceCode },
                new(){ IndexPriceId = -151, MarketIndexId = -3, PriceDate = new DateTime(2023, 3, 16), PriceCode = priceCode },
                new(){ IndexPriceId = -152, MarketIndexId = -4, PriceDate = new DateTime(2023, 3, 16), PriceCode = priceCode },
                new(){ IndexPriceId = -153, MarketIndexId = -2, PriceDate = new DateTime(2023, 3, 16), PriceCode = priceCode },
                new(){ IndexPriceId = -154, MarketIndexId = -3, PriceDate = new DateTime(2023, 3, 17), PriceCode = priceCode },
                new(){ IndexPriceId = -155, MarketIndexId = -4, PriceDate = new DateTime(2023, 3, 17), PriceCode = priceCode },
                new(){ IndexPriceId = -156, MarketIndexId = -2, PriceDate = new DateTime(2023, 3, 17), PriceCode = priceCode },
                new(){ IndexPriceId = -157, MarketIndexId = -3, PriceDate = new DateTime(2023, 3, 20), PriceCode = priceCode },
                new(){ IndexPriceId = -158, MarketIndexId = -4, PriceDate = new DateTime(2023, 3, 20), PriceCode = priceCode },
                new(){ IndexPriceId = -159, MarketIndexId = -2, PriceDate = new DateTime(2023, 3, 20), PriceCode = priceCode },
                new(){ IndexPriceId = -160, MarketIndexId = -3, PriceDate = new DateTime(2023, 3, 21), PriceCode = priceCode },
                new(){ IndexPriceId = -161, MarketIndexId = -4, PriceDate = new DateTime(2023, 3, 21), PriceCode = priceCode },
                new(){ IndexPriceId = -162, MarketIndexId = -2, PriceDate = new DateTime(2023, 3, 21), PriceCode = priceCode },
                new(){ IndexPriceId = -163, MarketIndexId = -3, PriceDate = new DateTime(2023, 3, 22), PriceCode = priceCode },
                new(){ IndexPriceId = -164, MarketIndexId = -4, PriceDate = new DateTime(2023, 3, 22), PriceCode = priceCode },
                new(){ IndexPriceId = -165, MarketIndexId = -2, PriceDate = new DateTime(2023, 3, 22), PriceCode = priceCode },
                new(){ IndexPriceId = -166, MarketIndexId = -3, PriceDate = new DateTime(2023, 3, 23), PriceCode = priceCode },
                new(){ IndexPriceId = -167, MarketIndexId = -4, PriceDate = new DateTime(2023, 3, 23), PriceCode = priceCode },
                new(){ IndexPriceId = -168, MarketIndexId = -2, PriceDate = new DateTime(2023, 3, 23), PriceCode = priceCode },
                new(){ IndexPriceId = -169, MarketIndexId = -3, PriceDate = new DateTime(2023, 3, 24), PriceCode = priceCode },
                new(){ IndexPriceId = -170, MarketIndexId = -4, PriceDate = new DateTime(2023, 3, 24), PriceCode = priceCode },
                new(){ IndexPriceId = -171, MarketIndexId = -2, PriceDate = new DateTime(2023, 3, 24), PriceCode = priceCode },
                new(){ IndexPriceId = -172, MarketIndexId = -3, PriceDate = new DateTime(2023, 3, 27), PriceCode = priceCode },
                new(){ IndexPriceId = -173, MarketIndexId = -4, PriceDate = new DateTime(2023, 3, 27), PriceCode = priceCode },
                new(){ IndexPriceId = -174, MarketIndexId = -2, PriceDate = new DateTime(2023, 3, 27), PriceCode = priceCode },
                new(){ IndexPriceId = -175, MarketIndexId = -3, PriceDate = new DateTime(2023, 3, 28), PriceCode = priceCode },
                new(){ IndexPriceId = -176, MarketIndexId = -4, PriceDate = new DateTime(2023, 3, 28), PriceCode = priceCode },
                new(){ IndexPriceId = -177, MarketIndexId = -2, PriceDate = new DateTime(2023, 3, 28), PriceCode = priceCode },
                new(){ IndexPriceId = -178, MarketIndexId = -3, PriceDate = new DateTime(2023, 3, 29), PriceCode = priceCode },
                new(){ IndexPriceId = -179, MarketIndexId = -4, PriceDate = new DateTime(2023, 3, 29), PriceCode = priceCode },
                new(){ IndexPriceId = -180, MarketIndexId = -2, PriceDate = new DateTime(2023, 3, 29), PriceCode = priceCode },
                new(){ IndexPriceId = -181, MarketIndexId = -3, PriceDate = new DateTime(2023, 3, 30), PriceCode = priceCode },
                new(){ IndexPriceId = -182, MarketIndexId = -4, PriceDate = new DateTime(2023, 3, 30), PriceCode = priceCode },
                new(){ IndexPriceId = -183, MarketIndexId = -2, PriceDate = new DateTime(2023, 3, 30), PriceCode = priceCode },
                new(){ IndexPriceId = -184, MarketIndexId = -3, PriceDate = new DateTime(2023, 3, 31), PriceCode = priceCode },
                new(){ IndexPriceId = -185, MarketIndexId = -4, PriceDate = new DateTime(2023, 3, 31), PriceCode = priceCode },
                new(){ IndexPriceId = -186, MarketIndexId = -2, PriceDate = new DateTime(2023, 3, 31), PriceCode = priceCode }
            };

            configurationCollection
                .WithConfiguration(NewConfiguration(sourceGuid, marketIndices))
                .WithConfiguration(NewConfiguration(sourceGuid, marketIndexRates));

            return configurationCollection;
        }


        /// <summary>
        /// Seeds this <see cref="IConfigurationCollection"/> with sample data for:
        /// <list type="bullet">
        /// <item><see cref="BankTransactionCode"/></item>
        /// <item><see cref="BankTransactionCodeAttributeMemberEntry"/></item>
        /// </list>
        /// </summary>
        /// <param name="configurationCollection"></param>
        /// <returns>This <see cref="IConfigurationCollection"/> for method chaining.</returns>
        public static IConfigurationCollection WithSample_BankTransactionCodeGraph(
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
