using AutoMapper;
using Ichosys.DataModel.Expressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NjordinSight.ChangeTracking;
using NjordinSight.DataTransfer;
using NjordinSight.DataTransfer.Common;
using NjordinSight.EntityModel;
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
    [Route("api/v{version:apiVersion}/accounts/{id}/wallets")]
    [ApiVersion("1.0")]
    public class AccountWalletsController : ApiCollectionController<
        AccountWalletDto, AccountWallet, AccountDto, Account>
    {
        /// <summary>
        /// Creates a new instance of <see cref="AccountWalletsController"/>.
        /// </summary>
        /// <param name="expressionBuilder">The expression builder for this controller.</param>
        /// <param name="mapper">The mapping service for this controller.</param>
        /// <param name="modelService">The model service for this controller.</param>
        /// <param name="queryService">The query service for this controller.</param>
        /// <param name="logger">The logging service for this controller.</param>
        public AccountWalletsController(
            IExpressionBuilder expressionBuilder,
            IMapper mapper,
            IModelCollectionService<AccountWallet> modelService,
            IQueryService queryService,
            ILogger logger) : base(expressionBuilder, mapper, modelService, queryService, logger)
        {
        }

        /// <inheritdoc/>
        protected override Expression<Func<AccountWallet, bool>> ParentPredicate(int id) =>
            x => x.AccountId == id;

        /// <inheritdoc/>
        protected override async Task<(IEnumerable<AccountWallet>, Account, PaginationData)> SelectAsync(
            Expression<Func<AccountWallet, bool>> predicate,
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
        protected override bool VerifyParent(IEnumerable<AccountWalletDto> changes, int parent)
            => changes.Any(x => x.AccountId != parent);
    }
}
