using Ichosys.DataModel.Annotations;
using NjordinSight.UserInterface;
using NjordinSight.Web.Components.Shared;
using System;
using System.Linq;
using System.Reflection;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using NjordinSight.EntityModelService;
using Microsoft.AspNetCore.Mvc;

namespace NjordinSight.Web.Components.Generic
{
    public partial class ModelPage<TModelDto> : ModelComponent<TModelDto>, INavigationSource
    {
#nullable enable
        private NounAttribute? _modelNoun;
        private string? _indexUriRelativePath;
        /// <summary>
        /// Gets or sets the <see cref="MenuRoot"/> containing available actions for this component.
        /// </summary>
        protected MenuRoot? ActionMenu { get; set; }

        /// <summary>
        /// Gets the <see cref="NounAttribute"/> associated with <typeparamref name="TModel"/>.
        /// </summary>
        protected NounAttribute ModelNoun
        {
            get
            {
                _modelNoun ??= ModelMetadata.GetAttribute<TModelDto, NounAttribute>();
                return _modelNoun;
            }
        }

        /// <summary>
        /// Gets the <see cref="IPageTitle"/> instance for this page.
        /// </summary>
        protected IPageTitle PageTitle => DisplayHelper.GetPagetTitle<TModelDto>();

        /// <summary>
        /// Gets or sets the current text describing this page's error state.
        /// </summary>
        protected string? ErrorMessage { get; set; }

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

        /// <summary>
        /// Gets the value associated with the first public <typeparamref name="TKey"/> member 
        /// that has the <see cref="KeyAttribute"/> applied. Composite keys are not supported.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="model"></param>
        /// <returns>The <typeparamref name="TKey"/> uniquely identifying the given 
        /// <typeparamref name="TModelDto"/>, or null if undefined.</returns>
        protected static TKey? GetKeyValueOrDefault<TKey>(TModelDto model)
        {
            if (model is null)
                throw new ArgumentNullException(paramName: nameof(model));

            var memberInfo = typeof(TModelDto).GetProperties(
                BindingFlags.Instance | BindingFlags.Public).Where(
                a => a.PropertyType == typeof(TKey) &&
                a.GetCustomAttribute<KeyAttribute>() is not null)
                .FirstOrDefault();

            if (memberInfo?.GetValue(model) is TKey key)
                return key;
            else
                return default;
        }
        protected void ProcessCreatedAtAction(CreatedAtActionResult? createdAtAction)
        {
            object? obj = createdAtAction?.RouteValues?["id"];

            if (obj is not null)
                NavigationHelper.NavigateTo(FormatDetailUri(obj));
        }

        protected void ProcessDetailAtAction(object? id)
        {
            if(id is not null)
                NavigationHelper.NavigateTo(FormatDetailUri(id));
        }

#nullable disable

        /// <summary>
        /// Runs an asynchronous operation catching <see cref="ModelUpdateException"/> throws 
        /// and handling via an update to <see cref="ErrorMessage"/>.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="task"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing an asychronous operation, else
        /// null if the specified exception is caused a status of faulted.</returns>
        protected async Task<TResult> RunCatchingModelUpdateException<TResult>(
            Task<TResult> task) => await RunCatchingException<TResult, ModelUpdateException>(task);

        // TODO: Expand use of this function to other Exception types.
        private async Task<TResult> RunCatchingException<TResult, TException>(
            Task<TResult> task)
            where TException : ModelUpdateException
        {
            return await task.ContinueWith(x =>
            {
                if (x.Status == TaskStatus.Faulted && x.Exception.InnerException is TException)
                {
                    InvokeAsync(() => ErrorMessage = x.Exception.Message);
                    return default;
                }
                return task.Result;
            });
        }
    }
}
