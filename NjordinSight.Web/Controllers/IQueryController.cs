using Microsoft.AspNetCore.Mvc;
using NjordinSight.EntityModelService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NjordinSight.Web.Controllers
{
    /// <summary>
    /// Represents a controller for handling read-only query requests of the data store.
    /// </summary>
    public interface IQueryController
    {
        /// <summary>
        /// Returns a single <typeparamref name="TSource"/> from the data store, or throws an exception 
        /// if the sequence does not return a single result.
        /// </summary>
        /// <typeparam name="TSource">The model type to return.</typeparam>
        /// <param name="predicate">The expression to match the <typeparamref name="T"/>.</param>
        /// <param name="path">The path for the navigation property to include. 
        /// The default is null, which does not load related data.</param>
        /// <returns>The <typeparamref name="T"/> instance that matches the 
        /// <paramref name="predicate"/>.</returns>
        Task<ActionResult<TSource>> GetSingleAsync<TSource>(
            Expression<Func<TSource, bool>> predicate,
            Expression<Func<TSource, object>> path = null)
            where TSource : class, new();

        /// <summary>
        /// Returns a collection of <typeparamref name="TSource"/> models from the data store.
        /// </summary>
        /// <typeparam name="TSource">The model type to return.</typeparam>
        /// <param name="predicate">The expression to match the <typeparamref name="TSource"/>.</param>
        /// <param name="path">The path for the navigation property to include. 
        /// The default is null, which does not load related data.</param>
        /// <returns>The <typeparamref name="TSource"/> instance that matches the 
        /// <paramref name="predicate"/>.</returns>
        Task<ActionResult<IEnumerable<TSource>>> GetManyAsync<TSource>(
            Expression<Func<TSource, bool>> predicate, Expression<Func<TSource, object>> path = null)
            where TSource : class, new();

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
        /// <returns>A task representing an asynchronous query and DTO-mapping. The task result is an <see cref="ActionResult"/>
        /// containing an <see cref="IEnumerable{T}"/> of key-value records represent a foregin key reference.</returns>
        Task<ActionResult<IEnumerable<LookupModel<TKey, TValue>>>> GetDtosAsync<TSource, TKey, TValue>(
            Expression<Func<TSource, TKey>> key,
            Expression<Func<TSource, TValue>> display,
            TKey defaultKey = default,
            TValue defaultDisplay = default)
            where TSource : class, new();

        /// <summary>
        /// Selects all account custodian lookup DTOs.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing an asynchronous select query for 
        /// whose result is a collection of <see cref="LookupModel{TKey, TDisplay}"/> records.</returns>
        Task<ActionResult<IEnumerable<LookupModel<int, string>>>> GetAccountCustodianDTOsAsync();

        /// <summary>
        /// Selects all account lookup DTOs.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing an asynchronous select query for 
        /// whose result is a collection of <see cref="LookupModel{TKey, TDisplay}"/> records.</returns>
        Task<ActionResult<IEnumerable<LookupModel<int, string>>>> GetAccountDTOsAsync();

        /// <summary>
        /// Selects all account custodian DTOs.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing an asynchronous select query for 
        /// whose result is a collection of <see cref="LookupModel{TKey, TDisplay}"/> records.</returns>
        Task<ActionResult<IEnumerable<LookupModel<int, string>>>> GetBankTransactionCodeDTOsAsync();

        /// <summary>
        /// Selects all broker transaction code lookup DTOs.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing an asynchronous select query for 
        /// whose result is a collection of <see cref="LookupModel{TKey, TDisplay}"/> records.</returns>
        Task<ActionResult<IEnumerable<LookupModel<int, string>>>> GetBrokerTransactionCodeDTOsAsync();

        /// <summary>
        /// Selects all security lookup DTOs that represent internal or external security deposit 
        /// locations.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing an asynchronous select query for 
        /// whose result is a collection of <see cref="LookupModel{TKey, TDisplay}"/> records.</returns>
        Task<ActionResult<IEnumerable<LookupModel<int, string>>>> GetCashOrExternalSecurityDTOsAsync();

        /// <summary>
        /// Selects all security lookup DTOs that represent cryptocurrencies.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing an asynchronous select query for 
        /// whose result is a collection of <see cref="LookupModel{TKey, TDisplay}"/> records.</returns>
        Task<ActionResult<IEnumerable<LookupModel<int, string>>>> GetCryptocurrencyDTOsAsync();

        /// <summary>
        /// Selects all market index lookup DTOs.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing an asynchronous select query for 
        /// whose result is a collection of <see cref="LookupModel{TKey, TDisplay}"/> records.</returns>
        Task<ActionResult<IEnumerable<LookupModel<int, string>>>> GetMarketIndexDTOsAsync();

        /// <summary>
        /// Selects all security type lookup DTOs.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing an asynchronous select query for 
        /// whose result is a collection of <see cref="LookupModel{TKey, TDisplay}"/> records.</returns>
        Task<ActionResult<IEnumerable<LookupModel<int, string>>>> GetSecurityTypeDTOsAsync();

        /// <summary>
        /// Selects all security type group lookup DTOs.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing an asynchronous select query for 
        /// whose result is a collection of <see cref="LookupModel{TKey, TDisplay}"/> records.</returns>
        Task<ActionResult<IEnumerable<LookupModel<int, string>>>> GetSecurityTypeGroupDTOsAsync();

        /// <summary>
        /// Selects all security lookup DTOs that are transactable in brokerage accounts.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing an asynchronous select query for 
        /// whose result is a collection of <see cref="LookupModel{TKey, TDisplay}"/> records.</returns>
        Task<ActionResult<IEnumerable<LookupModel<int, string>>>> GetTransactableSecurityDTOsAsync();

        /// <summary>
        /// Selects all model attribute member lookup DTOs who are children of the attribute 
        /// identified by <paramref name="attributeId"/>.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing an asynchronous select query for 
        /// whose result is a collection of <see cref="LookupModel{TKey, TDisplay}"/> records.</returns>
        Task<ActionResult<IEnumerable<LookupModel<int, string>>>> GetModelAttributeMemberDTOsAsync(
            int attributeId);

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
        /// <returns>An <see cref="ActionResult"/> wrapping the collection of DTOs.</returns>
        async Task<ActionResult<IEnumerable<LookupModel<TKey, TValue>>>> SelectDTOsFromEnum<TEnum, TKey, TValue>(
            Func<TEnum, bool> predicate,
            Expression<Func<TEnum, TKey>> key,
            Expression<Func<TEnum, TValue>> display,
            Func<LookupModel<TKey, TValue>> placeHolderDelegate = null)
            where TEnum : struct, Enum
        {
            var t = Task.Run(() => SelectDTOSFromEnum(predicate, key, display, placeHolderDelegate));

            return new ActionResult<IEnumerable<LookupModel<TKey, TValue>>>(await t);
        }
        
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
        /// <returns>A collection of DTOs.</returns>
        private static IEnumerable<LookupModel<TKey, TValue>> SelectDTOSFromEnum<TEnum, TKey, TValue>(
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

            if (placeHolderDelegate is not null)
            {
                var placeHolder = placeHolderDelegate.Invoke();
                results.Insert(0, placeHolder);
            }

            return results;
        }
    }
}
