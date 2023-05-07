using System;
using System.Linq.Expressions;

namespace NjordFinance.EntityModelService.Query
{
    /// <summary>
    /// Represents a utility class for constructing simple and complex reads of the model data store.
    /// </summary>
    /// <typeparam name="TSource">The source model type. Relationships are expressed 
    /// using this type as the starting point.</typeparam>
    public interface IQueryBuilder<TSource> : IDisposable//, IQueryDataStore<TSource>
        where TSource : class, new()
    {
        /// <summary>
        /// Appends a direct relationship to the query.
        /// </summary>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="navigationPropertyPath"></param>
        /// <returns>The <see cref="IQueryBuilder{TSource}"/> instance, configured to include 
        /// a direct model relationship from the <typeparamref name="TSource"/> source.</returns>
        IQueryBuilder<TSource> WithDirectRelationship<TProperty>(
            Expression<Func<TSource, TProperty>> navigationPropertyPath);

        /// <summary>
        /// Appends an indirect relationship to the query.
        /// </summary>
        /// <typeparam name="TPreviousProperty"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="navigationPropertyPath"></param>
        /// <returns>The <see cref="IQueryBuilder{TSource}"/> instance, configured to include 
        /// an indirect model relationship from the <typeparamref name="TSource"/> source.</returns>
        IQueryBuilder<TSource> WithIndirectRelationship<TPreviousProperty, TProperty>(
            Expression<Func<TPreviousProperty, TProperty>> navigationPropertyPath)
            where TPreviousProperty : class, new()
            where TProperty : class, new();

        /// <summary>
        /// Builds a new instance impleemtning <see cref="IQueryBuilder{TSource}"/> from this 
        /// configuration.
        /// </summary>
        /// <returns>An <see cref="IQueryBuilder{TSource}"/> instance.</returns>
        IQueryDataStore<TSource> Build();
    }
}
