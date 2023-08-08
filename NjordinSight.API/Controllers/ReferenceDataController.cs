using AutoMapper;
using Ichosys.DataModel.Expressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using NjordinSight.DataTransfer.Common;
using NjordinSight.EntityModel;
using NjordinSight.EntityModelService.Query;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;
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
        public Task<ActionResult<IEnumerable<AccountDto>>> GetAccountsAsync(
            int pageNumber = 1, int pageSize = 20);

        /// <summary>
        /// Gets the defined <see cref="AccountCustodianDto"/> records from the data store.
        /// </summary>
        /// <param name="pageNumber">The index of the page to retrieve.</param>
        /// <param name="pageSize">The record limit per page.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="AccountCustodianDto"/>.</returns>
        public Task<ActionResult<IEnumerable<AccountCustodianDto>>> GetCustodiansAsync(
            int pageNumber = 1, int pageSize = 20);

        /// <summary>
        /// Gets the defined <see cref="BankTransactionCodeDtoBase"/> records from the data store.
        /// </summary>
        /// <param name="pageNumber">The index of the page to retrieve.</param>
        /// <param name="pageSize">The record limit per page.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="BankTransactionCodeDtoBase"/>.</returns>
        public Task<ActionResult<IEnumerable<BankTransactionCodeDtoBase>>> GetBankCodesAsync(
            int pageNumber = 1, int pageSize = 20);

        /// <summary>
        /// Gets the defined <see cref="BrokerTransactionCodeDtoBase"/> records from the data store.
        /// </summary>
        /// <param name="pageNumber">The index of the page to retrieve.</param>
        /// <param name="pageSize">The record limit per page.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="BrokerTransactionCodeDtoBase"/>.</returns>
        public Task<ActionResult<IEnumerable<BrokerTransactionCodeDtoBase>>> GetBrokerCodesAsync(
            int pageNumber = 1, int pageSize = 20);

        /// <summary>
        /// Gets the defined <see cref="CountryDtoBase"/> records from the data store.
        /// </summary>
        /// <param name="pageNumber">The index of the page to retrieve.</param>
        /// <param name="pageSize">The record limit per page.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="CountryDtoBase"/>.</returns>
        public Task<ActionResult<IEnumerable<CountryDtoBase>>> GetCountriesAsync(
            int pageNumber = 1, int pageSize = 20);

        /// <summary>
        /// Gets the defined <see cref="SecurityDtoBase"/> records from the data store that are deposit 
        /// sources or destinations.
        /// </summary>
        /// <param name="pageNumber">The index of the page to retrieve.</param>
        /// <param name="pageSize">The record limit per page.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="SecurityDtoBase"/>.</returns>
        public Task<ActionResult<IEnumerable<SecurityDtoBase>>> GetDepositSecuritiesAsync(
            int pageNumber = 1, int pageSize = 20);

        /// <summary>
        /// Gets the defined <see cref="SecurityDtoBase"/> records from the data store that represent 
        /// crypto-currencies.
        /// </summary>
        /// <param name="pageNumber">The index of the page to retrieve.</param>
        /// <param name="pageSize">The record limit per page.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="SecurityDtoBase"/>.</returns>
        public Task<ActionResult<IEnumerable<SecurityDtoBase>>> GetCryptoCurrencySecuritiesAsync(
            int pageNumber = 1, int pageSize = 20);

        /// <summary>
        /// Gets the defined <see cref="SecurityTypeDto"/> records from the data store.
        /// </summary>
        /// <param name="pageNumber">The index of the page to retrieve.</param>
        /// <param name="pageSize">The record limit per page.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="SecurityTypeDto"/>.</returns>
        public Task<ActionResult<IEnumerable<SecurityTypeDto>>> GetSecurityTypesAsync(
            int pageNumber = 1, int pageSize = 20);

        /// <summary>
        /// Gets the defined <see cref="SecurityTypeGroupDto"/> records from the data store.
        /// </summary>
        /// <param name="pageNumber">The index of the page to retrieve.</param>
        /// <param name="pageSize">The record limit per page.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="SecurityTypeGroupDto"/>.</returns>
        public Task<ActionResult<IEnumerable<SecurityTypeGroupDto>>> GetSecurityTypeGroupsAsync(
            int pageNumber = 1, int pageSize = 20);

        /// <summary>
        /// Gets the defined <see cref="SecurityDtoBase"/> records from the data store that are 
        /// transactable in brokerage-type accounts.
        /// </summary>
        /// <param name="pageNumber">The index of the page to retrieve.</param>
        /// <param name="pageSize">The record limit per page.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="SecurityDtoBase"/>.</returns>
        public Task<ActionResult<IEnumerable<SecurityDtoBase>>> GetTransactableSecurities(
            int pageNumber = 1, int pageSize = 20);

        /// <summary>
        /// Gets the defined <see cref="ModelAttributeMemberDtoBase"/> records from the data store.
        /// </summary>
        /// <param name="attributeId">Id of the parent <see cref="ModelAttributeDto"/> record.</param>
        /// <param name="pageNumber">The index of the page to retrieve.</param>
        /// <param name="pageSize">The record limit per page.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="ModelAttributeMemberDtoBase"/>.</returns>
        public Task<ActionResult<IEnumerable<ModelAttributeMemberDtoBase>>> GetAttributeValuesAsync(
            int attributeId, int pageNumber = 1, int pageSize = 20);
    }


    /// <summary>
    /// Represents an API controller handling calls to reference data source for use in lookup 
    /// controls or identifying valid inputs.
    /// </summary>
    [ApiController]
    [Route("api/v{version:apiVersion}/reference-data")]
    [ApiVersion("1.0")]
    public class ReferenceDataController : ControllerBase, IReferenceDataController
    {
        private readonly IExpressionBuilder _expressionBuilder;
        private readonly IQueryService _queryService;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes required parameters for <see cref="ReferenceDataController"/>.
        /// </summary>
        /// <param name="expressionBuilder"></param>
        /// <param name="mapper"></param>
        /// <param name="queryService"></param>
        /// <param name="logger"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public ReferenceDataController(
            IExpressionBuilder expressionBuilder,
            IMapper mapper,
            IQueryService queryService,
            ILogger logger)
        {
            if (expressionBuilder is null)
                throw new ArgumentNullException(paramName: nameof(expressionBuilder));  

            if (mapper is null)
                throw new ArgumentNullException(paramName: nameof(mapper)); 

            if (queryService is null)
                throw new ArgumentNullException(paramName: nameof(queryService));

            if (logger is null)
                throw new ArgumentNullException(paramName: nameof(logger));

            _expressionBuilder = expressionBuilder;
            _mapper = mapper;
            _queryService = queryService;
            _logger = logger;
        }

        /// <inheritdoc/>
        [HttpGet("accounts")]
        public virtual async Task<ActionResult<IEnumerable<AccountDto>>> GetAccountsAsync(
            int pageNumber = 1, int pageSize = 20)
        {
            var (items, pagination) = await _queryService.GetRecordSetAsync<Account>(
                predicate: x => true, pageNumber: pageNumber, pageSize: pageSize);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagination));

            var dtoItems = _mapper.Map<IEnumerable<AccountDto>>(items);

            return Ok(dtoItems);
        }

        /// <inheritdoc/>
        [HttpGet("attribute-values")]
        public Task<ActionResult<IEnumerable<ModelAttributeMemberDtoBase>>> GetAttributeValuesAsync(
            int attributeId, int pageNumber = 1, int pageSize = 20)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        [HttpGet("bank-transaction-codes")]
        public Task<ActionResult<IEnumerable<BankTransactionCodeDtoBase>>> GetBankCodesAsync(
            int pageNumber = 1, int pageSize = 20)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        [HttpGet("broker-transaction-codes")]
        public Task<ActionResult<IEnumerable<BrokerTransactionCodeDtoBase>>> GetBrokerCodesAsync(
            int pageNumber = 1, int pageSize = 20)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        [HttpGet("countries")]
        public Task<ActionResult<IEnumerable<CountryDtoBase>>> GetCountriesAsync(
            int pageNumber = 1, int pageSize = 20)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        [HttpGet("cryptocurrencies")]
        public Task<ActionResult<IEnumerable<SecurityDtoBase>>> GetCryptoCurrencySecuritiesAsync(
            int pageNumber = 1, int pageSize = 20)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        [HttpGet("custodians")]
        public Task<ActionResult<IEnumerable<AccountCustodianDto>>> GetCustodiansAsync(
            int pageNumber = 1, int pageSize = 20)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        [HttpGet("deposit-securities")]
        public Task<ActionResult<IEnumerable<SecurityDtoBase>>> GetDepositSecuritiesAsync(
            int pageNumber = 1, int pageSize = 20)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        [HttpGet("security-type-groups")]
        public Task<ActionResult<IEnumerable<SecurityTypeGroupDto>>> GetSecurityTypeGroupsAsync(
            int pageNumber = 1, int pageSize = 20)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        [HttpGet("security-types")]
        public Task<ActionResult<IEnumerable<SecurityTypeDto>>> GetSecurityTypesAsync(
            int pageNumber = 1, int pageSize = 20)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        [HttpGet("transactable-securities")]
        public Task<ActionResult<IEnumerable<SecurityDtoBase>>> GetTransactableSecurities(
            int pageNumber = 1, int pageSize = 20)
        {
            throw new NotImplementedException();
        }
    }
}
