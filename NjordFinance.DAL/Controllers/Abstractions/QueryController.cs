using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NjordFinance.EntityModelService;
using NjordFinance.EntityModelService.Query;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NjordFinance.Controllers.Abstractions
{
    /// <summary>
    /// Base class for handling requests for lookup data-transfer objects for pre-defined 
    /// use cases.
    /// </summary>
    public partial class QueryController : ControllerBase, IQueryController
    {
        private readonly IQueryService _queryService;
        private readonly ILogger _logger;
        public QueryController(IQueryService queryService, ILogger logger)
        {
            if (queryService is null)
                throw new ArgumentNullException(paramName: nameof(queryService));

            if (logger is null)
                throw new ArgumentNullException(paramName: nameof(logger));

            _queryService = queryService;
            _logger = logger;
        }

        /// <inheritdoc/>
        public async Task<ActionResult<IEnumerable<LookupModel<TKey, TValue>>>> 
            GetDtosAsync<TSource, TKey, TValue>(
                Expression<Func<TSource, TKey>> key, 
                Expression<Func<TSource, TValue>> display, 
                TKey defaultKey = default, 
                TValue defaultDisplay = default)
            where TSource : class, new()
        {
            var task = _queryService.SelectDTOsAsync(
                key,
                display,
                defaultKey,
                defaultDisplay);

            return await task.ContinueWith(x =>
                new ActionResult<IEnumerable<LookupModel<TKey, TValue>>>(x.Result));
        }

        /// <inheritdoc/>
        public async Task<ActionResult<IEnumerable<TSource>>> GetManyAsync<TSource>(
            Expression<Func<TSource, bool>> predicate, 
            Expression<Func<TSource, object>> path = null) where TSource : class, new()
        {
            return new ActionResult<IEnumerable<TSource>>(
                await _queryService.GetManyAsync(predicate, path));
        }

        /// <inheritdoc/>
        public async Task<ActionResult<TSource>> GetSingleAsync<TSource>(
            Expression<Func<TSource, bool>> predicate, 
            Expression<Func<TSource, object>> path = null) 
            where TSource : class, new()
        {
            return new ActionResult<TSource>(await _queryService.GetSingleAsync(
                predicate: predicate,
                path: path));
        }

        /// <inheritdoc/>
        async Task<ActionResult<IEnumerable<LookupModel<int, string>>>>
            IQueryController.GetAccountCustodianDTOsAsync()
        {
            return new ActionResult<IEnumerable<LookupModel<int, string>>>(
                await _queryService.GetAccountCustodianDTOsAsync());
        }

        /// <inheritdoc/>
        async Task<ActionResult<IEnumerable<LookupModel<int, string>>>>
            IQueryController.GetAccountDTOsAsync()
        {
            return new ActionResult<IEnumerable<LookupModel<int, string>>>(
                await _queryService.GetAccountDTOsAsync());
        }

        /// <inheritdoc/>
        async Task<ActionResult<IEnumerable<LookupModel<int, string>>>>
            IQueryController.GetBankTransactionCodeDTOsAsync()
        {
            return new ActionResult<IEnumerable<LookupModel<int, string>>>(
                await _queryService.GetBankTransactionCodeDTOsAsync());
        }

        /// <inheritdoc/>
        async Task<ActionResult<IEnumerable<LookupModel<int, string>>>>
            IQueryController.GetBrokerTransactionCodeDTOsAsync()
        {
            return new ActionResult<IEnumerable<LookupModel<int, string>>>(
                await _queryService.GetBrokerTransactionCodeDTOsAsync());
        }

        /// <inheritdoc/>
        async Task<ActionResult<IEnumerable<LookupModel<int, string>>>>
            IQueryController.GetCashOrExternalSecurityDTOsAsync()
        {
            return new ActionResult<IEnumerable<LookupModel<int, string>>>(
                await _queryService.GetCashOrExternalSecurityDTOsAsync());
        }

        /// <inheritdoc/>
        async Task<ActionResult<IEnumerable<LookupModel<int, string>>>>
            IQueryController.GetCryptocurrencyDTOsAsync()
        {
            return new ActionResult<IEnumerable<LookupModel<int, string>>>(
                await _queryService.GetCryptocurrencyDTOsAsync());
        }

        /// <inheritdoc/>
        async Task<ActionResult<IEnumerable<LookupModel<int, string>>>>
            IQueryController.GetMarketIndexDTOsAsync()
        {
            return new ActionResult<IEnumerable<LookupModel<int, string>>>(
                await _queryService.GetMarketIndexDTOsAsync());
        }

        /// <inheritdoc/>
        async Task<ActionResult<IEnumerable<LookupModel<int, string>>>>
            IQueryController.GetModelAttributeMemberDTOsAsync(int attributeId)
        {
            return new ActionResult<IEnumerable<LookupModel<int, string>>>(
                await _queryService.GetModelAttributeMemberDTOsAsync(attributeId));
        }

        /// <inheritdoc/>
        async Task<ActionResult<IEnumerable<LookupModel<int, string>>>>
            IQueryController.GetSecurityTypeDTOsAsync()
        {
            return new ActionResult<IEnumerable<LookupModel<int, string>>>(
                await _queryService.GetSecurityTypeDTOsAsync());
        }

        /// <inheritdoc/>
        async Task<ActionResult<IEnumerable<LookupModel<int, string>>>>
            IQueryController.GetSecurityTypeGroupDTOsAsync()
        {
            return new ActionResult<IEnumerable<LookupModel<int, string>>>(
                await _queryService.GetSecurityTypeGroupDTOsAsync());
        }

        /// <inheritdoc/>
        async Task<ActionResult<IEnumerable<LookupModel<int, string>>>>
            IQueryController.GetTransactableSecurityDTOsAsync()
        {
            return new ActionResult<IEnumerable<LookupModel<int, string>>>(
                await _queryService.GetTransactableSecurityDTOsAsync());
        }
    }
}
