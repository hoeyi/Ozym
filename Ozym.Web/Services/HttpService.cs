using Ozym.DataTransfer;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Ozym.DataTransfer.Common.Query;
using Microsoft.Extensions.Configuration;
using Ozym.DataTransfer.Common;
using System.Linq;
using Ozym.ChangeTracking;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using Ozym.DataTransfer.Common.Collections;
using System.Net.Http.Headers;

namespace Ozym.Web.Services
{
    /// <summary>
    /// Service class responsible for managing HTTP requests via a web API service and navigation 
    /// via URI.
    /// </summary>
    /// <typeparam name="T">The type of resource this service interacts with.</typeparam>
    public partial class HttpService<T>
    {
        private readonly string _rootApiPath;
        private readonly IReadOnlyDictionary<Type, string> _endPointMap =
            new Dictionary<Type, string>()
            {
                { typeof(AccountDto), "/accounts" },
                { typeof(AccountCompositeDto), "/composites" },
                { typeof(AccountCustodianDto), "/custodians" },
                { typeof(AccountWalletDto), "/accounts/{0}/wallets" },
                { typeof(BankTransactionCodeDto), "/bank-transaction-codes" },
                { typeof(BankTransactionDto), "/accounts/{0}/bank-transactions" },
                { typeof(BrokerTransactionCodeDto), "/broker-transaction-codes" },
                { typeof(BrokerTransactionDto), "/accounts/{0}/broker-transactions" },
                { typeof(CountryDto), "/countries" },
                { typeof(CountryDtoBase), "/countries" },
                { typeof(InvestmentModelDto), "/investment-models" },
                { typeof(MarketHolidayObservanceDto), "/holidays/observances" },
                { typeof(MarketIndexPriceDto), "/market-indices/rates" },
                { typeof(MarketIndexPriceDtoBase), "/market-indices/rates" },
                { typeof(MarketIndexDto), "/market-indices" },
                { typeof(ModelAttributeDto), "/attributes" },
                { typeof(ModelAttributeDtoBase), "/attributes" },
                { typeof(ReportConfigurationDto), "/report-configurations" },
                { typeof(ReportStyleSheetDto), "/style-sheets" },
                { typeof(SecurityDto), "/securities" },
                { typeof(SecurityDtoBase), "/securities" },
                { typeof(SecurityExchangeDto), "/exchanges" },
                { typeof(SecurityPriceDto), "/securities/prices" },
                { typeof(SecurityTypeDto), "/security-types" },
                { typeof(SecurityTypeGroupDto), "/security-type-groups" }
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

            HttpFactory = httpFactory;

            var apiOptions = new ApiOptions();
            configuration.GetSection(ApiOptions.ApiService).Bind(apiOptions);

            _rootApiPath = "http://ozymapi/api/v1";
            ResourceIndexUri = CombinePath(rootPath: _rootApiPath, relativePath: _endPointMap[typeof(T)]);
        }

        protected IHttpClientFactory HttpFactory { get; init; }

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

            using var client = HttpFactory.CreateClient();

            var response = await client.GetFromJsonAsync<TRecord>(absolutePath);

            return response;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<TRecord>> GetAllAsync<TRecord>()
        {
            string relativePath = _endPointMap[typeof(TRecord)];
            string absolutePath = CombinePath(_rootApiPath, $"{relativePath}/all");

            using var client = HttpFactory.CreateClient();

            var response = await client.GetFromJsonAsync<IEnumerable<TRecord>>(absolutePath);

            return response;
        }

        /// <inheritdoc/>
        public async Task<(IEnumerable<TRecord>, PaginationData)> SearchAsync<TRecord>(
            ParameterDto<TRecord> queryParameter, int pageNumber = 1, int pageSize = 20)
        {

            string endpoint = _endPointMap[typeof(TRecord)];
            string relativePath = CombinePath(_rootApiPath, endpoint);

            using var client = HttpFactory.CreateClient();

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

        protected async Task<(TRepsonse, PaginationData)> SearchAsync<TRepsonse>(
            string requestUri, ParameterDto<T> parameter)
        {
            if (parameter is null)
                throw new ArgumentNullException(paramName: nameof(parameter));

            using var client = HttpFactory.CreateClient();

            var httpResponse = await client.PostAsJsonAsync(requestUri, parameter);

            httpResponse.EnsureSuccessStatusCode();

            var deserializedResults = await httpResponse.Content.ReadFromJsonAsync<TRepsonse>();

            PaginationData pageData = null!;

            if (httpResponse.Headers.TryGetValues("X-Pagination", out var stringValues))
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
            if (string.IsNullOrEmpty(rootPath))
                return relativePath;

            var combinedString = string.Join("/", rootPath.TrimEnd('/'), relativePath.TrimStart('/'));

            return combinedString;
        }
    }
    
    public partial class HttpService<T> : IHttpService<T>
    {
        /// <inheritdoc/>
        public async Task<T> GetAsync(int? id)
        {
            using var client = HttpFactory.CreateClient();

            var response = await client.GetAsync($"{ResourceIndexUri}/{id}");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<T>();
        }

        /// <inheritdoc/>
        public async Task<(IEnumerable<T>, PaginationData)> IndexAsync(
            int pageNumber = 1, int pageSize = 20)
        {
            using var client = HttpFactory.CreateClient();

            var httpResponse = await client.GetAsync(
                $"{ResourceIndexUri}?&pageNumber={pageNumber}&pageSize={pageSize}");

            try
            {
                httpResponse.EnsureSuccessStatusCode();
            }
            catch(HttpRequestException hre)
            {
                System.Diagnostics.Debug.WriteLine(hre);
            }


            var deserializedResults = await httpResponse.Content.ReadFromJsonAsync<IEnumerable<T>>();

            PaginationData pageData = null!;

            if (httpResponse.Headers.TryGetValues("X-Pagination", out var stringValues))
            {
                if (stringValues?.Any() ?? false)
                {
                    pageData = JsonSerializer.Deserialize<PaginationData>(stringValues.First());
                }
            }

            return (deserializedResults, pageData);
        }

        /// <inheritdoc/>
        public async Task DeleteAsync(int id)
        {
            using var client = HttpFactory.CreateClient();

            var httpResponse =  await client.DeleteAsync($"{ResourceIndexUri}/{id}");

            httpResponse.EnsureSuccessStatusCode();
        }

        /// <inheritdoc/>
        public async Task<T> InitDefaultAsync()
        {
            using var client = HttpFactory.CreateClient();

            return await client.GetFromJsonAsync<T>($"{ResourceIndexUri}/init");
        }

        /// <inheritdoc/>
        public async Task<CreationRecord<TKey, T>> PostAysnc<TKey>(T model)
        {
            using var client = HttpFactory.CreateClient();

            var httpResponse = await client.PostAsJsonAsync(requestUri: $"{ResourceIndexUri}", model);

            httpResponse.EnsureSuccessStatusCode();

            var creationRecord = await httpResponse.Content
                                        .ReadFromJsonAsync<CreationRecord<TKey, T>>();

            return creationRecord;
        }

        /// <inheritdoc/>
        public async Task<Uri> PutAsync(int id, T model)
        {
            using var client = HttpFactory.CreateClient();

            var httpResponse = await client.PutAsJsonAsync(
                requestUri: $"{ResourceIndexUri}/{id}", model, options: new(JsonSerializerDefaults.Web));

            httpResponse.EnsureSuccessStatusCode();

            return httpResponse.Headers.Location;
        }

        /// <inheritdoc/>
        public async Task<(IEnumerable<T>, PaginationData)> SearchAsync(
            ParameterDto<T> parameter, int pageNumber = 1, int pageSize = 20)
        {
            if(parameter is null)
                throw new ArgumentNullException(paramName: nameof(parameter));

            string requestUri = $"{ResourceIndexUri}/search?&pageNumber={pageNumber}&pageSize={pageSize}";

            return await SearchAsync<IEnumerable<T>>(requestUri, parameter);
        }
    }

    public partial class HttpService<T> : IHttpCollectionService<T>
    {
        /// <inheritdoc/>
        public async Task<int> PatchCollectionAsync(IEnumerable<(T, TrackingState)> changes)
        {
            using var client = HttpFactory.CreateClient();

            IDictionary<TrackingState, IEnumerable<T>> changeDocument = 
                changes.GroupBy(x => x.Item2, y => y.Item1)
                    .ToDictionary(x => x.Key, y => y.AsEnumerable());

            var httpResponse = await client.PostAsJsonAsync(
                requestUri: $"{ResourceIndexUri}",
                value: changeDocument,
                options: new JsonSerializerOptions(JsonSerializerDefaults.Web) { IncludeFields = true });

            httpResponse.EnsureSuccessStatusCode();

            return await httpResponse.Content.ReadFromJsonAsync<int>();
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
        public async Task<(IEnumerable<T>, TParent, PaginationData)> IndexAsync<TParent>(
            TParentKey parent, int pageNumber = 1, int pageSize = 20)
        {
            using var client = HttpFactory.CreateClient();

            var httpResponse = await client.GetAsync(
                $"{string.Format(ResourceIndexUri, parent)}?&pageNumber={pageNumber}&pageSize={pageSize}");

            httpResponse.EnsureSuccessStatusCode();

            var deserializedResults = await httpResponse.Content
                                            .ReadFromJsonAsync<IndexWithParentResponse<TParent>>();

            PaginationData pageData = null!;

            if (httpResponse.Headers.TryGetValues("X-Pagination", out var stringValues))
            {
                if (stringValues?.Any() ?? false)
                {
                    pageData = JsonSerializer.Deserialize<PaginationData>(stringValues.First());
                }
            }

            return (deserializedResults.Entries, deserializedResults.Parent, pageData);
        }

        /// <inheritdoc/>
        public async Task<int> PatchCollectionAsync(
            IEnumerable<(T, TrackingState)> changes, TParentKey parent)
        {
            using var client = HttpFactory.CreateClient();

            IDictionary<TrackingState, IEnumerable<T>> changeDocument =
                changes.GroupBy(x => x.Item2, y => y.Item1)
                    .ToDictionary(x => x.Key, y => y.AsEnumerable());

            var httpResponse = await client.PostAsJsonAsync(
                requestUri: $"{string.Format(ResourceIndexUri, parent)}",
                value: changeDocument,
                options: new JsonSerializerOptions(JsonSerializerDefaults.Web) { IncludeFields = true });

            httpResponse.EnsureSuccessStatusCode();

            return await httpResponse.Content.ReadFromJsonAsync<int>();
        }

        /// <inheritdoc/>
        public async Task<(IEnumerable<T>, TParent, PaginationData)> SearchAsync<TParent>(
            TParentKey parent, ParameterDto<T> parameter, int pageNumber = 1, int pageSize = 20)
        {
            if (parameter is null)
                throw new ArgumentNullException(paramName: nameof(parameter));

            string requestUri = CombinePath(
                rootPath: string.Format(ResourceIndexUri, parent),
                relativePath: $"/search?&pageNumber={pageNumber}&pageSize={pageSize}");

            var (response, pageData) = 
                await SearchAsync<IndexWithParentResponse<TParent>>(requestUri, parameter);

            return (response.Entries, response.Parent, pageData);
        }

        private class IndexWithParentResponse<TParent>
        {
            public IEnumerable<T> Entries { get; init; } = new List<T>();

            public TParent Parent { get; init; }
        }
    }
}
