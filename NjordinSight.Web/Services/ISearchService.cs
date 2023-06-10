using Ichosys.DataModel.Expressions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace NjordinSight.Web.Services
{
    /// <summary>
    /// Represents a service that constructs search queries from user input.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ISearchService<T>
    {
        /// <summary>
        /// Gets or sets the last used search expression. Initial value evaluates to true.
        /// </summary>
        Expression<Func<T, bool>> CurrentExpression { get; set; }

        /// <summary>
        /// Gets the collection of <see cref="ComparisonOperator"/> entries valid 
        /// for <typeparamref name="T"/>.
        /// </summary>
        IEnumerable<ComparisonOperator> ComparisonOperators { get; init; }

        /// <summary>
        /// Gets the expression builder for this service.
        /// </summary>
        IExpressionBuilder ExpressionBuilder { get; init; }

        /// <summary>
        /// Gets the metadata collection for searchable members of <typeparamref name="T"/>.
        /// </summary>
        IEnumerable<ISearchableMemberMetadata> SearchFields { get; init; }
    }
}