using Microsoft.AspNetCore.Mvc;
using NjordinSight.DataTransfer;
using NjordinSight.DataTransfer.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NjordinSight.Api.Controllers
{
    /// <summary>
    /// Represents an API controller for pre-defined reference data queries.
    /// </summary>
    public interface IReferenceDataController
    {
        /// <summary>
        /// Gets the defined <see cref="AccountDto"/> records from the data store.
        /// </summary>
        /// <param name="pageNumber">The index of the page to retrieve.</param>
        /// <param name="pageSize">The record limit per page.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="AccountDto"/>.</returns>
        Task<ActionResult<IEnumerable<AccountDto>>> GetAccountsAsync(
            int pageNumber = 1, int pageSize = 20);

        /// <summary>
        /// Gets the defined <see cref="AccountCustodianDto"/> records from the data store.
        /// </summary>
        /// <param name="pageNumber">The index of the page to retrieve.</param>
        /// <param name="pageSize">The record limit per page.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="AccountCustodianDto"/>.</returns>
        Task<ActionResult<IEnumerable<AccountCustodianDto>>> GetCustodiansAsync(
            int pageNumber = 1, int pageSize = 20);

        /// <summary>
        /// Gets the defined <see cref="BankTransactionCodeDtoBase"/> records from the data store.
        /// </summary>
        /// <param name="pageNumber">The index of the page to retrieve.</param>
        /// <param name="pageSize">The record limit per page.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="BankTransactionCodeDtoBase"/>.</returns>
        Task<ActionResult<IEnumerable<BankTransactionCodeDtoBase>>> GetBankCodesAsync(
            int pageNumber = 1, int pageSize = 20);

        /// <summary>
        /// Gets the defined <see cref="BrokerTransactionCodeDtoBase"/> records from the data store.
        /// </summary>
        /// <param name="pageNumber">The index of the page to retrieve.</param>
        /// <param name="pageSize">The record limit per page.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="BrokerTransactionCodeDtoBase"/>.</returns>
        Task<ActionResult<IEnumerable<BrokerTransactionCodeDtoBase>>> GetBrokerCodesAsync(
            int pageNumber = 1, int pageSize = 20);

        /// <summary>
        /// Gets the defined <see cref="CountryDtoBase"/> records from the data store.
        /// </summary>
        /// <param name="pageNumber">The index of the page to retrieve.</param>
        /// <param name="pageSize">The record limit per page.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="CountryDtoBase"/>.</returns>
        Task<ActionResult<IEnumerable<CountryDtoBase>>> GetCountriesAsync(
            int pageNumber = 1, int pageSize = 20);

        /// <summary>
        /// Gets the defined <see cref="SecurityDtoBase"/> records from the data store that are deposit 
        /// sources or destinations.
        /// </summary>
        /// <param name="pageNumber">The index of the page to retrieve.</param>
        /// <param name="pageSize">The record limit per page.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="SecurityDtoBase"/>.</returns>
        Task<ActionResult<IEnumerable<SecurityDtoBase>>> GetDepositSecuritiesAsync(
            int pageNumber = 1, int pageSize = 20);

        /// <summary>
        /// Gets the defined <see cref="SecurityDtoBase"/> records from the data store that represent 
        /// crypto-currencies.
        /// </summary>
        /// <param name="pageNumber">The index of the page to retrieve.</param>
        /// <param name="pageSize">The record limit per page.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="SecurityDtoBase"/>.</returns>
        Task<ActionResult<IEnumerable<SecurityDtoBase>>> GetCryptoCurrencySecuritiesAsync(
            int pageNumber = 1, int pageSize = 20);

        /// <summary>
        /// Gets the defined <see cref="SecurityTypeDto"/> records from the data store.
        /// </summary>
        /// <param name="pageNumber">The index of the page to retrieve.</param>
        /// <param name="pageSize">The record limit per page.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="SecurityTypeDto"/>.</returns>
        Task<ActionResult<IEnumerable<SecurityTypeDto>>> GetSecurityTypesAsync(
            int pageNumber = 1, int pageSize = 20);

        /// <summary>
        /// Gets the defined <see cref="SecurityTypeGroupDto"/> records from the data store.
        /// </summary>
        /// <param name="pageNumber">The index of the page to retrieve.</param>
        /// <param name="pageSize">The record limit per page.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="SecurityTypeGroupDto"/>.</returns>
        Task<ActionResult<IEnumerable<SecurityTypeGroupDto>>> GetSecurityTypeGroupsAsync(
            int pageNumber = 1, int pageSize = 20);

        /// <summary>
        /// Gets the defined <see cref="SecurityDtoBase"/> records from the data store that are 
        /// transactable in brokerage-type accounts.
        /// </summary>
        /// <param name="pageNumber">The index of the page to retrieve.</param>
        /// <param name="pageSize">The record limit per page.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="SecurityDtoBase"/>.</returns>
        Task<ActionResult<IEnumerable<SecurityDtoBase>>> GetTransactableSecurities(
            int pageNumber = 1, int pageSize = 20);

        /// <summary>
        /// Gets the defined <see cref="ModelAttributeMemberDtoBase"/> records from the data store.
        /// </summary>
        /// <param name="attributeId">Id of the parent <see cref="ModelAttributeDtoBase"/> record.</param>
        /// <param name="pageNumber">The index of the page to retrieve.</param>
        /// <param name="pageSize">The record limit per page.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="ModelAttributeMemberDtoBase"/>.</returns>
        Task<ActionResult<IEnumerable<ModelAttributeMemberDtoBase>>> GetAttributeValuesAsync(
            int attributeId, int pageNumber = 1, int pageSize = 20);

        /// <summary>
        /// Gets the defined <see cref="SecuritySymbolTypeDto"/> records from the data store.
        /// </summary>
        /// <param name="pageNumber">The index of the page to retrieve.</param>
        /// <param name="pageSize">The record limit per page.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="ModelAttributeMemberDtoBase"/>.</returns>
        Task<ActionResult<IEnumerable<SecuritySymbolTypeDto>>> GetSecuritySymbolTypesAsync(
            int pageNumber = 1, int pageSize = 20);
    }
}
