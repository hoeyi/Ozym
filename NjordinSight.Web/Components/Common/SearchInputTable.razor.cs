using Ichosys.DataModel.Exceptions;
using Ichosys.DataModel.Expressions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.DependencyInjection;
using NjordinSight.DataTransfer.Common.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NjordinSight.Web.Components.Common
{
    public partial class SearchInputTable<TModel> : LocalizableComponent
    {
#nullable enable
        /// <summary>
        /// Gets or sets the collection of searchables fields for the type: <typeparamref name="TModel"/>.
        /// </summary>
        [Parameter, EditorRequired]
        public IEnumerable<ISearchableMemberMetadata> SearchFields { get; init; } = default!;

        /// <summary>
        /// Gets or sets the collection of allowable <see cref="ComparisonOperator"/> for
        /// the type: <typeparamref name="TModel"/>.
        /// </summary>
        [Parameter, EditorRequired]
        public IEnumerable<ComparisonOperator> ComparisonOperators { get; init; } = default!;

        /// <summary>
        /// Gets or sets the <see cref="IExpressionBuilder"/> instance for this component.
        /// </summary>
        [Parameter, EditorRequired]
        public IExpressionBuilder ExpressionBuilder { get; init; } = default!;

        /// <summary>
        /// Gets or sets the delegate for handling search submission events from this component.
        /// </summary>
        [Parameter, EditorRequired]
        public EventCallback<SearchSubmittedEventArgs<TModel>> OnSearchClick { get; set; } = default!;

        /// <summary>
        /// The field defining the search error message text.
        /// </summary>
        private string _searchErrorMessage = string.Empty;


        /// <summary>
        /// Gets whether the last search submitted to this index had valid syntax.
        /// </summary>
#pragma warning disable IDE0052 // Remove unread private members
        // This warning is incorrect. Not sure why.
        private bool SearchIsValid { get; set; }
#pragma warning restore IDE0052 // Remove unread private members

        /// <summary>
        /// Gets or sets the search error message for this component.
        /// </summary>
        private string ErrorMessage
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

        private ParameterDto<TModel> Parameter { get; set; } = default!;

        /// <inheritdoc/>
        protected override void OnInitialized()
        {
            if (SearchFields is null)
                throw new ArgumentNullException(paramName: nameof(SearchFields));

            if (ComparisonOperators is null || !ComparisonOperators.Any())
                throw new ArgumentNullException(paramName: nameof(ComparisonOperators));

            if(ExpressionBuilder is null)
                throw new ArgumentNullException(paramName: nameof(ExpressionBuilder));

            Parameter = new ParameterDto<TModel>()
            {
                MemberName = SearchFields.FirstOrDefault()?.QualifiedMemberName ?? string.Empty,
                Operator = ComparisonOperators.First()
            };

            IsLoading = 
                SearchFields is null || 
                !SearchFields.Any() || 
                ComparisonOperators is null || 
                Parameter is null;
        }

        /// <summary>
        /// Handles the search submitted event of this component.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        private async Task SearchSubmitted(MouseEventArgs args)
        {
            if (ValidateParameter(Parameter, out string? errorMessage))
            {
                ErrorMessage = string.Empty;
                SearchSubmittedEventArgs<TModel> searchArgs = new(args, Parameter);

                await OnSearchClick.InvokeAsync(searchArgs);
            }
            else
            {
                ErrorMessage = errorMessage ?? string.Empty;
            }
        }

        private bool ValidateParameter(IQueryParameter<TModel>? parameter, out string? errorMessage)
        {
            try
            {
                // We don't need the result here. IExpressionBuilder.GetExpression will throw
                // a ParseException if the given parameter is not valid.
                _ = ExpressionBuilder.GetExpression(parameter) is not null;
                errorMessage = null;
                return true;
            }
            catch (ParseException pe)
            {
                errorMessage = pe.Message;

                return false;
            }
        }
    }
#nullable disable
}
