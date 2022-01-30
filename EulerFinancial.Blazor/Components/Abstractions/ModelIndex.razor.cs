using System;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Ichosoft.DataModel.Expressions;
using EulerFinancial.Controllers;
using EulerFinancial.ModelMetadata;
using Ichosoft.Extensions.Common.Localization;

namespace EulerFinancial.Blazor.Components.Abstractions
{
    /// <summary>
    /// A component for interacting with a model index.
    /// </summary>
    public partial class ModelIndex<TModel> : ModelComponentBase<TModel>
        where TModel : class, new()
    {
        private string _searchErrorMessage;

        /// <summary>
        /// Gets or sets the <see cref="IExpressionBuilder"/> for this component.
        /// </summary>
        [Inject]
        protected IExpressionBuilder ExpressionBuilder { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="IController{TModel}"/> for this component.
        /// </summary>
        [Inject]
        protected IController<TModel> Controller { get; set; }

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
        protected ComparisonOperator CurrentSearchOperator { get; set; }

        /// <summary>
        /// Gets or sets the current member to be used as a parameter for searches in this view. 
        /// </summary>
        protected string CurrentSearchMemberName { get; set; }

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

        /// <summary>
        /// Gets or sets the default search expression used when first loading the index.
        /// </summary>
        protected Expression<Func<TModel, bool>> InitialSearchExpression { get; set; } = x => true;

        /// <summary>
        /// Gets or sets the default maximum record 
        /// </summary>
        protected int DefaultMaxRecordCount { get; set; } = 0;

        /// <summary>
        /// Gets the model collection that matches the search expression for this component.
        /// </summary>
        protected IEnumerable<TModel> Models { get; private set; }

        /// <inheritdoc/>   
        protected override async Task OnInitializedAsync()
        {
            Task<ActionResult<IList<TModel>>> actionResult = 
                Controller.SelectWhereAysnc(InitialSearchExpression, DefaultMaxRecordCount);

            SearchFields = ExpressionBuilder?.GetSearchableMembers<TModel>();
            ComparisonOperators = ExpressionBuilder?.GetComparisonOperators();

            if (SearchFields.Any())
                CurrentSearchMemberName = SearchFields.First().QualifiedMemberName;

            if (ComparisonOperators.Any())
                CurrentSearchOperator = ComparisonOperators.First();

            await actionResult;
            Models = actionResult.Result?.Value;
            IsLoading = Models is null;
        }
        
        /// <summary>
        /// Attempts to create a <see cref="Expression{Func{TModel, Boolean}}"/> from the entered 
        /// parameters.
        /// </summary>
        /// <param name="expression">The generated search expression if successful, else null.</param>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        protected bool TryCreateSearchExpression(
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

        /// <summary>
        /// Handles the search action for the model collection.
        /// </summary>
        /// <returns>A <see cref="Task"/>, representing an asynchronous operation.</returns>
        protected async Task SearchClicked()
        {
            if (TryCreateSearchExpression(out Expression<Func<TModel, bool>> exp, out string msg))
            {
                try
                {
                    SearchErrorMessage = msg;
                    var actionResult = await Controller.SelectWhereAysnc(exp, maxCount: 0);
                    Models = actionResult.Value;
                }
                catch (Exception e)
                {
                    Logger.Error(e, string.Empty);
                }
            }
            else
            {
                SearchErrorMessage = msg;
            }
        }
    }
}
