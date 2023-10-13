using NjordinSight.DataTransfer;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NjordinSight.EntityModelService.Query
{
    /// <summary>
    /// Represents a query data store with pre-configured relationship inclusions. 
    /// </summary>
    /// <typeparam name="TSource">The type representing the base type for the query.</typeparam>
    public interface IQueryDataStore<TSource>
        where TSource : class, new()
    {
        /// <summary>
        /// Selects records matching the given predicate and page parameters.
        /// </summary>
        /// <param name="predicate">The predicate to filter returned records.</param>
        /// <param name="pageNumber">The index of the page to return.</param>
        /// <param name="pageSize">The record limit per page.</param>
        /// <returns>A task representing an asynchronous query operation.</returns>
        Task<(IEnumerable<TSource>, PaginationData)> SelectAsync(
            Expression<Func<TSource, bool>> predicate,
            int pageNumber = 1,
            int pageSize = 20);

        /// <summary>
        /// Executes a select query returning a key-value representation of <typeparamref name="TSource"/> 
        /// records.. Only the fields matching the <paramref name="key"/> and <paramref name="display"/> parameters 
        /// are included in the query.
        /// </summary>
        /// <typeparamref name="TSource"/>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="key">Expression indicating the attribute to use as the key.</param>
        /// <param name="display">Expression indicating the attribute to use for display.</param>
        /// <param name="defaultKey">Default key value to use for placeholder record.</param>
        /// <param name="defaultDisplay">Default display value to use for the placeholder record.</param>
        /// <returns>A task representing an asynchronous query and DTO-mapping. The task result is an
        /// <see cref="IEnumerable{T}"/> containing key-value records represent a foregin key reference.</returns>
        Task<IEnumerable<KeyValuePair<TKey, TValue>>> SelectDTOsAsync<TKey, TValue>(
            Expression<Func<TSource, TKey>> key,
            Expression<Func<TSource, TValue>> display,
            TKey defaultKey = default,
            TValue defaultDisplay = default);

        /// <summary>
        /// Executes a select query returning a key-value representation of <typeparamref name="TSource"/> 
        /// records.. Only the fields matching the <paramref name="key"/> and <paramref name="display"/> parameters 
        /// are included in the query.
        /// </summary>
        /// <typeparamref name="TSource"/>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="predicate">Predicate filtering the returned record set.</param>
        /// <param name="key">Expression indicating the attribute to use as the key.</param>
        /// <param name="display">Expression indicating the attribute to use for display.</param>
        /// <param name="defaultKey">Default key value to use for placeholder record.</param>
        /// <param name="defaultDisplay">Default display value to use for the placeholder record.</param>
        /// <param name="pageNumber">Index of the page number to retrieve.</param>
        /// <param name="pageSize">Record limit per page.</param>
        /// <returns>A task representing an asynchronous query and DTO-mapping. The task result is an
        /// <see cref="IEnumerable{T}"/> containing key-value records represent a foregin key reference, 
        /// and a <see cref="PaginationData"/> instance describing the data store record set 
        /// and returned records.</returns>
        Task<(IEnumerable<KeyValuePair<TKey, TValue>>, PaginationData)> SelectDTOsAsync<TKey, TValue>(
            Expression<Func<TSource, bool>> predicate,
            Expression<Func<TSource, TKey>> key,
            Expression<Func<TSource, TValue>> display,
            TKey defaultKey = default,
            TValue defaultDisplay = default,
            int pageNumber = 1,
            int pageSize = 20);
    }
}
