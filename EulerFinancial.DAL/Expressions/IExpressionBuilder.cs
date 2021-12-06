using EulerFinancial.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace EulerFinancial.Expressions
{
    /// <summary>
    /// Represents a helper class for building filter expressions.
    /// </summary>
    public interface IExpressionBuilder
    {
        /// <summary>
        /// Creates a reference collection of search comparison operators and their display names.
        /// </summary>
        /// <returns>A <see cref="IDictionary{TKey, TValue}"/> where <see cref="IDictionary{TKey, TValue}.Keys"/> 
        /// are <see cref="ComparisonOperator"/> and <see cref="IDictionary{TKey, TValue}.Values"/> are string their string representations.</returns>
        IDictionary<ComparisonOperator, string> GetComparisonOperatorLookup();

        /// <summary>
        /// Creates a dynamic <see cref="Expression{TDelegate}"/> of <see cref="Func{T, TResult}"/>
        /// where <typeparamref name="TModel"/> is the query object type and <paramref name="queryParameter"/> 
        /// is the instance containing the query parameter information.
        /// </summary>
        /// <typeparamref name="TModel"></typeparamref>
        /// <param name="queryParameter">The instance carrying the query parameter information.</param>
        /// <returns>An <see cref="Expression{TDelegate}"/> with <typeparamref name="TModel"/> input type and <see cref="bool"/> return type.</returns>
        Expression<Func<TModel, bool>> GetExpression<TModel>(IQueryParameter<TModel> queryParameter);

        /// <summary>
        /// Creates a reference collection of searchable fields that are members or nested members 
        /// of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IEnumerable<ModelMetadata> GetSearchableMetadata<T>()
            where T : class, new();
    }
}
