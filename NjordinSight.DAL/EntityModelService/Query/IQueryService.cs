using NjordinSight.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using NjordinSight.EntityModel.Annotations;
using System.Reflection;
using System.Linq;
using NjordinSight.DataTransfer.Common.Generic;
using NjordinSight.DataTransfer;
using Microsoft.Data.SqlClient;
using NjordinSight.DataTransfer.Common;
using NjordinSight.DataTransfer.Common.Query;
using NjordinSight.EntityModel.ConstraintType;

namespace NjordinSight.EntityModelService.Query
{
    /// <summary>
    /// Represents a read-only service for extracting DTOs representing foreign-key relationships.
    /// </summary>
    public partial interface IQueryService
    {
        /// <summary>
        /// Converts the given <typeparamref name="TEnum"/> members to a key-value map 
        /// for display values.
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <typeparam name="TKey">The key type for the resulting map.</typeparam>
        /// <typeparam name="TValue">The value type for the resulting map.</typeparam>
        /// <param name="predicate">Predicate to filter the member results.</param>
        /// <param name="key">Expression describing the method to assign the key value for each record.</param>
        /// <param name="display">Expression describing the method to assign the display value for each record.</param>
        /// <param name="placeHolderDelegate">Delegate for creating a placehold/defult entry.</param>
        /// <returns>A collection of key-value assignments, where the value is the display value 
        /// for the record.</returns>
        IDictionary<TKey, TValue> CreateEnumerableDisplayMap<TEnum, TKey, TValue>(
            Func<TEnum, bool> predicate,
            Expression<Func<TEnum, TKey>> key,
            Expression<Func<TEnum, TValue>> display,
            Func<KeyValuePair<TKey, TValue>> placeHolderDelegate = null)
            where TEnum : struct, Enum;

        /// <summary>
        /// Gets the collection of <typeparamref name="T"/> models from the data store matching the 
        /// predicate limited to the given page number and size.
        /// </summary>
        /// <param name="predicate">The <see cref="Expression{Func{T}}"/> used to determine results.</param>
        /// <param name="pageNumber">Specifies the index of the page to return.</param>
        /// <param name="pageSize">Specifies the maximum number of records per page.</param>
        /// <returns>A <see cref="IEnumerable{T}"/> representing the records matching the predicate, 
        /// limited to a maximum count.</returns>
        Task<(IEnumerable<T>, PaginationData)> GetRecordSetAsync<T>(
            Expression<Func<T, bool>> predicate,
            int pageNumber = 1,
            int pageSize = 20)
            where T : class, new();

        /// <summary>
        /// Gets the collection of <typeparamref name="T"/> models from the data store matching the 
        /// predicate limited to the given page number and size.
        /// </summary>
        /// <param name="predicate">The <see cref="Expression{Func{T}}"/> used to determine results.</param>
        /// <param name="pageNumber">Specifies the index of the page to return.</param>
        /// <param name="pageSize">Specifies the maximum number of records per page.</param>
        /// <param name="sortBy">Optional expression defining the memeber to sort results by.</param>
        /// <param name="sortOrder">Optional <see cref="SortOrder"/> defining the sort direction.</param>
        /// <returns>A <see cref="IEnumerable{T}"/> representing the records matching the predicate, 
        /// limited to a maximum count.</returns>
        Task<(IEnumerable<T>, PaginationData)> GetRecordSetAsync<T, TKey>(
            Expression<Func<T, bool>> predicate,
            int pageNumber = 1,
            int pageSize = 20,
            Expression<Func<T, TKey>> sortBy = null,
            SortOrder sortOrder = SortOrder.Unspecified)
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
        /// Gets the collection of built-in query methods.
        /// </summary>
        IBuiltInQuery BuiltIn { get; }

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
        async Task<IEnumerable<KeyValuePair<TKey, TValue>>> SelectDTOsAsync<TSource, TKey, TValue>(
            Expression<Func<TSource, TKey>> key,
            Expression<Func<TSource, TValue>> display,
            TKey defaultKey = default,
            TValue defaultDisplay = default)
            where TSource : class, new()
        {
            using var queryBuilder = CreateQueryBuilder<TSource>();

            return await queryBuilder.Build().SelectDTOsAsync(key, display, defaultKey, defaultDisplay);
        }
    }
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
        public static async Task<IEnumerable<KeyValuePair<TKey, TDisplay>>>
            OrderByWithDefaultFirstAsync<TKey, TDisplay>(
                this Task<IEnumerable<KeyValuePair<TKey, TDisplay>>> lookupModelQueryTask)
            => (await lookupModelQueryTask)
                .OrderByDescending(x => x.Key.Equals(default(TKey)))
                .ThenBy(x => x.Value)
                .ToList();
    }
}
