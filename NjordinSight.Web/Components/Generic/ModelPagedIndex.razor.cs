using Ichosys.DataModel.Expressions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using NjordinSight.Web.Components.Common;
using NjordinSight.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NjordinSight.Web.Components.Generic
{
    /// <summary>
    /// Generic <see cref="ModelPage{TModelDto}"/>-derived class that supports searching and 
    /// paging through records.
    /// </summary>
    /// <typeparam name="TModelDto"></typeparam>
    public partial class ModelPagedIndex<TModelDto> : ModelPage<TModelDto>
        where TModelDto : class
    {
        /// <summary>
        /// Checks the current page state and returns true if all required properties have been 
        /// set. Inheritors may override this method to handle additional initialization checks.
        /// </summary>
        /// <returns>True if the page is loaded, else false.</returns>
        protected virtual bool GetLoadingState() => Entries is null;

        /// <summary>
        /// Gets or sets the <see cref="ISearchService{T}"/> for this page.
        /// </summary>
        [Inject]
        protected ISearchService<TModelDto> SearchService { get; init; }

        protected IEnumerable<ComparisonOperator> ComparisonOperators => SearchService.ComparisonOperators;

        protected IEnumerable<ISearchableMemberMetadata> SearchFields => SearchService.SearchFields;

        protected IExpressionBuilder ExpressionBuilder => SearchService.ExpressionBuilder;

        /// <summary>
        /// Gets the model collection that matches the search expression for this component.
        /// </summary>
        protected virtual IEnumerable<TModelDto> Entries { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="PagerModel" /> for this component.
        /// </summary>
        protected PagerModel PaginationHelper { get; set; } = new()
        {
            PageIndex = 1,
            PageSize = 20
        };

        /// <summary>
        /// Awaits a collection of <see cref="Task" /> objects representing initialization 
        /// tasks for this page.
        /// </summary>
        /// <param name="initTasks"></param>
        /// <returns>An empty <see cref="Task"/> representing an asynchronous operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        protected async Task InitializationTasksAsync(params Task[] initTasks)
        {
            if (initTasks is null || !initTasks.Any())
                throw new ArgumentNullException(paramName: nameof(initTasks));

            var initTaskCollection = Task.WhenAll(initTasks);
            await initTaskCollection;

            if (initTaskCollection.Status != TaskStatus.RanToCompletion)
                throw initTaskCollection.Exception.Flatten();
        }

        /// <summary>
        /// Delegate handler for <see cref="Paginator.IndexChanged"/> events.
        /// </summary>
        /// <param name="args">The new <see cref="int"/> index value.</param>
        /// <returns>A task representing an asynchronous query and render operation.</returns>
        protected async Task OnIndexChangedAsync() => await RefreshResultsAsync();

        /// <summary>
        /// Delegate handler for <see cref="Paginator.PageSizeChanged"/> events.
        /// </summary>
        /// <param name="args">The new <see cref="int"/> index value.</param>
        /// <returns>A task representing an asynchronous query and render operation.</returns>
        protected async Task OnPageSizeChangedAsync() => await RefreshResultsAsync();

        /// <summary>
        /// Refreshes the core result set according to the current search and page parameters. Lookup 
        /// collections are not refreshed. Wrapper method for 
        /// <see cref="RefreshResultsAsync(Expression{Func{TModelDto, bool}}, int, int, Func{bool})"/> 
        /// using the current values of <see cref="SearchService"/> and <see cref="PaginationHelper"/> 
        /// as parameters.
        /// </summary>
        /// <returns>A task representing the asynchronous action to query and render 
        /// updated data.</returns>
        protected async Task RefreshResultsAsync()
        {
            IsLoading = true;

            try
            {
                var refreshTask = RefreshResultsAsync(
                    predicate: SearchService.CurrentExpression,
                    pageNumber: PaginationHelper.PageIndex,
                    pageSize: PaginationHelper.PageSize);

                await refreshTask;
            }
            finally
            {
                IsLoading = GetLoadingState();
            }
        }

        /// <summary>
        /// Refreshes the core result set according to the current search and page parameters. Lookup 
        /// collections are not refreshed.
        /// </summary>
        /// <param name="predicate">The filter expression to apply.</param>
        /// <param name="pageNumber">The index of the page desired.</param>
        /// <param name="pageSize">The record limit per page.</param>
        /// page should render as loading data.</param>
        /// <returns>A task representing the asynchronous action to query and render 
        /// updated data.</returns>
        /// <exception cref="NotImplementedException">The method has not been overriden in a 
        /// derived class.</exception>
        protected virtual Task RefreshResultsAsync(
            Expression<Func<TModelDto, bool>> predicate,
            int pageNumber,
            int pageSize)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Handles search submission events that that contain 
        /// <see cref="SearchSubmittedEventArgs{TModel}"/> data.
        /// </summary>
        /// <param name="args">The <see cref="SearchSubmittedEventArgs{TModel}"/> that 
        /// containst the data for the invoked event.</param>
        /// <returns>A task representing an asynchronous operation. Successful operation will 
        /// cause <see cref="Entries"/> to updates to the collection matching the event arguments 
        /// search expression.</returns>
        protected async Task SearchClicked(SearchSubmittedEventArgs<TModelDto> args)
        {
            IsLoading = true;

            try
            {
                await RefreshResultsAsync(
                    predicate: args.SearchExpression,
                    pageNumber: PaginationHelper.PageIndex,
                    pageSize: PaginationHelper.PageSize);

                SearchService.CurrentExpression = args.SearchExpression;
            }
            finally
            {
                IsLoading = GetLoadingState();
            }
        }
    }
}
