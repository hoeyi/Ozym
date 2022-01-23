using System;
using Microsoft.AspNetCore.Components;

namespace EulerFinancial.Blazor.Shared
{
    /// <summary>
    /// Base component for viewing details of a <typeparamref name="TModel"/>.
    /// </summary>
    /// <typeparam name="TModel">The model type.</typeparam>
    public partial class ModelDetail<TModel> : ModelComponentBase<TModel>
        where TModel : class, new()
    {
        /// <summary>
        /// Gets or sets the model for which details are provided. 
        /// </summary>
        [Parameter]
        public TModel Model { get; set; }

        /// <summary>
        /// Gets or sets the model index uri for this component.
        /// </summary>
        protected virtual string IndexUri { get; set; }

        /// <summary>
        /// Redirects the focus to a new page. Must be overriden in child classes.
        /// </summary>
        protected virtual void NavigateToIndex()
        {
            ValidateUriOrThrow();

            NavigationHelper.NavigateTo(IndexUri);
        }

        /// <summary>
        /// Redirects the focus to the edit page for a model with the given <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The model unique identifier.</param>
        protected virtual void NavigateToEdit(string id)
        {
            ValidateUriOrThrow();

            if (IsLoading)
                return;

            NavigationHelper.NavigateTo($"{IndexUri}/Edit/{id}");
        }

        /// <summary>
        /// Redirects the focus to the detail page for a model with the given <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The model unique identifier.</param>
        protected virtual void NavigateToDetail(string id)
        {
            ValidateUriOrThrow();

            if (IsLoading)
                return;

            NavigationHelper.NavigateTo($"{IndexUri}/Detail/{id}");
        }
        /// <summary>
        /// Confrms the current <see cref="IndexUri"/> is valid or throws an 
        /// <see cref="InvalidOperationException"/>.
        /// </summary>
        protected void ValidateUriOrThrow()
        {
            if (string.IsNullOrEmpty(IndexUri))
                throw new InvalidOperationException();
        }
    }
}
