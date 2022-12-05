using NjordFinance.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using NjordFinance.ModelMetadata;
using NjordFinance.ModelService.Query;
using NjordFinance.Model.Annotations;
using System.Reflection;
using NjordFinance.Model.ViewModel.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.Update;

namespace NjordFinance.ModelService
{

    /// <summary>
    /// Represents a read-only service for extracting common reference lists.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public partial interface IReferenceDataService
    {
        /// <summary>
        /// Gets the collection of <see cref="MarketIndexPriceCode"/> values.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{T}"/> containing each defined value for
        /// <see cref="MarketIndexPriceCode"/>.</returns>
        Task<IEnumerable<MarketIndexPriceCode>> MarketIndexPriceCodesAsync();
        
        /// <summary>
        /// Gets the collection representing <see cref="AccountCustodian"/> models as a reference list.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="AccountCustodian"/> models, including 
        /// a default lookup entry.</returns>
        Task<IEnumerable<AccountCustodian>> AccountCustodianListAsync();

        /// <summary>
        /// Gets the collection representing <see cref= "Account" /> models as a reference list.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="Account"/> models, including 
        /// a default lookup entry.</returns>
        Task<IEnumerable<Account>> AccountListAsync();

        /// <summary>
        /// Gets the collection representing <see cref="Security"/> models as a reference list, 
        /// restricted to securities that are valid end-points for brokerage transactions.
        /// </summary>
        /// <returns>An <see cref="IList{T}"/> of <see cref="Security"/> models, including 
        /// a default lookup entry.</returns>
        Task<IEnumerable<Security>> CashOrExternalSecurityListAsync();

        /// <summary>
        /// Gets the collection representing <see cref="Country"/> models as a reference list.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="Country"/> models, including 
        /// a default lookup entry.</returns>
        Task<IEnumerable<Country>> CountryListAsync();

        /// <summary>
        /// Creates a new instance implementing <see cref="IQueryBuilder{TSource}"/> where 
        /// <typeparamref name="TSource"/> is the target object.
        /// </summary>
        /// <typeparam name="TSource">Is the target of the query built using this interface.</typeparam>
        /// <returns>An <see cref="IQueryBuilder{TSource}"/> for <typeparamref name="TSource"/> models.</returns>
        /// <remarks>Calls to this method should use its <see cref="IDisposable"/> implementation.</remarks>
        IQueryBuilder<TSource> CreateQueryBuilder<TSource>()
            where TSource : class, new();

        /// <summary>
        /// Gets the collection representing <see cref="Security"/> models as a reference list, 
        /// restricted to securities that are crypto-currencies or storable in a digital wallet.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="Security"/> models, including 
        /// a default lookup entry.</returns>
        Task<IEnumerable<Security>> CryptocurrencyListAsync();

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

        /// <summary>
        /// Gets the collection representing <see cref="ModelAttribute"/> models as a reference list, 
        /// restricted to entries with the given <see cref="ModelAttributeScopeCode"/>.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="LookupModel"/> models, including 
        /// a default lookup entry.</returns>
        Task<IEnumerable<ModelAttribute>> ModelAttributeListAsync(ModelAttributeScopeCode scopeCode);

        /// <summary>
        /// Gets the collection representing <see cref="ModelAttributeMember"/> models as a reference list, 
        /// restricted to the given <see cref="ModelAttribute.AttributeId"/>.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="LookupModel"/> models, including 
        /// a default lookup entry.</returns>
        Task<IEnumerable<ModelAttributeMember>> ModelAttributeMemberListAsync(int attributeId);

        /// <summary>
        /// Gets the collection representing <see cref="Security"/> models as a reference list, restricted to 
        /// securities that are valid subjects for brokerage transactions.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="LookupModel"/> models, including 
        /// a default lookup entry.</returns>
        Task<IEnumerable<Security>> TransactableSecurityListAsync();

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
    }

    public partial interface IReferenceDataService
    {
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
}
