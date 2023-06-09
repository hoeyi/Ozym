using Ichosys.DataModel.Expressions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using NjordinSight.Web.Components.Common;
using NjordinSight.UserInterface;
using NjordinSight.Web.Controllers;
using Ichosys.DataModel;
using Microsoft.AspNetCore.Http;
using NjordinSight.EntityModelService.Abstractions;
using NjordinSight.DataTransfer;
using System.Drawing.Drawing2D;
using System.Linq;
using NjordinSight.EntityModel;

namespace NjordinSight.Web.Components.Generic
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
        /// Gets or sets the last saved search expression. Defaults to return all records.
        /// </summary>
        protected Expression<Func<TModel, bool>> SavedSearchExpression { get; set; } = x => true;

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
        /// Gets or sets the default maximum record count.
        /// </summary>
        protected int MaxRecordCount { get; set; } = 20;

        /// <summary>
        /// Gets or sets page record limit for each request.
        /// </summary>
        protected int PageSize { get; set; } = 20;

        /// <summary>
        /// Gets or sets the page index to request.
        /// </summary>
        protected int PageIndex { get; set; } = 1;

        /// <summary>
        /// Gets or sets the <see cref="PagerModel" /> for this component.
        /// </summary>
        protected PagerModel PaginationHelper { get; set; } = new()
        {
            PageIndex = 1,
            PageSize = 20
        };

        /// <inheritdoc/>
        protected override MenuRoot CreateSectionNavigationMenu() => new()
        {
            Children = new()
            {
                new MenuItem()
                {
                    IconKey = "create",
                    Caption = Strings.Caption_CreateNew.Format(ModelNoun.GetSingular()),
                    UriRelativePath = FormatCreateUri(Guid.NewGuid())
                }
            }
        };
        
        /// <inheritdoc/>   
        protected override async Task OnInitializedAsync()
        {
            IsLoading = true;
            try
            {
                if (ExpressionBuilder is null)
                    throw new ArgumentNullException(paramName: nameof(ExpressionBuilder));

                if (Controller is null)
                    throw new ArgumentNullException(paramName: nameof(Controller));

                SearchFields = ExpressionBuilder!.GetSearchableMembers<TModel>();
                ComparisonOperators = ExpressionBuilder!.GetComparisonOperators();

                ActionResult<(IEnumerable<TModel>, PaginationData)> results = await Controller
                    .SelectAsync(SavedSearchExpression, pageNumber: PageIndex, pageSize: PageSize);

                Models = results.Value.Item1;
                PaginationHelper.TotalItemCount = results.Value.Item2.ItemCount;
                PaginationHelper.ItemCount = Models.Count();
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
                    ActionResult<(IEnumerable<TModel>, PaginationData)> results = 
                        await Controller.SelectAsync(
                                predicate: args.SearchExpression, 
                                pageNumber: PaginationHelper.PageIndex, 
                                pageSize: PaginationHelper.PageSize);

                    Models = results.Value.Item1.ToList();

                    PaginationHelper.TotalItemCount = results.Value.Item2.ItemCount;
                    PaginationHelper.ItemCount = Models.Count();
                }
            }
            finally
            {
                IsLoading = false;
            }
        }
    }
}
