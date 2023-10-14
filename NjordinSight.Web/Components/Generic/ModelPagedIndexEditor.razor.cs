using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;
using NjordinSight.Web.Components.Common;
using System.Linq.Expressions;
using NjordinSight.EntityModel;
using Microsoft.AspNetCore.Http;
using NjordinSight.Web.Services;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NjordinSight.ChangeTracking;
using System.ComponentModel;
using NjordinSight.DataTransfer.Common.Query;
using System.Net.Http;
using Ichosys.DataModel.Expressions;

namespace NjordinSight.Web.Components.Generic
{
    /// <summary>
    /// Generic razor component-class implementing default features for read/write interaction
    /// with a stateful server collection.
    /// </summary>
    /// <typeparam name="TModelDto">The entity type worked.</typeparam>
    public partial class ModelPagedIndexEditor<TModelDto> : ModelPage<TModelDto>
        where TModelDto : class, INotifyPropertyChanged, new()
    {
        [Inject]
        protected IHttpCollectionService<TModelDto> HttpService { get; init; }

        /// <summary>
        /// Gets or sets the <see cref="ISearchService{T}"/> for this page.
        /// </summary>
        [Inject]
        protected ISearchService<TModelDto> SearchService { get; init; }

        /// <inheritdoc/>
        protected override bool PageDataIsLoading() => WorkingEntries is null || Context is null;

        /// <summary>
        /// Gets or sets the <see cref="PagerModel" /> for this component.
        /// </summary>
        protected PagerModel PaginationHelper { get; set; } = new()
        {
            PageIndex = 1,
            PageSize = 20
        };

        protected ParameterDto<TModelDto>? LastSearchParameter { get; set; }

        /// <summary>
        /// Gets or sets the collection of entries worked via this page.
        /// </summary>
        protected ITrackingEnumerable<TModelDto> WorkingEntries { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="EditContext" /> for this control.
        /// </summary>
        protected EditContext Context { get; set; }

        /// <summary>
        /// Adds a new entry to the worked collection.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        protected virtual void AddNew(MouseEventArgs args)
        {
            WorkingEntries.Add(new());
        }

        /// <summary>
        /// Checks the <see cref="SearchService"/> and <see cref="Controller"/> properties are 
        /// non-null, else throws an <see cref="ArgumentNullException" />.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        protected void CheckNullParameters()
        {
            if (HttpService is null)
                throw new ArgumentNullException(paramName: nameof(HttpService));

            if (SearchService is null)
                throw new ArgumentNullException(paramName: nameof(SearchService));
        }

        /// <summary>
        /// Removes an existing or pending entry from the worked collection.
        /// </summary>
        /// <param name="args"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
#pragma warning disable IDE0060 // Remove unused parameter
        protected void DeleteRecord(MouseEventArgs args, TModelDto model) => 
            WorkingEntries.Remove(model);

#pragma warning restore IDE0060 // Remove unused parameter

        /// <summary>
        /// Cancels the operation on this page and returns to <typeparamref name="TModelDto"/> 
        /// index URI.
        /// </summary>
        protected async Task CancelEditor_OnClick()
        {
            if (WorkingEntries?.HasChanges ?? false)
            {
                var discardConfirmed = await ConfirmDiscardChangesAsync();

                if (!discardConfirmed)
                    return;
            }

            ReturnToIndex();
        }

        protected virtual void ReturnToIndex() => NavigationHelper.NavigateTo(IndexUriRelativePath);

        /// <summary>
        /// Delegate handler for <see cref="Paginator.IndexChanged"/> events.
        /// </summary>
        /// <returns>A task representing an asynchronous query and render operation.</returns>
        protected async Task OnIndexChangedAsync() => await RefreshResultsAsync(
            parameter: LastSearchParameter,
            pageNumber: PaginationHelper.PageIndex,
            pageSize: PaginationHelper.PageSize);

        /// <summary>
        /// Delegate handler for <see cref="Paginator.PageSizeChanged"/> events.
        /// </summary>
        /// <returns>A task representing an asynchronous query and render operation.</returns>
        protected async Task OnPageSizeChangedAsync() => await RefreshResultsAsync(
            parameter: LastSearchParameter,
            pageNumber: PaginationHelper.PageIndex,
            pageSize: PaginationHelper.PageSize);

        /// <summary>
        /// Validates and submits a request to save changes to <see cref="WorkingEntries"/>.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        protected virtual async Task Submit_OnClick(EditContext context, MouseEventArgs args)
        {
            // Clear error message, if present.
            ErrorMessage = null;

            if(!WorkingEntries.HasChanges)
                ReturnToIndex();

            bool isValid = context.Validate();
            if (isValid)
            {
                var changes = WorkingEntries.GetChanges();

                try
                {
                    var saveResult = await HttpService.PatchCollectionAsync(changes);
                    
                    ReturnToIndex();
                }
                catch(HttpRequestException e)
                {
                    ErrorMessage = e?.Message;
                }
            }
            else
            {
                ErrorMessage = string.Join("\n", context.GetValidationMessages());
            }
        }

        /// <inheritdoc/>
        protected override async Task OnInitializedAsync()
        {
            CheckNullParameters();

            IsLoading = true;

            try
            {
                await RefreshResultsAsync(null, PaginationHelper.PageIndex, PaginationHelper.PageSize);
            }
            finally
            {
                IsLoading = PageDataIsLoading();
            }
        }

        /// <summary>
        /// Refreshes the core result set according to the current search and page parameters. Lookup 
        /// collections are not refreshed.
        /// </summary>
        /// <param name="predicate">The filter expression to apply.</param>
        /// <param name="pageNumber">The index of the page desired.</param>
        /// <param name="pageSize">The record limit per page.</param>
        /// <returns>A task representing the asynchronous action to query and render 
        /// updated data.</returns>
        /// <exception cref="NotImplementedException">The method has not been overriden in a 
        /// derived class.</exception>
        protected virtual async Task RefreshResultsAsync(
            ParameterDto<TModelDto> parameter, int pageNumber, int pageSize)
        {
            if (WorkingEntries?.HasChanges ?? false)
            {
                var discardConfirmed = await ConfirmDiscardChangesAsync();

                if (!discardConfirmed)
                    return;
            }

            var responseObject = await (parameter is null ?
                HttpService.IndexAsync(
                    pageNumber: PaginationHelper.PageIndex,
                    pageSize: PaginationHelper.PageSize) :
                HttpService.SearchAsync(
                    parameter: parameter,
                    pageNumber: PaginationHelper.PageIndex,
                    pageSize: PaginationHelper.PageSize));

            WorkingEntries = new TrackingEnumerable<TModelDto>(responseObject.Item1.ToList());

            Context = new(WorkingEntries);

            PaginationHelper.TotalItemCount = responseObject.Item2.ItemCount;
            PaginationHelper.ItemCount = WorkingEntries.Count;
        }

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

        protected static async Task<bool> ConfirmDiscardChangesAsync()
        {
            await Task.Delay(2000);

            return true;
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
                LastSearchParameter = args.Parameter;

                await RefreshResultsAsync(
                    parameter: LastSearchParameter,
                    pageNumber: PaginationHelper.PageIndex,
                    pageSize: PaginationHelper.PageSize);

            }
            finally
            {
                IsLoading = PageDataIsLoading();
            }
        }
    }
}
