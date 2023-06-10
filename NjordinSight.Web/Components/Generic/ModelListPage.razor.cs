using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using NjordinSight.Web.Controllers;
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

namespace NjordinSight.Web.Components.Generic
{
    /// <summary>
    /// Generic razor component-class implementing default features for read/write interaction
    /// with a stateful server collection.
    /// </summary>
    /// <typeparam name="TModelDto">The entity type worked.</typeparam>
    public partial class ModelListPage<TModelDto> : ModelPagedIndex<TModelDto>
        where TModelDto : class, new()
    {
        /// <inheritdoc/>
        protected override bool GetLoadingState() => WorkingEntries is null || Context is null;
        
        /// <summary>
        /// Gets or sets the <see cref="ICollectionController{T}"/> provider for this page.
        /// </summary>
        protected ICollectionController<TModelDto> Controller { get; set; }

        /// <summary>
        /// Gets or sets the collection of entries worked via this page.
        /// </summary>
        protected IList<TModelDto> WorkingEntries { get; set; }

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
        protected virtual async Task AddNewAsync(MouseEventArgs args)
        {
            var getDefaultTask = await Controller.GetDefaultAsync();
            
            await Controller.AddAsync(getDefaultTask.Value);

            if (getDefaultTask.Value is TModelDto model)
                WorkingEntries.Insert(0, model);
            else
                // TODO: Log error here with useful message.
                throw new InvalidOperationException();
        }

        /// <summary>
        /// Checks the <see cref="SearchService"/> and <see cref="Controller"/> properties are 
        /// non-null, else throws an <see cref="ArgumentNullException" />.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        protected void CheckNullParameters()
        {
            if (SearchService is null)
                throw new ArgumentNullException(paramName: nameof(SearchService));

            if (Controller is null)
                throw new ArgumentNullException(paramName: nameof(Controller));
        }

        /// <summary>
        /// Removes an existing or pending entry from the worked collection.
        /// </summary>
        /// <param name="args"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
#pragma warning disable IDE0060 // Remove unused parameter
        protected async Task DeleteAsync(MouseEventArgs args, TModelDto model)
        #pragma warning restore IDE0060 // Remove unused parameter
        {
            var result = await Controller.DeleteOrDetachAsync(model);

            if (result is OkResult)
                WorkingEntries.Remove(model);
            else
                // TODO: Log error here with useful message.
                throw new InvalidOperationException();
        }

        /// <summary>
        /// Cancels the operation on this page and returns to <typeparamref name="TModelDto"/> 
        /// index URI.
        /// </summary>
        protected virtual void Cancel_OnClick() => NavigationHelper.NavigateTo(IndexUriRelativePath);

        /// <summary>
        /// Validates and submits a request to save changes to <see cref="WorkingEntries"/>.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        protected virtual async Task Submit_OnClick(EditContext context, MouseEventArgs args)
        {
            bool isValid = context.Validate();
            if (isValid)
            {
                var saveResult = await Controller.SaveChangesAsync();

                if (saveResult is NoContentResult)
                    // Brings us back to the next highest index page.
                    Cancel_OnClick();

                else if (saveResult is ObjectResult objectResult)
                    ErrorMessage = (objectResult.Value as Exception)?.Message;
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
                await RefreshResultsAsync(
                    predicate: SearchService.CurrentExpression, 
                    pageNumber: PaginationHelper.PageIndex, 
                    pageSize: PaginationHelper.PageSize);
            }
            finally
            {
                IsLoading = GetLoadingState();
            }
        }

        /// <inheritdoc/>
        protected override async Task RefreshResultsAsync(
            Expression<Func<TModelDto, bool>> predicate, 
            int pageNumber, 
            int pageSize)
        {
            var actionResult = await Controller.SelectAsync(predicate, pageNumber, pageSize);

            WorkingEntries = actionResult.Value.Item1.ToList();
            //Entries = WorkingEntries;

            Context = new(WorkingEntries);

            #if DEBUG
            await Task.Delay(5000);
            #endif

            PaginationHelper.TotalItemCount = actionResult.Value.Item2.ItemCount;
            PaginationHelper.ItemCount = WorkingEntries.Count;
        }
    }
}
