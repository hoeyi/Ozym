using EulerFinancial.Blazor.Components.Generic;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Serilog;
using System;

namespace EulerFinancial.Blazor.Components.Abstractions
{
    public partial class ModelComponentBase<TModel> : LocalizedComponent
    {
        /// <summary>
        /// Gets or sets the <see cref="ILogger"/> used by this component.
        /// </summary>
        [Inject]
        protected ILogger Logger { get; set; }

        /// <summary>
        /// Gets the absolute uri for the index page that represents this model.
        /// Model pages use the index page as the base relative path for other model pages.
        /// Ex. {BaseUri}/Accounts
        /// </summary>
        protected string PageIndexUri
        {
            get
            {
                string relativePath = NavigationHelper.ToBaseRelativePath(NavigationHelper.Uri);

                string[] pathElements = relativePath.Split("/");

                if (pathElements.Length > 0)
                    return NavigationHelper.ToAbsoluteUri(pathElements[0]).AbsoluteUri;
                else
                    throw new InvalidOperationException(BlazorResources.Exception.Navigation_BaseUriNotValid);

            }
        }

        /// <inheritdoc/>
        protected override string PageTitle
        {
            get
            {
                return Resources.PageMetadata.Title_Not_Found;
            }
        }

        /// <summary>
        /// Redirects the focus to the model index page.
        /// </summary>
        protected virtual void NavigateToIndex(MouseEventArgs args)
        {
            if (IsLoading)
                return;

            NavigationHelper.NavigateTo($"{PageIndexUri}");
        }

        /// <summary>
        /// Redirects the focus to the model creation page.
        /// </summary>
        /// <param name="id">The identifier representing the request.</param>
        protected virtual void NavigateToCreate(string id)
        {
            if (IsLoading)
                return;

            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException(paramName: nameof(id));

            NavigationHelper.NavigateTo($"{PageIndexUri}/Create/{id}");
        }

        /// <summary>
        /// Redirects the focus to the model edit page.
        /// </summary>
        /// <param name="id">The identifier representing the request.</param>
        protected virtual void NavigateToEdit(string id)
        {
            if (IsLoading)
                return;

            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException(paramName: nameof(id));

            NavigationHelper.NavigateTo($"{PageIndexUri}/Edit/{id}");
        }

        /// <summary>
        /// Redirects the focus to the model details page.
        /// </summary>
        /// <param name="id">The identifier representing the request.</param>
        protected virtual void NavigateToDetail(string id)
        {
            if (IsLoading)
                return;

            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException(paramName: nameof(id));

            NavigationHelper.NavigateTo($"{PageIndexUri}/Detail/{id}");
        }
    }
}
