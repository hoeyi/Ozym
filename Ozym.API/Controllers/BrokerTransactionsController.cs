using AutoMapper;
using Ichosys.DataModel.Expressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ozym.ChangeTracking;
using Ozym.DataTransfer;
using Ozym.DataTransfer.Common;
using Ozym.EntityModel;
using Ozym.EntityModelService.Abstractions;
using Ozym.EntityModelService.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Asp.Versioning;

namespace Ozym.Api.Controllers
{
    /// <inheritdoc/>
    [ApiController]
    [Route("api/v{version:apiVersion}/accounts/{id}/broker-transactions")]
    [ApiVersion("1.0")]
    public class BrokerTransactionsController : ApiCollectionController<
        BrokerTransactionDto, BrokerTransaction, AccountDto, Account>
    {
        /// <summary>
        /// Creates a new instance of <see cref="BrokerTransactionsController"/>.
        /// </summary>
        /// <param name="expressionBuilder">The expression builder for this controller.</param>
        /// <param name="mapper">The mapping service for this controller.</param>
        /// <param name="modelService">The model service for this controller.</param>
        /// <param name="queryService">The query service for this controller.</param>
        /// <param name="logger">The logging service for this controller.</param>
        public BrokerTransactionsController(
            IExpressionBuilder expressionBuilder,
            IMapper mapper,
            IModelCollectionService<BrokerTransaction> modelService, 
            IQueryService queryService, 
            ILogger logger) : base(expressionBuilder, mapper, modelService, queryService, logger)
        {
        }

        /// <inheritdoc/>
        protected override Expression<Func<BrokerTransaction, bool>> ParentPredicate(int id) =>
            x => x.AccountId == id;

        /// <inheritdoc/>
        protected override async Task<(IEnumerable<BrokerTransaction>, Account, PaginationData)> SelectAsync(
            Expression<Func<BrokerTransaction, bool>> predicate,
            int parentId,
            int pageNumber,
            int pageSize)
        {
            var (items, pagination) = await ModelService.SelectAsync(predicate, pageNumber, pageSize);
            var parent = await QueryService.GetSingleAsync<Account>(
                predicate: x => x.AccountId == parentId,
                path: x => x.AccountNavigation);

            return (items, parent, pagination);
        }

        /// <inheritdoc/>
        protected override bool VerifyParent(IEnumerable<BrokerTransactionDto> changes, int parent)
            => changes.All(x => x.AccountId == parent);
    }
}
