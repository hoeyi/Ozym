using EulerFinancial.Controllers;
using Ichosoft.DataModel.Expressions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EulerFinancial.Blazor.Components.Abstractions
{
    /// <summary>
    /// A component for interacting with a model index.
    /// </summary>
    public partial class ModelIndex<TModel> : ModelComponentBase<TModel>
        where TModel : class, new()
    {
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
        /// Gets or sets the default search expression used when first loading the index.
        /// </summary>
        protected Expression<Func<TModel, bool>> InitialSearchExpression { get; set; } = x => true;

        /// <summary>
        /// Gets or sets the default maximum record 
        /// </summary>
        protected int MaxRecordCount { get; set; } = 0;

        /// <summary>
        /// Gets the model collection that matches the search expression for this component.
        /// </summary>
        protected IEnumerable<TModel> Models { get; private set; }

        /// <summary>
        /// Gets or sets the collection of searchables fields for the type: <typeparamref name="TModel"/>.
        /// </summary>
        protected IEnumerable<ISearchableMemberMetadata> SearchFields { get; set; }

        /// <summary>
        /// Gets or sets the collection of allowable <see cref="ComparisonOperator"/> for
        /// the type: <typeparamref name="TModel"/>.
        /// </summary>
        protected IEnumerable<ComparisonOperator> ComparisonOperators { get; set; }

        /// <inheritdoc/>   
        protected override async Task OnInitializedAsync()
        {
            SearchFields = ExpressionBuilder.GetSearchableMembers<TModel>();
            ComparisonOperators = ExpressionBuilder.GetComparisonOperators();

            Task<ActionResult<IList<TModel>>> actionResult =
                Controller.SelectWhereAysnc(InitialSearchExpression, MaxRecordCount);

            await actionResult;
            Models = actionResult.Result?.Value;
            IsLoading = Models is null;
        }

        /// <summary>
        /// Handles search submission events that that contain 
        /// <see cref="Generic.SearchSubmittedEventArgs{TModel}"/> data.
        /// </summary>
        /// <param name="args">The <see cref="Generic.SearchSubmittedEventArgs{TModel}"/> that 
        /// containst the data for the invoked event.</param>
        /// <returns>A task representing an asynchronous operator. Successful ooperation will 
        /// cause <see cref="Models"/> to updates to the collection matching the event arguments 
        /// search expression.</returns>
        protected async Task SearchClicked(Generic.SearchSubmittedEventArgs<TModel> args)
        {
            if (args is not null)
            {
                var actionResult = await Controller.SelectWhereAysnc(
                        predicate: args.SearchExpression, maxCount: MaxRecordCount);

                Models = actionResult.Value;
            }
        }
    }
}
