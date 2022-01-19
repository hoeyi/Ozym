using Microsoft.AspNetCore.Components;
using Ichosoft.DataModel.Expressions;
using Ichosoft.DataModel;
using System.Globalization;
using System.Collections.Generic;

namespace EulerFinancial.Blazor.Shared
{
    /// <summary>
    /// Represents a searchable index of a model collection.
    /// </summary>
    public partial class ModelIndexView : LocalizedComponent
    {
        private string _searchErrorMessage;

        /// <summary>
        /// Gets or sets the <see cref="IExpressionBuilder"/> for this component.
        /// </summary>
        [Inject]
        protected IExpressionBuilder ExpressionBuilder { get; set; }

        /// <summary>
        /// Gets or sets the collection of allowable <see cref="ComparisonOperator"/> for 
        /// searching this index.
        /// </summary>
        protected IEnumerable<ComparisonOperator> ComparisonOperators { get; set; }

        /// <summary>
        /// Gets or sets the collection of searchables fields when this index is searched.
        /// </summary>
        protected IEnumerable<ISearchableMemberMetadata> SearchFields { get; set; }

        /// <summary>
        /// Gets or sets the current operator used in searches in this view.
        /// </summary>
        protected ComparisonOperator SearchOperator { get; set; }
        
        /// <summary>
        /// Gets or sets the current member to be used as a parameter for searches in this view. 
        /// </summary>
        protected string SearchMemberName { get; set;  }

        /// <summary>
        /// Gets or sets the string representation of the value used when this index is searched.
        /// </summary>
        protected string SearchValue { get; set; }

        /// <summary>
        /// Gets whether the last search submitted to this index had valid syntax.
        /// </summary>
        protected bool SearchIsValid { get; private set; }

        /// <summary>
        /// Gets or sets the search error message for this component.
        /// </summary>
        protected string SearchErrorMessage
        {
            get { return _searchErrorMessage; }
            set
            {
                if (_searchErrorMessage != value)
                {
                    _searchErrorMessage = value;
                    SearchIsValid = string.IsNullOrEmpty(_searchErrorMessage);
                }
            }
        }
    }
}
