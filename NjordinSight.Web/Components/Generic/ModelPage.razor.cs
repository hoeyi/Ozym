using Ichosys.DataModel.Annotations;
using NjordinSight.UserInterface;
using NjordinSight.Web.Components.Common;
using System;
using System.Linq;
using System.Reflection;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using NjordinSight.EntityModelService;
using Microsoft.AspNetCore.Mvc;
using Ichosys.DataModel;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using NjordinSight.Web.Services;
using System.Net.Http;
using Radzen;

namespace NjordinSight.Web.Components.Generic
{
    public partial class ModelPage<TModelDto> : ModelComponent<TModelDto>, INavigationSource
        where TModelDto : class
    {
        #nullable enable
        private MenuRoot? _sectionNavigationMenu;
        private NounAttribute? _modelNoun;
        private string? _indexUriRelativePath;

        

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
        /// Gets the <see cref="MenuRoot"/> containing available actions for this component.
        /// The default is null.
        /// </summary>
        protected MenuRoot? SectionNavigationMenu
        {
            get
            {
                _sectionNavigationMenu ??= CreateSectionNavigationMenu();
                return _sectionNavigationMenu;
            }
        }

        /// <summary>
        /// Gets the <see cref="NounAttribute"/> associated with <typeparamref name="TModelDto"/>.
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
        protected IPageTitle PageTitle => IPageTitle.GetTitleFor<TModelDto>();

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

        /// <summary>
        /// Processes a navigation request
        /// </summary>
        /// <param name="id"></param>
        protected void ProcessDetailAtAction(object? id)
        {
            if(id is not null)
                NavigationHelper.NavigateTo(FormatDetailUri(id));
        }

        /// <summary>
        /// Base method to create a new <see cref="MenuRoot"/> instance. Default implementation 
        /// returns <see cref="null"/>.
        /// </summary>
        /// <returns>An instance of <see cref="MenuRoot"/> or null.</returns>
        protected virtual MenuRoot? CreateSectionNavigationMenu() => null;

#nullable disable

        /// <summary>
        /// Checks the current page state and returns true if all required properties have been 
        /// set. Inheritors may override this method to handle additional initialization checks.
        /// </summary>
        /// <returns>True if the page is loading, else false.</returns>
        protected virtual bool PageDataIsLoading() => false;

        /// <summary>
        /// Runs the given task catching exceptions of type <see cref="HttpRequestException"/>.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="task"></param>
        /// <returns>A <see cref="Task{TResult}"/> from the </returns>
        protected async Task<TResult> RunCatchingHttpRequestException<TResult>(Task<TResult> task)
            => await RunCatchingException<TResult, HttpRequestException>(task);

        /// <summary>
        /// Runs the given task catching exceptions of type <see cref="HttpRequestException"/>.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="task"></param>
        /// <returns>A <see cref="Task"/> from the </returns>
        protected async Task RunCatchingHttpRequestException(Task task)
            => await RunCatchingException<HttpRequestException>(task);

        /// <summary>
        /// Runs the given <see cref="Task"/> and handles 
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        private async Task RunCatchingException<TException>(Task task)
            where TException : Exception
        {
            await task.ContinueWith(x =>
            {
                if (x.Status == TaskStatus.Faulted && x.Exception is not null)
                {
                    InvokeAsync(() => ErrorMessage = x.Exception.Message);
                    throw x.Exception;
                }
            });
        }

        // TODO: Expand use of this function to other Exception types.
        /// <summary>
        /// Runs the given <see cref="Task"/> and handles <typeparamref name="TException"/> exceptions 
        /// raised while performing the task operation.
        /// </summary>
        /// <typeparam name="TResult">The task return type.</typeparam>
        /// <typeparam name="TException">The handled exception type.</typeparam>
        /// <param name="task">The task that for which <typeparamref name="TException"/> handling 
        /// is applied.</param>
        /// <returns>A <see cref="Task{TResult}"/> represesnting an asynchronous operation.</returns>
        private async Task<TResult> RunCatchingException<TResult, TException>(Task<TResult> task)
            where TException : Exception
        {
            return await task.ContinueWith(x =>
            {
                if (x.Status == TaskStatus.Faulted && x.Exception.InnerException is TException)
                {
                    InvokeAsync(() => ErrorMessage = x.Exception.Message);
                    throw x.Exception;
                }
                return task.Result;
            });
        }
    }
}
