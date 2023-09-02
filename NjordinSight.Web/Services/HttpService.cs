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
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using NjordinSight.DataTransfer.Common;
using System.Linq;
using NjordinSight.ChangeTracking;
using Ichosys.DataModel.Expressions;
using System.Runtime.CompilerServices;

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
        /// Get the <typeparamref name="TKey"/> instanced identified by the given id value.
        /// </summary>
        /// <typeparam name="TKey">The type of record.</typeparam>
        /// <param name="id">The unique identifier for the record.</param>
        /// <returns>An instance of <typeparamref name="TKey"/> matching the value of 
        /// <paramref name="id"/>.</returns>
        Task<TKey> GetAsync<TKey>(int id);

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
        /// Selects records matching the given <paramref name="queryParameter"/>, limited to the given
        /// page index, and page size.
        /// </summary>
        /// <param name="queryParameter"><see cref="IQueryParameter{T}"/> instance describing the 
        /// query filter.</param>
        /// <param name="pageNumber">Index of the page of results to return.</param>
        /// <param name="pageSize">Limit to records returned in a single page.</param>
        /// <returns>A task containing the <see cref="IEnumerable{T}"/> of <typeparamref name="T"/> 
        /// matching the given predication and page parameters.</returns>
        Task<(IEnumerable<T>, PaginationData)> SelectAsync(
            IQueryParameter<T> queryParameter = null, int pageNumber = 1, int pageSize = 20);

        /// <summary>
        /// Selects the <typeparamref name="TRecord"/> records matching the given 
        /// <paramref name="queryParameter"/>, limited to the given
        /// page index, and page size.
        /// </summary>
        /// <param name="queryParameter"><see cref="IQueryParameter{T}"/> instance describing the 
        /// query filter.</param>
        /// <param name="pageNumber">Index of the page of results to return.</param>
        /// <param name="pageSize">Limit to records returned in a single page.</param>
        /// <returns>A task containing the <see cref="IEnumerable{T}"/> of <typeparamref name="T"/> 
        /// matching the given predication and page parameters.</returns>
        Task<(IEnumerable<TRecord>, PaginationData)> SelectAsync<TRecord>(
            IQueryParameter<TRecord> queryParameter, int pageNumber = 1, int pageSize = 20);

        [Obsolete("This interface member may be removed because it is not clear whether the " +
            "Blazor component navigation should be bundled with the service repsonsible for " +
            "sending/receiving HTTP requests to get or edit data.")]
        /// <summary>
        /// Calls navigation to the index page for the <typeparamref name="T"/> resource store.
        /// </summary>
        void NavigateToIndex();

        /// <summary>
        /// Modifies the collection in the data store by applying the given inserts, updates, and 
        /// deletes.
        /// </summary>
        /// <param name="changes">Enumerable collection of models being inserted, modified, or deleted.</param>
        /// <returns>A <see cref="Uri"/> given the location of the udpated resource.</returns>
        Task<Uri> PatchCollectionAsync(IEnumerable<(T, TrackingState)> changes);
    }

    /// <summary>
    /// Service class responsible for managing HTTP requests via a web API service and navigation 
    /// via URI.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class HttpService<T> : IHttpService<T>
    {
        private readonly string _rootApiPath;
        private readonly IHttpClientFactory _httpFactory;
        private readonly NavigationManager _navigationManager;
        private readonly IReadOnlyDictionary<Type, string> _endPointMap = 
            new Dictionary<Type, string>()
            {
                { typeof(AccountDto), "/accounts" }
            };

        /// <summary>
        /// Initializes a new instance of <see cref="IHttpService{T}"/>.
        /// </summary>
        /// <param name="httpFactory"></param>
        /// <param name="navigationManager"></param>
        /// <param name="configuration"></param>
        public HttpService(
            IHttpClientFactory httpFactory, 
            NavigationManager navigationManager, 
            IConfiguration configuration)
        {
            if (httpFactory is null)
                throw new ArgumentNullException(paramName: nameof(httpFactory));

            if (navigationManager is null)
                throw new ArgumentNullException(paramName: nameof(navigationManager));

            if (configuration is null)
                throw new ArgumentNullException(paramName: nameof(configuration));

            _httpFactory = httpFactory;
            _navigationManager = navigationManager;

            var apiOptions = new ApiOptions();
            configuration.GetSection(ApiOptions.ApiService).Bind(apiOptions);

            _rootApiPath = apiOptions.Url;
            ResourceIndexUri = CombinePath(rootPath: _rootApiPath, relativePath: _endPointMap[typeof(T)]);
        }

        /// <summary>
        /// Gets or sets the base URI for this web service.
        /// </summary>
        private string ResourceIndexUri { get; init; }

        /// <inheritdoc/>
        public async Task<T> GetAsync(int? id)
        {
            using var client = _httpFactory.CreateClient();

            return await client.GetFromJsonAsync<T>($"{ResourceIndexUri}/{id}");
        }

        /// <inheritdoc/>
        public async Task<TRecord> GetAsync<TRecord>(int id)
        {
            string relativePath = _endPointMap[typeof(TRecord)];
            string absolutePath = CombinePath(_rootApiPath, $"{relativePath}/{id}");

            using var client = _httpFactory.CreateClient();

            var response = await client.GetFromJsonAsync<TRecord>(absolutePath);

            return response;
        }

        /// <inheritdoc/>
        public async Task DeleteAsync(int id)
        {
            using var client = _httpFactory.CreateClient();

            var httpResponse =  await client.DeleteAsync($"{ResourceIndexUri}/{id}");

            httpResponse.EnsureSuccessStatusCode();
        }

        /// <inheritdoc/>
        public async Task<T> InitDefaultAsync()
        {
            using var client = _httpFactory.CreateClient();

            return await client.GetFromJsonAsync<T>($"{ResourceIndexUri}/init");
        }

        /// <inheritdoc/>
        public Task<Uri> PatchCollectionAsync(IEnumerable<(T, TrackingState)> changes)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public async Task<Uri> PostAysnc(T model)
        {
            using var client = _httpFactory.CreateClient();

            var httpResponse = await client.PostAsJsonAsync(requestUri: $"{ResourceIndexUri}", model);

            httpResponse.EnsureSuccessStatusCode();

            return httpResponse.Headers.Location;
        }

        /// <inheritdoc/>
        public async Task<Uri> PutAsync(int? id, T model)
        {
            using var client = _httpFactory.CreateClient();

            var httpResponse = await client.PutAsJsonAsync(
                requestUri: $"{ResourceIndexUri}", model, options: new(JsonSerializerDefaults.Web));

            httpResponse.EnsureSuccessStatusCode();

            return httpResponse.Headers.Location;
        }

        /// <inheritdoc/>
        public async Task<(IEnumerable<T>, PaginationData)> SelectAsync(
            IQueryParameter<T> queryParameter, int pageNumber = 1, int pageSize = 20)
        {
            // Initialize a default invalid parameter to create a filter that returns all records.
            ParameterDto<T> parameterDto = queryParameter is null ?
                new ParameterDto<T>() { MemberName = string.Empty } :
                new ParameterDto<T>
                {
                    MemberName = queryParameter.MemberName,
                    Operator = queryParameter.Operator,
                    Value = queryParameter.Value
                };

            // TODO: Convert methods to have query parameter be passed in the URI string. 

            using var client = _httpFactory.CreateClient();

            var httpResponse = await client.PostAsJsonAsync(
                $"{ResourceIndexUri}/search?&pageNumber={pageNumber}&pageSize={pageSize}", parameterDto);

            httpResponse.EnsureSuccessStatusCode();

            var deserializedResults = await httpResponse.Content.ReadFromJsonAsync<IEnumerable<T>>();

            PaginationData pageData = null!;

            if(httpResponse.Content.Headers.TryGetValues("X-Pagination", out var stringValues))
            {
                if(stringValues?.Any() ?? false)
                {
                    pageData = JsonSerializer.Deserialize<PaginationData>(stringValues.First());
                }
            }

            return (deserializedResults, pageData);
        }

        public async Task<(IEnumerable<TRecord>, PaginationData)> SelectAsync<TRecord>(
            IQueryParameter<TRecord> queryParameter, int pageNumber = 1, int pageSize = 20)
        {

            string endpoint = _endPointMap[typeof(TRecord)];
            string relativePath = CombinePath(_rootApiPath, endpoint);

            using var client = _httpFactory.CreateClient();

            var httpResponse = await client.PostAsJsonAsync(
                $"{relativePath}/search?&pageNumber={pageNumber}&pageSize={pageSize}", queryParameter);

            httpResponse.EnsureSuccessStatusCode();

            var deserializedResults = await httpResponse.Content.ReadFromJsonAsync<IEnumerable<TRecord>>();

            PaginationData pageData = null!;

            if (httpResponse.Content.Headers.TryGetValues("X-Pagination", out var stringValues))
            {
                if (stringValues?.Any() ?? false)
                {
                    pageData = JsonSerializer.Deserialize<PaginationData>(stringValues.First());
                }
            }

            return (deserializedResults, pageData);
        }

        /// <inheritdoc/>
        public void NavigateToIndex() => _navigationManager.NavigateTo(ResourceIndexUri, replace: true);

        private static string CombinePath(string rootPath, string relativePath)
        {
            var combinedString = string.Join("/", rootPath.TrimEnd('/'), relativePath.TrimStart('/'));

            return combinedString;
        }
    }
}
