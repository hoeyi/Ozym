using Ichosys.DataModel.Expressions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using NjordFinance.Web.Components.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace NjordFinance.Web.Components
{
    public partial class SearchInputTable<TModel> : LocalizableComponent
    {
        /// <summary>
        /// Gets or sets the collection of searchables fields for the type: <typeparamref name="TModel"/>.
        /// </summary>
        [Parameter]
        public IEnumerable<ISearchableMemberMetadata> SearchFields { get; set; } 
            = Array.Empty<ISearchableMemberMetadata>();

        /// <summary>
        /// Gets or sets the collection of allowable <see cref="ComparisonOperator"/> for
        /// the type: <typeparamref name="TModel"/>.
        /// </summary>
        [Parameter]
        public IEnumerable<ComparisonOperator> ComparisonOperators { get; set; }
            = Array.Empty<ComparisonOperator>();

        /// <summary>
        /// Gets or sets the <see cref="IExpressionBuilder"/> instance for this component.
        /// </summary>
        [Parameter]
        public IExpressionBuilder? ExpressionBuilder { get; set; }

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
        /// Gets whether the last search submitted to this index had valid syntax.
        /// </summary>
        private bool SearchIsValid { get; set; }

        /// <summary>
        /// Gets or sets the search error message for this component.
        /// </summary>
        private string InvalidSearchMessage
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
        /// Gets or sets the current member to be used as a parameter when a search is submitted.
        /// </summary>
        private string? QualifiedMemberName { get; set; }

        /// <summary>
        /// Gets or sets the current operator used when a search is submitted.
        /// </summary>
        private ComparisonOperator SearchOperator { get; set; }

        /// <summary>
        /// Gets or sets the string representation of the value used when this index is searched.
        /// </summary>
        private string? SearchValue { get; set; }

        /// <inheritdoc/>
        protected override async Task OnInitializedAsync()
        {
            if (SearchFields.Any())
                QualifiedMemberName = SearchFields.First().QualifiedMemberName;

            if (ComparisonOperators.Any())
                SearchOperator = ComparisonOperators.First();

            await base.OnInitializedAsync();

            IsLoading = SearchFields is null || ComparisonOperators is null;
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
                out string? errorMessage))
            {
                InvalidSearchMessage = string.Empty;
                SearchSubmittedEventArgs<TModel> searchArgs = new(args, expression);

                await OnSearchClick.InvokeAsync(searchArgs);
            }
            else
            {
                InvalidSearchMessage = errorMessage ?? string.Empty;
            }
        }

        /// <summary>
        /// Attempts to create a <see cref="Expression{Func{TModel, bool}}"/> from the entered
        /// parameters.
        /// </summary>
        /// <param name="expression">The generated search expression if successful, else: x => false.</param>
        /// <param name="errorMessage">The resulting error message, if an exception was thrown.</param>
        /// <returns>True if an expression was successfully created, else false.</returns>
        private bool TryCreateSearchExpression(
            out Expression<Func<TModel, bool>> expression, out string? errorMessage)
        {
            try
            {
                var param = ExpressionBuilder!
                    .CreateQueryParameter<TModel>(
                        SearchFields?.FirstOrDefault(s => s.QualifiedMemberName == QualifiedMemberName),
                        SearchOperator,
                        SearchValue);

                expression = ExpressionBuilder!.GetExpression(param);
                errorMessage = null;

                return true;
            }
            catch (Exception e)
            {
                expression = x => false;
                errorMessage = e.Message;

                return false;
            }
        }

        private static string NameFor(ComparisonOperator @operator)
        {
            var enumType = typeof(ComparisonOperator);
            var name = Enum.GetName(enumType, @operator);

            var displayAttribute = enumType
                .GetMember(name)
                .FirstOrDefault()
                ?.GetCustomAttribute<DisplayAttribute>();

            return displayAttribute?.GetName();
        }
    }
}
