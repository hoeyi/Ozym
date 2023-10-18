using AutoMapper;
using Ichosys.DataModel.Expressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ozym.DataTransfer;
using Ozym.DataTransfer.Common;
using Ozym.EntityModel;
using Ozym.EntityModelService.Query;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace Ozym.Api.Controllers
{


    /// <summary>
    /// Represents an API controller handling calls to reference data source for use in lookup 
    /// controls or identifying valid inputs.
    /// </summary>
    [ApiController]
    [Route("api/v{version:apiVersion}/reference")]
    [ApiVersion("1.0")]
    public class ReferenceDataController : ControllerBase, IReferenceDataController
    {
        private readonly IExpressionBuilder _expressionBuilder;
        private readonly IQueryService _queryService;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private const string PaginationKey = "X-Pagination";

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

            Response.Headers.Add(PaginationKey, JsonSerializer.Serialize(pagination));

            var dtoItems = _mapper.Map<IEnumerable<AccountDto>>(items);

            return Ok(dtoItems);
        }

        /// <inheritdoc/>
        [HttpGet("attribute-values")]
        public async Task<ActionResult<IEnumerable<ModelAttributeMemberDtoBase>>> GetAttributeValuesAsync(
            int attributeId, int pageNumber = 1, int pageSize = 20)
        {
            var (items, pagination) = await _queryService.GetRecordSetAsync<ModelAttributeMember>(
                predicate: x => x.AttributeId == attributeId,
                pageNumber: pageNumber, 
                pageSize: pageSize);

            Response.Headers.Add(PaginationKey, JsonSerializer.Serialize(pagination));

            var dtoItems = _mapper.Map<IEnumerable<ModelAttributeMemberDtoBase>>(items);

            return Ok(dtoItems);
        }

        /// <inheritdoc/>
        [HttpGet("bank-transaction-codes")]
        public async Task<ActionResult<IEnumerable<BankTransactionCodeDtoBase>>> GetBankCodesAsync(
            int pageNumber = 1, int pageSize = 20)
        {
            var (items, pagination) = await _queryService.GetRecordSetAsync<BankTransactionCode>(
                predicate: x => true, pageNumber: pageNumber, pageSize: pageSize);

            Response.Headers.Add(PaginationKey, JsonSerializer.Serialize(pagination));

            var dtoItems = _mapper.Map<IEnumerable<BankTransactionCodeDtoBase>>(items);

            return Ok(dtoItems);
        }

        /// <inheritdoc/>
        [HttpGet("broker-transaction-codes")]
        public async Task<ActionResult<IEnumerable<BrokerTransactionCodeDtoBase>>> GetBrokerCodesAsync(
            int pageNumber = 1, int pageSize = 20)
        {
            var (items, pagination) = await _queryService.GetRecordSetAsync<BrokerTransactionCode>(
                predicate: x => true, pageNumber: pageNumber, pageSize: pageSize);

            Response.Headers.Add(PaginationKey, JsonSerializer.Serialize(pagination));

            var dtoItems = _mapper.Map<IEnumerable<BrokerTransactionCodeDtoBase>>(items);

            return Ok(dtoItems);
        }

        /// <inheritdoc/>
        [HttpGet("countries")]
        public async Task<ActionResult<IEnumerable<CountryDtoBase>>> GetCountriesAsync(
            int pageNumber = 1, int pageSize = 20)
        {
            var (items, pagination) = await _queryService.CreateQueryBuilder<Country>()
                .WithDirectRelationship(a => a.AttributeMemberNavigation)
                .Build()
                .SelectAsync(
                    predicate: x => true,
                    pageNumber: pageNumber,
                    pageSize: pageSize);

            Response.Headers.Add(PaginationKey, JsonSerializer.Serialize(pagination));

            var dtoItems = _mapper.Map<IEnumerable<CountryDtoBase>>(items);

            return Ok(dtoItems);
        }

        /// <inheritdoc/>
        [HttpGet("crypto-currencies")]
        public async Task<ActionResult<IEnumerable<SecurityDtoBase>>> GetCryptoCurrencySecuritiesAsync(
            int pageNumber = 1, int pageSize = 20)
        {
            using var queryBuilder = _queryService.CreateQueryBuilder<Security>()
                .WithDirectRelationship(x => x.SecurityType)
                .WithIndirectRelationship<SecurityType, SecurityTypeGroup>(y => y.SecurityTypeGroup);

            var (items, pagination) = await queryBuilder.Build().SelectAsync(
                predicate: x => x.SecurityType.HeldInWallet == true,
                pageNumber: pageNumber,
                pageSize: pageSize);

            Response.Headers.Add(PaginationKey, JsonSerializer.Serialize(pagination));

            var dtoItems = _mapper.Map<IEnumerable<SecurityDtoBase>>(items);

            return Ok(dtoItems);
        }

        /// <inheritdoc/>
        [HttpGet("custodians")]
        public async Task<ActionResult<IEnumerable<AccountCustodianDto>>> GetCustodiansAsync(
            int pageNumber = 1, int pageSize = 20)
        {
            var (items, pagination) = await _queryService.GetRecordSetAsync<AccountCustodian>(
                predicate: x => true,
                pageNumber: pageNumber,
                pageSize: pageSize);

            Response.Headers.Add(PaginationKey, JsonSerializer.Serialize(pagination));

            var dtoItems = _mapper.Map<IEnumerable<AccountCustodianDto>>(items);

            return Ok(dtoItems);
        }

        /// <inheritdoc/>
        [HttpGet("deposit-securities")]
        public async Task<ActionResult<IEnumerable<SecurityDtoBase>>> GetDepositSecuritiesAsync(
            int pageNumber = 1, int pageSize = 20)
        {
            using var queryBuilder = _queryService.CreateQueryBuilder<Security>()
                .WithDirectRelationship(x => x.SecurityType)
                .WithIndirectRelationship<SecurityType, SecurityTypeGroup>(y => y.SecurityTypeGroup);

            var (items, pagination) = await queryBuilder.Build().SelectAsync(
                    predicate: x => x.SecurityType.SecurityTypeGroup.DepositSource == true,
                    pageNumber: pageNumber,
                    pageSize: pageSize);

            Response.Headers.Add(PaginationKey, JsonSerializer.Serialize(pagination));

            var dtoItems = _mapper.Map<IEnumerable<SecurityDtoBase>>(items);

            return Ok(dtoItems);
        }

        /// <inheritdoc/>
        [HttpGet("security-type-groups")]
        public async Task<ActionResult<IEnumerable<SecurityTypeGroupDto>>> GetSecurityTypeGroupsAsync(
            int pageNumber = 1, int pageSize = 20)
        {
            var (items, pagination) = await _queryService.GetRecordSetAsync<SecurityTypeGroup>(
                predicate: x => true,
                pageNumber: pageNumber,
                pageSize: pageSize);

            Response.Headers.Add(PaginationKey, JsonSerializer.Serialize(pagination));

            var dtoItems = _mapper.Map<IEnumerable<SecurityTypeGroupDto>>(items);

            return Ok(dtoItems);
        }

        /// <inheritdoc/>
        [HttpGet("security-types")]
        public async Task<ActionResult<IEnumerable<SecurityTypeDto>>> GetSecurityTypesAsync(
            int pageNumber = 1, int pageSize = 20)
        {
            var (items, pagination) = await _queryService.GetRecordSetAsync<SecurityType>(
                predicate: x => true,
                pageNumber: pageNumber,
                pageSize: pageSize);

            Response.Headers.Add(PaginationKey, JsonSerializer.Serialize(pagination));

            var dtoItems = _mapper.Map<IEnumerable<SecurityTypeDto>>(items);

            return Ok(dtoItems);
        }

        /// <inheritdoc/>
        [HttpGet("transactable-securities")]
        public async Task<ActionResult<IEnumerable<SecurityDtoBase>>> GetTransactableSecurities(
            int pageNumber = 1, int pageSize = 20)
        {
            using var queryBuilder = _queryService.CreateQueryBuilder<Security>()
                .WithDirectRelationship(a => a.SecurityType)
                .WithIndirectRelationship<SecurityType, SecurityTypeGroup>(x => x.SecurityTypeGroup);

            var (items, pagination) = await queryBuilder
                .Build()
                .SelectAsync(
                    predicate: x => x.SecurityType.SecurityTypeGroup.Transactable == true,
                    pageNumber: pageNumber,
                    pageSize: pageSize);

            Response.Headers.Add(PaginationKey, JsonSerializer.Serialize(pagination));

            var dtoItems = _mapper.Map<IEnumerable<SecurityDtoBase>>(items);

            return Ok(dtoItems);
        }

        /// <inheritdoc/>
        [HttpGet("symbol-types")]
        public async Task<ActionResult<IEnumerable<SecuritySymbolTypeDto>>> GetSecuritySymbolTypesAsync(
            int pageNumber = 1, int pageSize = 20)
        {
            using var queryBuilder = _queryService.CreateQueryBuilder<SecuritySymbolType>();

            var (items, pagination) = await queryBuilder
                .Build()
                .SelectAsync(
                    predicate: x => true,
                    pageNumber: pageNumber,
                    pageSize: pageSize);

            Response.Headers.Add(PaginationKey, JsonSerializer.Serialize(pagination));

            var dtoItems = _mapper.Map<IEnumerable<SecuritySymbolTypeDto>>(items);

            return Ok(dtoItems);
        }
    }
}
