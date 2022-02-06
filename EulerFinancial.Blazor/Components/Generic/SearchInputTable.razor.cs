﻿using Ichosoft.DataModel.Expressions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EulerFinancial.Blazor.Components.Generic
{
    public partial class SearchInputTable<TModel> : LocalizedComponent
    {
        /// <summary>
        /// Gets or sets the collection of searchables fields for the type: <typeparamref name="TModel"/>.
        /// </summary>
        [Parameter]
        public IEnumerable<ISearchableMemberMetadata> SearchFields { get; set; }

        /// <summary>
        /// Gets or sets the collection of allowable <see cref="ComparisonOperator"/> for
        /// the type: <typeparamref name="TModel"/>.
        /// </summary>
        [Parameter]
        public IEnumerable<ComparisonOperator> ComparisonOperators { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="IExpressionBuilder"/> instance for this component.
        /// </summary>
        [Parameter]
        public IExpressionBuilder ExpressionBuilder { get; set; }

        /// <summary>
        /// Gets or sets the delegate for handling search submission events from this component.
        /// </summary>
        [Parameter]
        public EventCallback<SearchSubmittedEventArgs<TModel>> OnSearchClick { get; set; }

        /// <summary>
        /// The field defining the search error message text.
        /// </summary>
        private string _searchErrorMessage = string.Empty;

        /// <summary>
        /// Gets or sets the current member to be used as a parameter when a search is submitted.
        /// </summary>
        private string CurrentSearchMemberName { get; set; }

        /// <summary>
        /// Gets or sets the string representation of the value used when this index is searched.
        /// </summary>
        private string SearchValue { get; set; }

        /// <summary>
        /// Gets whether the last search submitted to this index had valid syntax.
        /// </summary>
        private bool SearchIsValid { get; set; }

        /// <summary>
        /// Gets or sets the search error message for this component.
        /// </summary>
        private string SearchErrorMessage
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

        /// <summary>
        /// Gets or sets the current operator used when a search is submitted.
        /// </summary>
        private ComparisonOperator CurrentSearchOperator { get; set; }

        /// <inheritdoc/>
        protected override Task OnInitializedAsync()
        {
            if (SearchFields.Any())
                CurrentSearchMemberName = SearchFields.First().QualifiedMemberName;

            if (ComparisonOperators.Any())
                CurrentSearchOperator = ComparisonOperators.First();

            return base.OnInitializedAsync();
        }

        /// <summary>
        /// Handles the search submitted event of this component.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        private async Task SearchSubmitted(MouseEventArgs args)
        {
            if (TryCreateSearchExpression(
                out Expression<Func<TModel, bool>> expression,
                out string errorMessage))
            {
                SearchErrorMessage = string.Empty;
                SearchSubmittedEventArgs<TModel> searchArgs = new(args, expression);

                await OnSearchClick.InvokeAsync(searchArgs);
            }
            else
            {
                SearchErrorMessage = errorMessage;
            }
        }

        /// <summary>
        /// Attempts to create a <see cref="Expression{Func{TModel, bool}}"/> from the entered
        /// parameters.
        /// </summary>
        /// <param name="expression">The generated search expression if successful, else null.</param>
        /// <param name="errorMessage">The resulting error message, if an exception was thrown.</param>
        /// <returns>True if an expression was successfully created, else false.</returns>
        private bool TryCreateSearchExpression(
            out Expression<Func<TModel, bool>> expression, out string errorMessage)
        {
            try
            {
                var param = ExpressionBuilder
                    .CreateQueryParameter<TModel>(
                        SearchFields.FirstOrDefault(s => s.QualifiedMemberName == CurrentSearchMemberName),
                        CurrentSearchOperator,
                        SearchValue);

                expression = ExpressionBuilder.GetExpression(param);
                errorMessage = null;

                return true;
            }
            catch (Exception e)
            {
                expression = null;
                errorMessage = e.Message;

                return false;
            }
        }
    }
}
