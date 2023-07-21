using Microsoft.AspNetCore.Components;
using NjordinSight.DataTransfer;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Mime;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;
using NjordinSight.DataTransfer.Common.Query;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace NjordinSight.Web.Services
{
    /// <summary>
    /// Interface representing methods for interacting with a RESTful web api.
    /// </summary>
    public interface IHttpService<T>
    {
        /// <summary>
        /// Deletes the <typeparamref name="T"/> resource matching the given identifier.
        /// </summary>
        /// <param name="id">Identifer of the resource to delete.</param>
        /// <returns>Task representing a completed deletion request.</returns>
        Task DeleteAsync(int id);

        /// <summary>
        /// Gets the <typeparamref name="T"/> resource matching the given identifier.
        /// </summary>
        /// <param name="id">The integer key to match.</param>
        /// <returns>The <typeparamref name="T"/> identified by <paramref name="id"/>.</returns>
        Task<T> GetAsync(int? id);

        /// <summary>
        /// Creates a default instance of <typeparamref name="T"/>.
        /// </summary>
        /// <returns>An instance of <typeparamref name="T"/>.
        Task<T> InitDefaultAsync();

        /// <summary>
        /// Posts the given <typeparamref name="T"/> resource to the data store.
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A task containing the <see cref="Uri"/> for the created resource.</returns>
        Task<Uri> PostAysnc(T model);

        /// <summary>
        /// Replaces the <typeparamref name="T"/> resource matching the given identifier.
        /// </summary>
        /// <param name="model">The <typeparamref name="T"/> model to update.</param>
        /// <returns>A task containing the <see cref="Uri"/> for the created resource.</returns>
        Task<Uri> PutAsync(int? id, T model);

        /// <summary>
        /// Selects records matching the given <paramref name="predicate"/>, limited to the given
        /// page index, and page size.
        /// </summary>
        /// <param name="queryParameter"><see cref="ParameterDto{T}"/> to filter results.</param>
        /// <param name="pageNumber">Number of the page of results to return.</param>
        /// <param name="pageSize">Limit to records returned in a single page.</param>
        /// <returns>A task containing the <see cref="IEnumerable{T}"/> of <typeparamref name="T"/> 
        /// matching the given predication and page parameters.</returns>
        Task<IEnumerable<T>> SelectAsync(
            ParameterDto<T> queryParameter = null, int pageNumber = 1, int pageSize = 20);

        /// <summary>
        /// Calls navigation to the index page for the <typeparamref name="T"/> resource store.
        /// </summary>
        void NavigateToIndex();
    }

    /// <summary>
    /// Service class responsible for managing HTTP requests via a web API service and navigation 
    /// via URI.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class HttpService<T> : IHttpService<T>
    {
#pragma warning disable IDE0052 // Remove unread private members
        private readonly IHttpClientFactory _httpFactory;
        private readonly NavigationManager _navigationManager;
#pragma warning restore IDE0052 // Remove unread private members

        /// <summary>
        /// Initializes a new instance of <see cref="IHttpService{T}"/>.
        /// </summary>
        /// <param name="httpFactory"></param>
        /// <param name="navigationManager"></param>
        public HttpService(IHttpClientFactory httpFactory, NavigationManager navigationManager)
        {
            if (httpFactory is null)
                throw new ArgumentNullException(paramName: nameof(httpFactory));

            if (navigationManager is null)
                throw new ArgumentNullException(paramName: nameof(navigationManager));

            _httpFactory = httpFactory;
            _navigationManager = navigationManager;
        }

        /// <summary>
        /// Gets or sets the base URI for this web service.
        /// </summary>
        private string BaseUri { get; init; }

        /// <inheritdoc/>
        public async Task<T> GetAsync(int? id)
        {
            using var client = _httpFactory.CreateClient();

            return await client.GetFromJsonAsync<T>($"{BaseUri}/{id}");
        }

        /// <inheritdoc/>
        public async Task DeleteAsync(int id)
        {
            using var client = _httpFactory.CreateClient();

            var httpResponse =  await client.DeleteAsync($"{BaseUri}/{id}");

            httpResponse.EnsureSuccessStatusCode();
        }

        /// <inheritdoc/>
        public async Task<T> InitDefaultAsync()
        {
            using var client = _httpFactory.CreateClient();

            return await client.GetFromJsonAsync<T>($"{BaseUri}/init");
        }
        
        /// <inheritdoc/>
        public async Task<Uri> PostAysnc(T model)
        {
            using var client = _httpFactory.CreateClient();

            var httpResponse = await client.PostAsJsonAsync(
                requestUri: $"{BaseUri}", model, options: new(JsonSerializerDefaults.Web));

            httpResponse.EnsureSuccessStatusCode();

            return httpResponse.Headers.Location;
        }

        /// <inheritdoc/>
        public async Task<Uri> PutAsync(int? id, T model)
        {
            using var client = _httpFactory.CreateClient();

            var httpResponse = await client.PutAsJsonAsync(
                requestUri: $"{BaseUri}", model, options: new(JsonSerializerDefaults.Web));

            httpResponse.EnsureSuccessStatusCode();

            return httpResponse.Headers.Location;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<T>> SelectAsync(
            #pragma warning disable IDE0060 // Remove unused parameter
            ParameterDto<T> queryParameter, int pageNumber = 1, int pageSize = 20)
            #pragma warning restore IDE0060 // Remove unused parameter
        {
            // TODO: Convert methods to have query parameter be passed in the URI string. 
            // For now no filter parameters will be provided.

            //var jsonContent = JsonContent.Create(
            //    queryParameter, options: new(JsonSerializerDefaults.Web));
            
            using var client = _httpFactory.CreateClient();

            return await client.GetFromJsonAsync<IEnumerable<T>>(
                requestUri: $"{BaseUri}?pageNumber={pageNumber}&pageSize={pageSize}");
        }

        /// <inheritdoc/>
        public void NavigateToIndex() => _navigationManager.NavigateTo(BaseUri, replace: true);
    }
}
