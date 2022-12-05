using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NjordFinance.ModelService.Query
{
    /// <summary>
    /// Represents a utility class for constructing complex reads of the model data store.
    /// </summary>
    /// <typeparam name="TSource">The origin model type. Direct relationships are expressed 
    /// using this type as the starting point.</typeparam>
    public interface IQueryBuilder<TSource> : IDisposable
        where TSource : class, new()
    {
        /// <summary>
        /// Appends a direct relationship to the query.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="navigationPropertyPath">The path to the join model.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        IQueryBuilder<TSource> WithDirectRelationship<TProperty>(
            Expression<Func<TSource, TProperty>> navigationPropertyPath);

        /// <summary>
        /// Appends an indirect relationship to the query.
        /// </summary>
        /// <typeparam name="TPreviousProperty"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="navigationPropertyPath"></param>
        /// <returns></returns>
        IQueryBuilder<TSource> WithIndirectRelationship<TPreviousProperty, TProperty>(
            Expression<Func<TPreviousProperty, TProperty>> navigationPropertyPath)
            where TPreviousProperty : class, new()
            where TProperty : class, new();

        /// <summary>
        /// Executes the select query and returns the data to the caller as an 
        /// <see cref="IEnumerable{T}"/> collection.
        /// </summary>
        /// <param name="predicate">The delegate specifying which models will be selected.</param>
        /// <param name="maxCount">The maximum record count to return. The default of zero returns 
        /// all records.</param>
        /// <returns>A task whose result is a collection of <typeparamref name="TSource"/> 
        /// implementing <see cref="IEnumerable{T}"/>.</returns>
        Task<IEnumerable<TSource>> SelectWhereAsync(
            Expression<Func<TSource, bool>> predicate, int maxCount = 0);

        /// <summary>
        /// Executes a select query return a key-value representation of a record. Only the 
        /// fields matching the <paramref name="key"/> and <paramref name="display"/> parameters 
        /// are included in the query.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="predicate"></param>
        /// <param name="maxCount"></param>
        /// <param name="key"></param>
        /// <param name="display"></param>
        /// <param name="defaultKey"></param>
        /// <param name="defaultDisplay"></param>
        /// <returns></returns>
        Task<IEnumerable<LookupModel<TKey, TValue>>> SelectDTOsAsync<TKey, TValue>(
            Expression<Func<TSource, bool>> predicate,
            int maxCount,
            Expression<Func<TSource, TKey>> key,
            Expression<Func<TSource, TValue>> display,
            TKey defaultKey = default,
            TValue defaultDisplay = default);
    }
}
