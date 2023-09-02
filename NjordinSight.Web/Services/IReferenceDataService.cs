using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NjordinSight.DataTransfer;
using NjordinSight.DataTransfer.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using NjordinSight.EntityModelService;
using System.Linq.Expressions;

namespace NjordinSight.Web.Services
{
    public interface IReferenceDataService
    {
        /// <summary>
        /// Gets the defined <see cref="AccountDto"/> records from the data store.
        /// </summary>
        /// <param name="pageNumber">The index of the page to retrieve.</param>
        /// <param name="pageSize">The record limit per page.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="AccountDto"/>.</returns>
        public Task<(IEnumerable<AccountDto>, PaginationData)> GetAccountsAsync(
            int pageNumber = 1, int pageSize = 20);

        /// <summary>
        /// Gets the defined <see cref="AccountCustodianDto"/> records from the data store.
        /// </summary>
        /// <param name="pageNumber">The index of the page to retrieve.</param>
        /// <param name="pageSize">The record limit per page.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="AccountCustodianDto"/>.</returns>
        public Task<(IEnumerable<AccountCustodianDto>, PaginationData)> GetCustodiansAsync(
            int pageNumber = 1, int pageSize = 20);

        /// <summary>
        /// Gets the defined <see cref="BankTransactionCodeDtoBase"/> records from the data store.
        /// </summary>
        /// <param name="pageNumber">The index of the page to retrieve.</param>
        /// <param name="pageSize">The record limit per page.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="BankTransactionCodeDtoBase"/>.</returns>
        public Task<(IEnumerable<BankTransactionCodeDtoBase>, PaginationData)> GetBankCodesAsync(
            int pageNumber = 1, int pageSize = 20);

        /// <summary>
        /// Gets the defined <see cref="BrokerTransactionCodeDtoBase"/> records from the data store.
        /// </summary>
        /// <param name="pageNumber">The index of the page to retrieve.</param>
        /// <param name="pageSize">The record limit per page.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="BrokerTransactionCodeDtoBase"/>.</returns>
        public Task<(IEnumerable<BrokerTransactionCodeDtoBase>, PaginationData)> GetBrokerCodesAsync(
            int pageNumber = 1, int pageSize = 20);

        /// <summary>
        /// Gets the defined <see cref="CountryDtoBase"/> records from the data store.
        /// </summary>
        /// <param name="pageNumber">The index of the page to retrieve.</param>
        /// <param name="pageSize">The record limit per page.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="CountryDtoBase"/>.</returns>
        public Task<(IEnumerable<CountryDtoBase>, PaginationData)> GetCountriesAsync(
            int pageNumber = 1, int pageSize = 20);

        /// <summary>
        /// Gets the defined <see cref="SecurityDtoBase"/> records from the data store that are deposit 
        /// sources or destinations.
        /// </summary>
        /// <param name="pageNumber">The index of the page to retrieve.</param>
        /// <param name="pageSize">The record limit per page.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="SecurityDtoBase"/>.</returns>
        public Task<(IEnumerable<SecurityDtoBase>, PaginationData)> GetDepositSecuritiesAsync(
            int pageNumber = 1, int pageSize = 20);

        /// <summary>
        /// Gets the defined <see cref="SecurityDtoBase"/> records from the data store that represent 
        /// crypto-currencies.
        /// </summary>
        /// <param name="pageNumber">The index of the page to retrieve.</param>
        /// <param name="pageSize">The record limit per page.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="SecurityDtoBase"/>.</returns>
        public Task<(IEnumerable<SecurityDtoBase>, PaginationData)> GetCryptoCurrencySecuritiesAsync(
            int pageNumber = 1, int pageSize = 20);

        /// <summary>
        /// Gets the defined <see cref="SecurityTypeDto"/> records from the data store.
        /// </summary>
        /// <param name="pageNumber">The index of the page to retrieve.</param>
        /// <param name="pageSize">The record limit per page.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="SecurityTypeDto"/>.</returns>
        public Task<(IEnumerable<SecurityTypeDto>, PaginationData)> GetSecurityTypesAsync(
            int pageNumber = 1, int pageSize = 20);

        /// <summary>
        /// Gets the defined <see cref="SecurityTypeGroupDto"/> records from the data store.
        /// </summary>
        /// <param name="pageNumber">The index of the page to retrieve.</param>
        /// <param name="pageSize">The record limit per page.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="SecurityTypeGroupDto"/>.</returns>
        public Task<(IEnumerable<SecurityTypeGroupDto>, PaginationData)>  GetSecurityTypeGroupsAsync(
            int pageNumber = 1, int pageSize = 20);

        /// <summary>
        /// Gets the defined <see cref="SecurityDtoBase"/> records from the data store that are 
        /// transactable in brokerage-type accounts.
        /// </summary>
        /// <param name="pageNumber">The index of the page to retrieve.</param>
        /// <param name="pageSize">The record limit per page.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="SecurityDtoBase"/>.</returns>
        public Task<(IEnumerable<SecurityDtoBase>, PaginationData)> GetTransactableSecurities(
            int pageNumber = 1, int pageSize = 20);

        /// <summary>
        /// Gets the defined <see cref="ModelAttributeMemberDtoBase"/> records from the data store.
        /// </summary>
        /// <param name="attributeId">Id of the parent <see cref="ModelAttributeDto"/> record.</param>
        /// <param name="pageNumber">The index of the page to retrieve.</param>
        /// <param name="pageSize">The record limit per page.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="ModelAttributeMemberDtoBase"/>.</returns>
        public Task<(IEnumerable<ModelAttributeMemberDtoBase>, PaginationData)> GetAttributeValuesAsync(
            int attributeId, int pageNumber = 1, int pageSize = 20);

        /// <summary>
        /// Converts the given <typeparamref name="TEnum"/> members to a key-value map 
        /// for display values.
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <typeparam name="TKey">The key type for the resulting map.</typeparam>
        /// <typeparam name="TValue">The value type for the resulting map.</typeparam>
        /// <param name="predicate">Predicate to filter the member results.</param>
        /// <param name="key">Expression describing the method to assign the key value for each record.</param>
        /// <param name="display">Expression describing the method to assign the display value for each record.</param>
        /// <param name="placeHolderDelegate">Delegate for creating a placehold/defult entry.</param>
        /// <returns>A collection of key-value assignments, where the value is the display value 
        /// for the record.</returns>
        public IDictionary<TKey, TValue> CreateEnumerableDisplayMap<TEnum, TKey, TValue>(
            Func<TEnum, bool> predicate,
            Expression<Func<TEnum, TKey>> key,
            Expression<Func<TEnum, TValue>> display,
            Func<KeyValuePair<TKey, TValue>> placeHolderDelegate = null)
            where TEnum : struct, Enum
        {
            var keyDeleg = key.Compile();
            var displayDeleg = display.Compile();

            var results = Enum.GetValues(typeof(TEnum)).Cast<TEnum>()
                .Where(predicate)
                .ToDictionary(x => keyDeleg(x), x => displayDeleg(x));

            if (placeHolderDelegate is not null)
            {
                var placeHolder = placeHolderDelegate.Invoke();
                results.Add(placeHolder.Key, placeHolder.Value);
            }

            return results;
        }
    }

    public class ReferenceDataService : IReferenceDataService
    {
        private readonly IHttpClientFactory _httpFactory;
        private readonly string _baseApiUri;

        /// <summary>
        /// Initializes a new instance of <see cref="ReferenceDataService"/>.
        /// </summary>
        /// <param name="httpFactory"></param>
        /// <param name="configuration"></param>
        public ReferenceDataService(
            IHttpClientFactory httpFactory, IConfiguration configuration)
        {
            if (httpFactory is null)
                throw new ArgumentNullException(paramName: nameof(httpFactory));

            if (configuration is null)
                throw new ArgumentNullException(paramName: nameof(configuration));

            _httpFactory = httpFactory;

            var apiOptions = new ApiOptions();
            configuration.GetSection(ApiOptions.ApiService).Bind(apiOptions);

            _baseApiUri = CombinePath(rootPath: apiOptions.Url, relativePath: "/reference");
        }
        private async Task<(IEnumerable<T>, PaginationData)> GetAsync<T>(
            string endPoint, int pageNumber = 1, int pageSize = 20)
        {
            if (string.IsNullOrEmpty(endPoint))
                throw new ArgumentNullException(paramName: nameof(endPoint));

            using var client = _httpFactory.CreateClient();

            var httpResponse = await client.GetAsync(
                $"{_baseApiUri}/{endPoint}?&pageNumber={pageNumber}&pageSize={pageSize}");

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

        public async Task<(IEnumerable<AccountDto>, PaginationData)> GetAccountsAsync(
            int pageNumber = 1, int pageSize = 20)
        {
            return await GetAsync<AccountDto>(endPoint: "accounts", pageNumber, pageSize);
        }

        public async Task<(IEnumerable<ModelAttributeMemberDtoBase>, PaginationData)> GetAttributeValuesAsync(
            int attributeId, int pageNumber = 1, int pageSize = 20)
        {
            using var client = _httpFactory.CreateClient();

            var httpResponse = await client.GetAsync(
                $"{_baseApiUri}/attribute-values?&attributeId={attributeId}&pageNumber={pageNumber}&pageSize={pageSize}");

            httpResponse.EnsureSuccessStatusCode();

            var deserializedResults = await httpResponse.Content
                .ReadFromJsonAsync<IEnumerable<ModelAttributeMemberDtoBase>>();

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

        public async Task<(IEnumerable<BankTransactionCodeDtoBase>, PaginationData)> GetBankCodesAsync(
            int pageNumber = 1, int pageSize = 20)
        {
            return await GetAsync<BankTransactionCodeDtoBase>(
                endPoint: "bank-transaction-codes", pageNumber, pageSize);
        }

        public async Task<(IEnumerable<BrokerTransactionCodeDtoBase>, PaginationData)> GetBrokerCodesAsync(
            int pageNumber = 1, int pageSize = 20)
        {
            return await GetAsync<BrokerTransactionCodeDtoBase>(
                endPoint: "broker-transaction-codes", pageNumber, pageSize);
        }

        public async Task<(IEnumerable<CountryDtoBase>, PaginationData)> GetCountriesAsync(
            int pageNumber = 1, int pageSize = 20)
        {
            return await GetAsync<CountryDtoBase>(endPoint: "countries", pageNumber, pageSize);
        }

        public async Task<(IEnumerable<SecurityDtoBase>, PaginationData)> GetCryptoCurrencySecuritiesAsync(
            int pageNumber = 1, int pageSize = 20)
        {
            return await GetAsync<SecurityDtoBase>(
                endPoint: "crypto-currencies", pageNumber, pageSize);
        }

        public async Task<(IEnumerable<AccountCustodianDto>, PaginationData)> GetCustodiansAsync(
            int pageNumber = 1, int pageSize = 20)
        {
            return await GetAsync<AccountCustodianDto>(endPoint: "custodians", pageNumber, pageSize);
        }

        public async Task<(IEnumerable<SecurityDtoBase>, PaginationData)> GetDepositSecuritiesAsync(
            int pageNumber = 1, int pageSize = 20)
        {
            return await GetAsync<SecurityDtoBase>(
                endPoint: "deposit-securities", pageNumber, pageSize);
        }

        public async Task<(IEnumerable<SecurityTypeGroupDto>, PaginationData)> GetSecurityTypeGroupsAsync(
            int pageNumber = 1, int pageSize = 20)
        {
            return await GetAsync<SecurityTypeGroupDto>(
                endPoint: "security-type-groups", pageNumber, pageSize);
        }

        public async Task<(IEnumerable<SecurityTypeDto>, PaginationData)> GetSecurityTypesAsync(
            int pageNumber = 1, int pageSize = 20)
        {
            return await GetAsync<SecurityTypeDto>(
                endPoint: "security-types", pageNumber, pageSize);
        }

        public async Task<(IEnumerable<SecurityDtoBase>, PaginationData)> GetTransactableSecurities(
            int pageNumber = 1, int pageSize = 20)
        {
            return await GetAsync<SecurityDtoBase>(
                endPoint: "transactable-securities", pageNumber, pageSize);
        }

        

        private static string CombinePath(string rootPath, string relativePath)
        {
            var combinedString = string.Join("/", rootPath.TrimEnd('/'), relativePath.TrimStart('/'));

            return combinedString;
        }
    }
}
