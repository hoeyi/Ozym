using NjordFinance.Web.Controllers;
using Ichosys.DataModel.Expressions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using NjordFinance.Web.Components.Shared;
using NjordFinance.UserInterface;

namespace NjordFinance.Web.Components.Generic
{
    /// <summary>
    /// A component for interacting with a model index.
    /// </summary>
    public partial class ModelIndex<TModel> : ModelPage<TModel>
        where TModel : class, new()
    {
        /// <summary>
        /// Gets or sets the <see cref="IExpressionBuilder"/> for this component.
        /// </summary>
        [Inject]
        protected IExpressionBuilder ExpressionBuilder { get; set; } = default!;

        /// <summary>
        /// Gets or sets the <see cref="IController{TModel}"/> for this component.
        /// </summary>
        [Inject]
        protected virtual IController<TModel> Controller { get; set; } = default!;

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
        protected IEnumerable<TModel> Models { get; private set; } = default!;

        /// <summary>
        /// Gets or sets the collection of searchables fields for the type: <typeparamref name="TModel"/>.
        /// </summary>
        protected IEnumerable<ISearchableMemberMetadata> SearchFields { get; set; }
            = Array.Empty<ISearchableMemberMetadata>();

        /// <summary>
        /// Gets or sets the collection of allowable <see cref="ComparisonOperator"/> for
        /// the type: <typeparamref name="TModel"/>.
        /// </summary>
        protected IEnumerable<ComparisonOperator> ComparisonOperators { get; set; }
            = Array.Empty<ComparisonOperator>();

        /// <summary>
        /// Gets or sets the default <see cref="Menu"/> instance for this class.
        /// </summary>
        private Menu? DefaultMenu { get; set; }

        /// <inheritdoc/>   
        protected override async Task OnInitializedAsync()
        {
            try
            {
                IsLoading = true;
                if (ExpressionBuilder is null)
                    throw new ArgumentNullException(paramName: nameof(ExpressionBuilder));

                if (Controller is null)
                    throw new ArgumentNullException(paramName: nameof(Controller));

                SearchFields = ExpressionBuilder!.GetSearchableMembers<TModel>();
                ComparisonOperators = ExpressionBuilder!.GetComparisonOperators();

                ActionResult<IList<TModel>> actionResult =
                    await Controller!.SelectWhereAysnc(InitialSearchExpression, MaxRecordCount);

                Models = actionResult.Value ?? Array.Empty<TModel>();
            }
            finally
            {
                IsLoading = Models is null;
            }
        }

        /// <summary>
        /// Handles search submission events that that contain 
        /// <see cref="SearchSubmittedEventArgs{TModel}"/> data.
        /// </summary>
        /// <param name="args">The <see cref="SearchSubmittedEventArgs{TModel}"/> that 
        /// containst the data for the invoked event.</param>
        /// <returns>A task representing an asynchronous operator. Successful ooperation will 
        /// cause <see cref="Models"/> to updates to the collection matching the event arguments 
        /// search expression.</returns>
        protected async Task SearchClicked(SearchSubmittedEventArgs<TModel> args)
        {
            try
            {
                IsLoading = true;
                if (args is not null)
                {
                    var actionResult = await Controller!.SelectWhereAysnc(
                            predicate: args.SearchExpression, maxCount: MaxRecordCount);

                    Models = actionResult.Value ?? Array.Empty<TModel>();
                }
            }
            finally
            {
                IsLoading = false;
            }
        }

        /// <summary>
        /// Gets an instance of <see cref="Menu"/> with pre-defined <see cref="MenuItem"/> entries.
        /// </summary>
        /// <returns>The default instance of <see cref="Menu"/> for <see cref="ModelIndex{TModel}"/> 
        /// types.</returns>
        /// <remarks>A new instance of <see cref="Menu"/> is not created for each call to this 
        /// method.</remarks>
        protected Menu GetDefaultIndexMenu() 
        {
            DefaultMenu ??= new()
            {
                IconKey = "reorder-four",
                Children = new()
                {
                    { 0, new MenuItem()
                        {
                            IconKey = "create",
                            Caption = Strings.Caption_CreateNew.Format(ModelNoun.GetSingular()),
                            UriStem = FormatCreateUri(Guid.NewGuid())
                        }
                    }
                }
            };

            return DefaultMenu;
        }
    }
}
