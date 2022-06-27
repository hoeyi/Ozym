using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.Logging;
using System;
using NjordFinance.UserInterface;
using NjordFinance.Web.Components.Shared;
using Ichosys.DataModel.Annotations;
using NjordFinance.ModelMetadata;

namespace NjordFinance.Web.Components.Generic
{
    public partial class ModelPage<TModel> : LocalizableComponent, INavigationSource
    {
        private NounAttribute _modelNoun;
        private string _indexUriRelativePath;

        /// <summary>
        /// Gets or sets the <see cref="ILogger"/> used by this component.
        /// </summary>
        [Inject]
        public ILogger Logger { get; set; } = default!;

        /// <summary>
        /// Gets or sets the <see cref="NavigationManager"/> for this component.
        /// </summary>
        [Inject]
        public NavigationManager NavigationHelper { get; set; } = default!;

        /// <summary>
        /// Gets or sets the <see cref="Menu"/> containing available actions for this component.
        /// </summary>
        protected Menu ActionMenu { get; set; }

        /// <summary>
        /// Gets the <see cref="NounAttribute"/> associated with <typeparamref name="TModel"/>.
        /// </summary>
        protected NounAttribute ModelNoun
        {
            get
            {
                _modelNoun ??= ModelMetadata.NounFor(typeof(TModel));
                return _modelNoun;
            }
        }

        /// <summary>
        /// Gets the <see cref="IPageTitle"/> instance for this page.
        /// </summary>
        protected IPageTitle PageTitle => DisplayHelper.GetPagetTitle<TModel>();

        /// <summary>
        /// Gets the relative uri for the index page that represents this model.
        /// Model pages use the index page as the base relative path for other model pages.
        /// Ex. /Accounts
        /// </summary>
        protected string IndexUriRelativePath
        {
            get
            {
                if (string.IsNullOrEmpty(_indexUriRelativePath))
                {
                    string relativePath = NavigationHelper.ToBaseRelativePath(NavigationHelper.Uri);

                    string[] pathElements = relativePath.Split("/");

                    if (pathElements.Length > 0)
                        _indexUriRelativePath = $"/{pathElements[0]}";
                    else
                        throw new InvalidOperationException(
                            Resources.Strings.Exception_Navigation_BaseUriNotValid);
                }

                return _indexUriRelativePath;
            }
        }

        /// <summary>
        /// Gets or sets the current text describing this page's error state.
        /// </summary>
        protected string ErrorMessage { get; set; }

        /// <summary>
        /// Redirects the focus to the model index page.
        /// </summary>
        protected virtual void NavigateToIndex(MouseEventArgs args)
        {
            NavigationHelper.NavigateTo($"{IndexUriRelativePath}");
        }

        /// <summary>
        /// Redirects the focus to the model creation page.
        /// </summary>
        /// <param name="id">The identifier representing the request.</param>
        protected virtual void NavigateToCreate(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException(paramName: nameof(id));

            NavigationHelper.NavigateTo($"{IndexUriRelativePath}/Create/{id}");
        }

        /// <summary>
        /// Redirects the focus to the model edit page.
        /// </summary>
        /// <param name="id">The identifier representing the request.</param>
        protected virtual void NavigateToEdit(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException(paramName: nameof(id));

            NavigationHelper.NavigateTo($"{IndexUriRelativePath}/Edit/{id}");
        }

        /// <summary>
        /// Redirects the focus to the model details page.
        /// </summary>
        /// <param name="id">The identifier representing the request.</param>
        protected virtual void NavigateToDetail(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException(paramName: nameof(id));

            NavigationHelper.NavigateTo($"{IndexUriRelativePath}/Detail/{id}");
        }
    }
}
