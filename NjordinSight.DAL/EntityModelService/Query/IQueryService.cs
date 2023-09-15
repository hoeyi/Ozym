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
