using Ichosys.DataModel.Expressions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Ozym.Web.Services
{
    public class SearchService<T> : ISearchService<T>
    {
        public SearchService(IExpressionBuilder expressionBuilder)
        {
            if (expressionBuilder is null)
                throw new ArgumentNullException(paramName: nameof(expressionBuilder));

            ExpressionBuilder = expressionBuilder;

            SearchFields = ExpressionBuilder.GetSearchableMembers<T>();
            ComparisonOperators = ExpressionBuilder.GetComparisonOperators();
        }

        /// <inheritdoc/>
        public IExpressionBuilder ExpressionBuilder { get; init; }

        /// <inheritdoc/>
        public IEnumerable<ISearchableMemberMetadata> SearchFields { get; init; }

        /// <inheritdoc/>
        public IEnumerable<ComparisonOperator> ComparisonOperators { get; init; }

        /// <inheritdoc/>
        public Expression<Func<T, bool>> CurrentExpression { get; set; } = x => true;
    }
}
