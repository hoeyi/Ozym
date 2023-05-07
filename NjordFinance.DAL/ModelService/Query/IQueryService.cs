using NjordFinance.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using NjordFinance.EntityModel.Annotations;
using System.Reflection;
using System.Linq;
using NjordFinance.DataTransfer.Generic;

namespace NjordFinance.EntityModelService.Query
{
    /// <summary>
    /// Represents a read-only service for extracting DTOs representing foreign-key relationships.
    /// </summary>
    public partial interface IQueryService
    {
        /// <summary>
        /// Returns a collection of <typeparamref name="T"/> models from the data store.
        /// </summary>
        /// <typeparam name="T">The model type to return.</typeparam>
        /// <param name="predicate">The expression to match the <typeparamref name="T"/>.</param>
        /// <param name="path">The path for the navigation property to include. 
        /// The default is null, which does not load related data.</param>
        /// <returns>The <typeparamref name="T"/> instance that matches the 
        /// <paramref name="predicate"/>.</returns>
        Task<IEnumerable<T>> GetManyAsync<T>(
            Expression<Func<T, bool>> predicate, Expression<Func<T, object>> path = null)
            where T : class, new();

        /// <summary>
        /// Returns a single <typeparamref name="T"/> from the data store, or throws an exception 
        /// if the sequence does not return a single result.
        /// </summary>
        /// <typeparam name="T">The model type to return.</typeparam>
        /// <param name="predicate">The expression to match the <typeparamref name="T"/>.</param>
        /// <param name="path">The path for the navigation property to include. 
        /// The default is null, which does not load related data.</param>
        /// <returns>The <typeparamref name="T"/> instance that matches the 
        /// <paramref name="predicate"/>.</returns>
        Task<T> GetSingleAsync<T>(
            Expression<Func<T, bool>> predicate, Expression<Func<T, object>> path = null)
            where T : class, new();
    }

    public partial interface IQueryService
    {
        /// <summary>
        /// Creates a new instance implementing <see cref="IQueryBuilder{TSource}"/> where 
        /// <typeparamref name="TSource"/> is the target object.
        /// </summary>
        /// <typeparam name="TSource">Is the target of the query built using this interface.
        /// </typeparam>
        /// <returns>An <see cref="IQueryBuilder{TSource}"/> for <typeparamref name="TSource"/> 
        /// models.</returns>
        IQueryBuilder<TSource> CreateQueryBuilder<TSource>()
            where TSource : class, new();

        /// <summary>
        /// Returns a key-value representation of a record. Only the 
        /// fields matching the <paramref name="key"/> and <paramref name="display"/> parameters 
        /// are included in the query.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="predicate"></param>
        /// <param name="key"></param>
        /// <param name="display"></param>
        /// <returns></returns>
        IEnumerable<LookupModel<TKey, TValue>> SelectDTOsFromEnum<TEnum, TKey, TValue>(
            Func<TEnum, bool> predicate,
            Expression<Func<TEnum, TKey>> key,
            Expression<Func<TEnum, TValue>> display,
            Func<LookupModel<TKey, TValue>> placeHolderDelegate = null)
            where TEnum : struct, Enum
        {
            var keyDeleg = key.Compile();
            var displayDeleg = display.Compile();

            var results = Enum.GetValues(typeof(TEnum)).Cast<TEnum>()
                .Where(predicate)
                .Select(x => new LookupModel<TKey, TValue>()
                {
                    Key = keyDeleg(x),
                    Display = displayDeleg(x)
                })
                .ToList();

            if(placeHolderDelegate is not null)
            {
                var placeHolder = placeHolderDelegate.Invoke();
                results.Insert(0, placeHolder);
            }

            return results;
        }

        /// <summary>
        /// Executes a select query returning a key-value representation of <typeparamref name="TSource"/> 
        /// records. Only the fields matching the <paramref name="key"/> and <paramref name="display"/> parameters 
        /// are included in the query.
        /// </summary>
        /// <typeparamref name="TSource"/>
        /// <typeparam name="TKey">The key type for the lookup record.</typeparam>
        /// <typeparam name="TValue">Teh display type for the lookup record.</typeparam>
        /// <param name="key">Expression indicating the attribute to use as the key.</param>
        /// <param name="display">Expression indicating the attribute to use for display.</param>
        /// <param name="defaultKey">Default key value to use for placeholder record.</param>
        /// <param name="defaultDisplay">Default display value to use for the placeholder record.</param>
        /// <returns>A task representing an asynchronous query and DTO-mapping. The task result is an
        /// <see cref="IEnumerable{T}"/> containing key-value records represent a foregin key reference.</returns>
        async Task<IEnumerable<LookupModel<TKey, TValue>>> SelectDTOsAsync<TSource, TKey, TValue>(
            Expression<Func<TSource, TKey>> key,
            Expression<Func<TSource, TValue>> display,
            TKey defaultKey = default,
            TValue defaultDisplay = default)
            where TSource : class, new()
        {
            using var queryBuilder = CreateQueryBuilder<TSource>();

            return await queryBuilder.Build().SelectDTOsAsync(key, display, defaultKey, defaultDisplay);
        }

        /// <summary>
        /// Executes a select query returning a key-value representation of <typeparamref name="TSource"/> 
        /// records. Only the fields matching the <paramref name="key"/> and <paramref name="display"/> parameters 
        /// are included in the query.
        /// Wrapper method for DTOs that will have an integer key and string display value.
        /// </summary>
        /// <typeparamref name="TSource"/>
        /// <param name="key">Expression indicating the attribute to use as the key.</param>
        /// <param name="display">Expression indicating the attribute to use for display.</param>
        /// <param name="defaultKey">Default key value to use for placeholder record.</param>
        /// <param name="defaultDisplay">Default display value to use for the placeholder record.</param>
        /// <returns>A task representing an asynchronous query and DTO-mapping. The task result is an
        /// <see cref="IEnumerable{T}"/> containing key-value records represent a foregin key reference.</returns>
        async Task<IEnumerable<LookupModel<int, string>>> SelectDTOsAsync<TSource>(
            Expression<Func<TSource, int>> key,
            Expression<Func<TSource, string>> display,
            int defaultKey = default,
            string defaultDisplay = default)
            where TSource : class, new()
        {
            using var queryBuilder = CreateQueryBuilder<TSource>();

            return await queryBuilder.Build().SelectDTOsAsync(key, display, defaultKey, defaultDisplay);
        }
    }

    #region Built-in queries
    public partial interface IQueryService
    {
        async Task<IEnumerable<LookupModel<int, string>>> GetAccountCustodianDTOsAsync()
        {
            using var queryBuilder = CreateQueryBuilder<AccountCustodian>();

            return await queryBuilder.Build()
                .SelectDTOsAsync(
                    key: x => x.AccountCustodianId,
                    display: x => x.DisplayName,
                    defaultKey: default,
                    defaultDisplay: UserInterface.Strings.Caption_InputSelect_Placeholder)
                .OrderByWithDefaultFirstAsync();
        }
        
        async Task<IEnumerable<LookupModel<int, string>>> GetAccountDTOsAsync()
        {
            using var queryBuilder = CreateQueryBuilder<Account>()
                .WithDirectRelationship(x => x.AccountNavigation);

            return await queryBuilder.Build()
                .SelectDTOsAsync(
                    key: x => x.AccountId,
                    display: x => x.AccountCode,
                    defaultKey: default,
                    defaultDisplay: UserInterface.Strings.Caption_InputSelect_Placeholder)
                .OrderByWithDefaultFirstAsync();
        }

        async Task<IEnumerable<LookupModel<int, string>>> GetBankTransactionCodeDTOsAsync()
        {
            return await SelectDTOsAsync<BankTransactionCode>(
                    key: x => x.TransactionCodeId,
                    display: x => x.TransactionCode,
                    defaultDisplay: UserInterface.Strings.Caption_InputSelect_Placeholder)
                .OrderByWithDefaultFirstAsync();
        }

        async Task<IEnumerable<LookupModel<int, string>>> GetBrokerTransactionCodeDTOsAsync()
        {
            return await SelectDTOsAsync<BrokerTransactionCode>(
                    key: x => x.TransactionCodeId,
                    display: x => x.DisplayName,
                    defaultDisplay: UserInterface.Strings.Caption_InputSelect_Placeholder)
                .OrderByWithDefaultFirstAsync();
        }

        async Task<IEnumerable<LookupModel<int, string>>> GetCashOrExternalSecurityDTOsAsync()
        {
            using var queryBuilder = CreateQueryBuilder<Security>()
                .WithDirectRelationship(x => x.SecuritySymbols)
                .WithDirectRelationship(x => x.SecurityType)
                .WithIndirectRelationship<SecurityType, SecurityTypeGroup>(x => x.SecurityTypeGroup);

            return await queryBuilder.Build()
                .SelectDTOsAsync(
                    predicate: x => x.SecurityType.SecurityTypeGroup.DepositSource,
                    maxCount: 0,
                    key: x => x.SecurityId,
                    display: x => $"{x.SecuritySymbol ?? "----"} {x.SecurityDescription}",
                    defaultKey: default,
                    defaultDisplay: UserInterface.Strings.Caption_InputSelect_Placeholder)
                .OrderByWithDefaultFirstAsync();
        }

        async Task<IEnumerable<LookupModel<int, string>>> GetCryptocurrencyDTOsAsync()
        {
            using var queryBuilder = CreateQueryBuilder<Security>()
                .WithDirectRelationship(x => x.SecuritySymbols)
                .WithDirectRelationship(x => x.SecurityType);

            return await queryBuilder.Build()
                .SelectDTOsAsync(
                    predicate: x => x.SecurityType.HeldInWallet,
                    maxCount: 0,
                    key: x => x.SecurityId,
                    display: x => $"{x.SecuritySymbol ?? "----"} {x.SecurityDescription}",
                    defaultKey: default,
                    defaultDisplay: UserInterface.Strings.Caption_InputSelect_Placeholder)
                .OrderByWithDefaultFirstAsync();
        }

        async Task<IEnumerable<LookupModel<int, string>>> GetMarketIndexDTOsAsync()
        {
            return await SelectDTOsAsync<MarketIndex>(
                    key: x => x.IndexId,
                    display: x => x.IndexCode,
                    defaultDisplay: UserInterface.Strings.Caption_InputSelect_Placeholder)
                .OrderByWithDefaultFirstAsync();
        }

        async Task<IEnumerable<LookupModel<int, string>>> GetSecurityTypeDTOsAsync()
        {
            return await SelectDTOsAsync<SecurityType>(
                    key: x => x.SecurityTypeId,
                    display: x => x.SecurityTypeName,
                    defaultDisplay: UserInterface.Strings.Caption_InputSelect_Placeholder)
                .OrderByWithDefaultFirstAsync();
        }

        async Task<IEnumerable<LookupModel<int, string>>> GetSecurityTypeGroupDTOsAsync()
        {
            return await SelectDTOsAsync<SecurityTypeGroup>(
                    key: x => x.SecurityTypeGroupId,
                    display: x => x.SecurityTypeGroupName,
                    defaultDisplay: UserInterface.Strings.Caption_InputSelect_Placeholder)
                .OrderByWithDefaultFirstAsync();
        }

        async Task<IEnumerable<LookupModel<int, string>>> GetTransactableSecurityDTOsAsync()
        {
            using var queryBuilder = CreateQueryBuilder<Security>()
                .WithDirectRelationship(x => x.SecuritySymbols)
                .WithDirectRelationship(x => x.SecurityType)
                .WithIndirectRelationship<SecurityType, SecurityTypeGroup>(x => x.SecurityTypeGroup);

            return await queryBuilder.Build()
                .SelectDTOsAsync(
                    predicate: x => x.SecurityType.SecurityTypeGroup.Transactable,
                    maxCount: 0,
                    key: x => x.SecurityId,
                    display: x => $"{x.SecuritySymbol ?? "----"} {x.SecurityDescription}",
                    defaultKey: default,
                    defaultDisplay: UserInterface.Strings.Caption_InputSelect_Placeholder)
                .OrderByWithDefaultFirstAsync();
        }

        async Task<IEnumerable<LookupModel<int, string>>> GetModelAttributeMemberDTOsAsync(
            int attributeId)
        {
            using var queryBuilder = CreateQueryBuilder<ModelAttributeMember>()
                .WithDirectRelationship(x => x.Country)
                .WithDirectRelationship(x => x.SecurityType)
                .WithDirectRelationship(x => x.SecurityTypeGroup);

            return await queryBuilder.Build()
                .SelectDTOsAsync(
                    predicate: x => x.AttributeId == attributeId,
                    maxCount: 0,
                    key: x => x.AttributeMemberId,
                    display: x => DisplayFor(x),
                    defaultDisplay: UserInterface.Strings.Caption_InputSelect_Placeholder)
                .OrderByWithDefaultFirstAsync();
        }
    }

    #endregion

    #region Static helper methods
    public partial interface IQueryService
    {
        public static string DisplayFor(ModelAttributeMember attributeMember)
        {
            if (attributeMember.Country is not null)
                return $"{attributeMember.Country.DisplayName} ({attributeMember.Country.IsoCode3})";

            return attributeMember.DisplayName;
        }

        /// <summary>
        /// Gets the array of string codes representing the supported <see cref="ModelAttributeScope"/> 
        /// for this type.
        /// </summary>
        /// <typeparam name="T"/>The class to be checked.</typeparam>
        /// <returns>A <see cref="string[]"/> containing the codes representing each supported 
        /// <see cref="ModelAttributeScopeCode"/> member, or an empty array.</returns>
        public static string[] GetSupportedAttributeScopeCodes<T>() 
            where T : IAttributeEntryViewModel =>
            typeof(T).GetCustomAttribute<ModelAttributeSupportAttribute>()
            ?.SupportedScopes.ToStringArray() ?? Array.Empty<string>();
    }
    #endregion
    static class QueryServiceExtension
    {
        /// <summary>
        /// Orders this enumerbale collection by the records with the default <typeparamref name="TKey"/> 
        /// value first, then by the <typeparamref name="TDisplay"/> display value of the record.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TDisplay"></typeparam>
        /// <param name="lookupModelQueryTask"></param>
        /// <returns>A <see cref="Task"/> representing an asynchronous query call and subsequent re-ordering of 
        /// the returned results.</returns>
        public static async Task<IEnumerable<LookupModel<TKey, TDisplay>>>
            OrderByWithDefaultFirstAsync<TKey, TDisplay>(
                this Task<IEnumerable<LookupModel<TKey, TDisplay>>> lookupModelQueryTask)
            => (await lookupModelQueryTask)
                .OrderByDescending(x => x.Key.Equals(default(TKey)))
                .ThenBy(x => x.Display)
                .ToList();
    }
}
