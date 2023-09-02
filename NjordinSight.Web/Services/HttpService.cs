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
using System.Drawing.Printing;

namespace NjordinSight.Web.Services
{
    /// <summary>
    /// Service class responsible for managing HTTP requests via a web API service and navigation 
    /// via URI.
    /// </summary>
    /// <typeparam name="T">The type of resource this service interacts with.</typeparam>
    public partial class HttpService<T>
    {
        private readonly string _rootApiPath;
        private readonly IHttpClientFactory _httpFactory;
        private readonly IReadOnlyDictionary<Type, string> _endPointMap =
            new Dictionary<Type, string>()
            {
                { typeof(AccountDto), "/accounts" },
                { typeof(BankTransactionDto), "/accounts/{0}/bank-transactions" }
            };

        /// <summary>
        /// Initializes a new instance of <see cref="HttpService{T}"/>.
        /// </summary>
        /// <param name="httpFactory"></param>
        /// <param name="navigationManager"></param>
        /// <param name="configuration"></param>
        public HttpService(
            IHttpClientFactory httpFactory,
            IConfiguration configuration)
        {
            if (httpFactory is null)
                throw new ArgumentNullException(paramName: nameof(httpFactory));

            if (configuration is null)
                throw new ArgumentNullException(paramName: nameof(configuration));

            _httpFactory = httpFactory;

            var apiOptions = new ApiOptions();
            configuration.GetSection(ApiOptions.ApiService).Bind(apiOptions);

            _rootApiPath = apiOptions.Url;
            ResourceIndexUri = CombinePath(rootPath: _rootApiPath, relativePath: _endPointMap[typeof(T)]);
        }

        /// <summary>
        /// Gets or sets the base URI for this web service.
        /// </summary>
        protected string ResourceIndexUri { get; init; }
    }

    public partial class HttpService<T> : IHttpService
    {
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
        public async Task<(IEnumerable<TRecord>, PaginationData)> SearchAsync<TRecord>(
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

        protected async Task<(IEnumerable<T>, PaginationData)> SearchAsync(
            string requestUri, IQueryParameter<T> parameter)
        {
            if (parameter is null)
                throw new ArgumentNullException(paramName: nameof(parameter));

            using var client = _httpFactory.CreateClient();

            var httpResponse = await client.PostAsJsonAsync(requestUri, parameter);

            httpResponse.EnsureSuccessStatusCode();

            var deserializedResults = await httpResponse.Content.ReadFromJsonAsync<IEnumerable<T>>();

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

        protected static string CombinePath(string rootPath, string relativePath)
        {
            var combinedString = string.Join("/", rootPath.TrimEnd('/'), relativePath.TrimStart('/'));

            return combinedString;
        }
    }
    
    public partial class HttpService<T> : IHttpService<T>
    {
        /// <inheritdoc/>
        public async Task<T> GetAsync(int? id)
        {
            using var client = _httpFactory.CreateClient();

            return await client.GetFromJsonAsync<T>($"{ResourceIndexUri}/{id}");
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
        public async Task<(IEnumerable<T>, PaginationData)> SearchAsync(
            IQueryParameter<T> parameter, int pageNumber = 1, int pageSize = 20)
        {
            if(parameter is null)
                throw new ArgumentNullException(paramName: nameof(parameter));

            string requestUri = $"{ResourceIndexUri}/search?&pageNumber={pageNumber}&pageSize={pageSize}";

            return await SearchAsync(requestUri, parameter);
        }
    }

    public partial class HttpService<T> : IHttpCollectionService<T>
    {
        /// <inheritdoc/>
        public Task<Uri> PatchCollectionAsync(IEnumerable<(T, TrackingState)> changes)
        {
            throw new NotImplementedException();
        }
    }

    public class HttpService<T, TParentKey> : HttpService<T>, IHttpCollectionService<T, TParentKey>
    {
        /// <summary>
        /// Initializes a new instance of <see cref="HttpService{T, TParentKey}"/>.
        /// </summary>
        /// <param name="httpFactory"></param>
        /// <param name="navigationManager"></param>
        /// <param name="configuration"></param>
        public HttpService(
            IHttpClientFactory httpFactory,
            IConfiguration configuration) : base(httpFactory, configuration)
        {
        }

        /// <inheritdoc/>
        public Task<Uri> PatchCollectionAsync(
            IEnumerable<(T, TrackingState)> changes, TParentKey parent)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public async Task<(IEnumerable<T>, PaginationData)> SearchAsync(
            TParentKey parent, IQueryParameter<T> parameter, int pageNumber = 1, int pageSize = 20)
        {
            if (parameter is null)
                throw new ArgumentNullException(paramName: nameof(parameter));

            string requestUri = CombinePath(
                rootPath: string.Format(ResourceIndexUri, parent),
                relativePath: $"/search?&pageNumber={pageNumber}&pageSize={pageSize}");

            return await SearchAsync(requestUri, parameter);
        }
    }
}
