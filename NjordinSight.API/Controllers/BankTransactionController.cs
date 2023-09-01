using AutoMapper;
using Ichosys.DataModel.Expressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NjordinSight.ChangeTracking;
using NjordinSight.DataTransfer;
using NjordinSight.DataTransfer.Common;
using NjordinSight.DataTransfer.Common.Query;
using NjordinSight.EntityModel;
using NjordinSight.EntityModelService;
using NjordinSight.EntityModelService.Abstractions;
using NjordinSight.EntityModelService.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NjordinSight.Api.Controllers
{
    /// <inheritdoc/>
    [ApiController]
    [Route("api/v{version:apiVersion}/bank-transactions")]
    [ApiVersion("1.0")]
    public class BankTransactionController : ApiCollectionController<
        BankTransactionDto, BankTransaction, AccountDto, Account>
    {
        /// <inheritdoc/>
        public BankTransactionController(
            IExpressionBuilder expressionBuilder, 
            IMapper mapper,
            IModelCollectionService<BankTransaction> modelService, 
            IQueryService queryService,
            ILogger logger) : base(expressionBuilder, mapper, modelService, queryService, logger)
        {
        }

        /// <inheritdoc/>
        protected override Expression<Func<BankTransaction, bool>> ParentPredicate(int id) =>
            x => x.AccountId == id;

        /// <inheritdoc/>
        protected override async Task<(IEnumerable<BankTransaction>, Account, PaginationData)> SelectAsync(
            Expression<Func<BankTransaction, bool>> predicate, 
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
        protected override bool VerifyParent(
            IEnumerable<(BankTransactionDto, TrackingState)> changes, int parent) 
                => changes.Any(x => x.Item1.AccountId != parent);
    }
}
