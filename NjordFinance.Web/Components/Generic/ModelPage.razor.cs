﻿using Ichosys.DataModel.Annotations;
using NjordFinance.UserInterface;
using NjordFinance.Web.Components.Shared;
using System.Linq.Expressions;
using System;

namespace NjordFinance.Web.Components.Generic
{
    public partial class ModelPage<TViewModel> : ModelComponent<TViewModel>, INavigationSource
    {
        private NounAttribute _modelNoun;
        private string _indexUriRelativePath;

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
                _modelNoun ??= ModelMetadata.GetAttribute<TViewModel, NounAttribute>();
                return _modelNoun;
            }
        }

        /// <summary>
        /// Gets the <see cref="IPageTitle"/> instance for this page.
        /// </summary>
        protected IPageTitle PageTitle => DisplayHelper.GetPagetTitle<TViewModel>();

        /// <summary>
        /// Gets or sets the current text describing this page's error state.
        /// </summary>
        protected string ErrorMessage { get; set; }

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
        /// Creates a new string representing the resource detail page URI for the given
        /// <paramref name="id"/>.
        /// </summary>
        /// <typeparam name="T">The id type, typically <see cref="int"/> or <see cref="Guid"/>.
        /// </typeparam>
        /// <param name="id">The id of the requested resource.</param>
        /// <returns>The formatted <see cref="string"/>.</returns>
        /// <remarks>Expects page to have root index paths defined by
        /// <see cref="IndexUriRelativePath"/>.</remarks>
        protected string FormatDetailUri<T>(T id) => $"{IndexUriRelativePath}/{id}/detail";

        /// <summary>
        /// Creates a new string representing the resource creation page URI for the given
        /// <paramref name="id"/>.
        /// </summary>
        /// <typeparam name="T">The id type, typically <see cref="int"/> or <see cref="Guid"/>.
        /// </typeparam>
        /// <param name="id">The id of the requested resource.</param>
        /// <returns>The formatted <see cref="string"/>.</returns>
        /// <remarks>Expects page to have root index paths defined by
        /// <see cref="IndexUriRelativePath"/>.</remarks>
        protected string FormatCreateUri<T>(T id) => $"{IndexUriRelativePath}/create/{id}";

        /// <summary>
        /// Creates a new string representing the resource edit page URI for the given
        /// <paramref name="id"/>.
        /// </summary>
        /// <typeparam name="T">The id type, typically <see cref="int"/> or <see cref="Guid"/>.
        /// </typeparam>
        /// <param name="id">The id of the requested resource.</param>
        /// <returns>The formatted <see cref="string"/>.</returns>
        /// <remarks>Expects page to have root index paths defined by
        /// <see cref="IndexUriRelativePath"/>.</remarks>
        protected string FormatEditUri<T>(T id) => $"{IndexUriRelativePath}/{id}/edit";
    }
}
