using Ozym.DataTransfer.Common;
using Ozym.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Ozym.DataTransfer;
using Ozym.DataTransfer.Common.Generic;
using Ozym.EntityModel.Annotations;
using System.Reflection;

namespace Ozym.EntityModelService.Query
{
    /// <summary>
    /// Represents the interface for built-in queries.
    /// </summary>
    public interface IBuiltInQuery
    {
        /// <summary>
        /// Gets the account custodian DTOs asynchronously.
        /// </summary>
        /// <param name="predicate">The predicate to filter the DTOs.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the account custodian DTOs and pagination data.</returns>
        Task<(IEnumerable<AccountCustodianDto>, PaginationData)> GetAccountCustodianDTOsAsync(
            Expression<Func<AccountCustodianDto, bool>> predicate = null,
            int pageNumber = 1,
            int pageSize = 20);

        /// <summary>
        /// Gets the account DTOs asynchronously.
        /// </summary>
        /// <param name="predicate">The predicate to filter the DTOs.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the account DTOs and pagination data.</returns>
        Task<(IEnumerable<AccountSimpleDto>, PaginationData)> GetAccountDTOsAsync(
            Expression<Func<AccountSimpleDto, bool>> predicate = null,
            int pageNumber = 1,
            int pageSize = 20);

        /// <summary>
        /// Gets the bank transaction code DTOs asynchronously.
        /// </summary>
        /// <param name="predicate">The predicate to filter the DTOs.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the bank transaction code DTOs and pagination data.</returns>
        Task<(IEnumerable<BankTransactionCodeDtoBase>, PaginationData)> GetBankTransactionCodeDTOsAsync(
            Expression<Func<BankTransactionCodeDtoBase, bool>> predicate = null,
            int pageNumber = 1,
            int pageSize = 20);

        /// <summary>
        /// Gets the broker transaction code DTOs asynchronously.
        /// </summary>
        /// <param name="predicate">The predicate to filter the DTOs.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the broker transaction code DTOs and pagination data.</returns>
        Task<(IEnumerable<BrokerTransactionCodeDtoBase>, PaginationData)> GetBrokerTransactionCodeDTOsAsync(
            Expression<Func<BrokerTransactionCodeDtoBase, bool>> predicate = null,
            int pageNumber = 1,
            int pageSize = 20);

        /// <summary>
        /// Gets the cash or external security DTOs asynchronously.
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the cash or external security DTOs and pagination data.</returns>
        Task<(IEnumerable<SecurityDtoBase>, PaginationData)> GetCashOrExternalSecurityDTOsAsync(
            int pageNumber = 1,
            int pageSize = 20);

        /// <summary>
        /// Gets the cryptocurrency DTOs asynchronously.
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the cryptocurrency DTOs and pagination data.</returns>
        Task<(IEnumerable<SecurityDtoBase>, PaginationData)> GetCryptocurrencyDTOsAsync(
            int pageNumber = 1,
            int pageSize = 20);

        /// <summary>
        /// Gets a subset of the currently defined issuers in the security information file asynchronously.
        /// </summary>
        /// <param name="pattern">The pattern to match the issuers.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the issuers and pagination data.</returns>
        Task<(IEnumerable<string>, PaginationData)> GetIssuersAsync(
            string pattern = null, int pageNumber = 1, int pageSize = 20);

        /// <summary>
        /// Gets the market index DTOs asynchronously.
        /// </summary>
        /// <param name="predicate">The predicate to filter the DTOs.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the market index DTOs and pagination data.</returns>
        Task<IEnumerable<KeyValuePair<int, string>>> GetMarketIndexDTOsAsync(
            Expression<Func<MarketIndexDto, bool>> predicate = null,
            int pageNumber = 1,
            int pageSize = 20);

        /// <summary>
        /// Gets the model attribute member DTOs asynchronously.
        /// </summary>
        /// <param name="predicate">The predicate to filter the DTOs.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the model attribute member DTOs and pagination data.</returns>
        Task<IEnumerable<KeyValuePair<int, string>>> GetModelAttributeMemberDTOsAsync(
            Expression<Func<ModelAttributeMemberDtoBase, bool>> predicate = null,
            int pageNumber = 1,
            int pageSize = 20);

        /// <summary>
        /// Gets the security DTOs asynchronously.
        /// </summary>
        /// <param name="predicate">The predicate to filter the DTOs.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the security DTOs and pagination data.</returns>
        Task<IEnumerable<KeyValuePair<int, string>>> GetSecurityDTOsAsync(
            Expression<Func<SecurityDtoBase, bool>> predicate = null,
            int pageNumber = 1,
            int pageSize = 20);

        /// <summary>
        /// Gets the security symbol types asynchronously.
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the security symbol types and pagination data.</returns>
        Task<(IEnumerable<SecuritySymbolTypeDto>, PaginationData)> GetSecuritySymbolTypesAsync(
            int pageNumber = 1, int pageSize = 20);

        /// <summary>
        /// Gets the security type DTOs asynchronously.
        /// </summary>
        /// <param name="predicate">The predicate to filter the DTOs.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the security type DTOs and pagination data.</returns>
        Task<(IEnumerable<SecurityTypeDto>, PaginationData)> GetSecurityTypeDTOsAsync(
            Expression<Func<SecurityTypeDto, bool>> predicate = null,
            int pageNumber = 1,
            int pageSize = 20);

        /// <summary>
        /// Gets the security type group DTOs asynchronously.
        /// </summary>
        /// <param name="predicate">The predicate to filter the DTOs.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the security type group DTOs and pagination data.</returns>
        Task<(IEnumerable<SecurityTypeGroupDto>, PaginationData)> GetSecurityTypeGroupDTOsAsync(
            Expression<Func<SecurityTypeGroupDto, bool>> predicate = null,
            int pageNumber = 1,
            int pageSize = 20);

        /// <summary>
        /// Gets the supported attributes asynchronously for the specified attribute entry view model type.
        /// </summary>
        /// <typeparam name="T">The type of the attribute entry view model.</typeparam>
        /// <returns>A task that represents the asynchronous operation. The task result contains the supported attributes.</returns>
        Task<IEnumerable<ModelAttributeDto>> GetSupportedAttributesAsync<T>()
            where T : IAttributeEntryViewModel;

        /// <summary>
        /// Gets the transactable security DTOs asynchronously.
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the transactable security DTOs and pagination data.</returns>
        Task<(IEnumerable<SecurityDtoBase>, PaginationData)> GetTransactableSecurityDTOsAsync(
            int pageNumber = 1,
            int pageSize = 20);

        /// <summary>
        /// Gets the display map for the market index price code constraint.
        /// </summary>
        /// <param name="placeHolderDelegate">The delegate used to provide placeholder key-value pairs.</param>
        /// <returns>An <see cref="IDictionary{TKey, TValue}"/> where the key is the bound string and the value is the display string.</returns>
        IDictionary<string, string> GetMarketIndexPriceCodeDisplayMap(
            Func<KeyValuePair<string, string>> placeHolderDelegate = null);

        /// <summary>
        /// Gets the display map for the model attribute scope.
        /// </summary>
        /// <param name="placeHolderDelegate">The delegate used to provide placeholder key-value pairs.</param>
        /// <returns>An <see cref="IDictionary{TKey, TValue}"/> where the key is the bound string and the value is the display string.</returns>
        IDictionary<string, string> GetModelAttributeScopeDisplayMap(
            Func<KeyValuePair<string, string>> placeHolderDelegate = null);

        /// <summary>
        /// Gets the supported attribute scope codes for the specified attribute entry view model type.
        /// </summary>
        /// <typeparam name="T">The type of the attribute entry view model.</typeparam>
        /// <returns>A <see cref="string[]"/> containing the codes representing each supported attribute scope, or an empty array.</returns>
        public static string[] GetSupportedAttributeScopeCodes<T>()
            where T : IAttributeEntryViewModel =>
            typeof(T).GetCustomAttribute<ModelAttributeSupportAttribute>()
            ?.SupportedScopes.ToStringArray() ?? Array.Empty<string>();
    }
}
