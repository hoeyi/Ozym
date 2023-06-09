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

namespace NjordinSight.Web.Components.Generic
{
    /// <summary>
    /// Generic razor component-class implementing default features for read/write interaction
    /// with a stateful server collection.
    /// </summary>
    /// <typeparam name="TModelDto">The entity type worked.</typeparam>
    public partial class ModelListPage<TModelDto>
        where TModelDto : class, new()
    {
        /// <summary>
        /// Gets or sets the <see cref="ICollectionController{T}"/> provider for this page.
        /// </summary>
        protected ICollectionController<TModelDto> Controller { get; set; }

        /// <summary>
        /// Gets or sets the collection of entries worked via this page.
        /// </summary>
        protected ICollection<TModelDto> Entries { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="EditContext" /> for this control.
        /// </summary>
        protected EditContext Context { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="PagerModel" /> for this component.
        /// </summary>
        protected PagerModel PaginationHelper { get; set; } = new()
        {
            PageIndex = 1,
            PageSize = 20
        };

        protected Expression<Func<TModelDto, bool>> LastSearchExpression { get; set; } = x => true;

        /// <summary>
        /// Adds a new entry to the worked collection.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
#pragma warning disable IDE0060 // Remove unused parameter
        // TODO: Do something with MouseEventArgs?
        protected virtual async Task AddNewAsync(MouseEventArgs args)
#pragma warning restore IDE0060 // Remove unused parameter
        {
            var getDefaultTask = await Controller.GetDefaultAsync();
            
            await Controller.AddAsync(getDefaultTask.Value);

            if (getDefaultTask.Value is TModelDto model)
                Entries.Add(model);
            else
                // TODO: Log error here with useful message.
                throw new InvalidOperationException();
        }

        /// <summary>
        /// Removes an existing or pending entry from the worked collection.
        /// </summary>
        /// <param name="args"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
#pragma warning disable IDE0060 // Remove unused parameter
        // TODO: Do sommething with MouseEventArgs?
        protected async Task DeleteAsync(MouseEventArgs args, TModelDto model)
#pragma warning restore IDE0060 // Remove unused parameter
        {
            var result = await Controller.DeleteOrDetachAsync(model);

            if (result is OkResult)
                Entries.Remove(model);
            else
                // TODO: Log error here with useful message.
                throw new InvalidOperationException();
        }

        protected virtual void Cancel_OnClick() => NavigationHelper.NavigateTo(IndexUriRelativePath);

        protected virtual async Task Submit_OnClick(EditContext context, MouseEventArgs args)
        {
            bool isValid = context.Validate();
            if (isValid)
            {
                var saveResult = await Controller.SaveChangesAsync();

                if (saveResult is NoContentResult)
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
            await RefreshResults(
                LastSearchExpression, PaginationHelper.PageIndex, PaginationHelper.PageCount);
                
            Context = new(Entries);
        }

        protected async Task OnIndexChangedAsync(int args)
        {
            await RefreshResults(
                predicate: LastSearchExpression,
                pageNumber: PaginationHelper.PageIndex,
                pageSize: PaginationHelper.PageSize);
        }

        protected async Task OnPageSizeChangedAsync(int args)
        {
            await RefreshResults(
                predicate: LastSearchExpression,
                pageNumber: PaginationHelper.PageIndex,
                pageSize: PaginationHelper.PageSize);
        }

        protected async Task RefreshResults(
            Expression<Func<TModelDto, bool>> predicate, 
            int pageNumber, 
            int pageSize,
            Func<bool> isLoadingDelegate = null)
        {
            IsLoading = true;

            try
            {
                var actionResult = await Controller.SelectAsync(predicate, pageNumber, pageSize);

                Entries = actionResult.Value.Item1.ToList();

                PaginationHelper.TotalItemCount = actionResult.Value.Item2.ItemCount;
                PaginationHelper.ItemCount = Entries.Count;
            }
            finally
            {
                if (isLoadingDelegate is null)
                    IsLoading = Entries is null;
                else
                    IsLoading = isLoadingDelegate.Invoke();
            }
        }

        protected async Task SearchClicked(SearchSubmittedEventArgs<TModelDto> args)
        {
            await RefreshResults(
                predicate: args.SearchExpression,
                pageNumber: PaginationHelper.PageIndex,
                pageSize: PaginationHelper.PageSize);
        }
    }
}
