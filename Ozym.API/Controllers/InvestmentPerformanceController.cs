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

namespace Ozym.Api.Controllers
{
    /// <inheritdoc/>
    [ApiController]
    [Route("api/v{version:apiVersion}/accounts/{id}/performance")]
    [ApiVersion("1.0")]
    public class InvestmentPerformanceController : ApiCollectionController<
        InvestmentPerformanceDto, InvestmentPerformanceEntry, AccountDto, Account>
    {
        /// <summary>
        /// Creates a new instance of <see cref="InvestmentPerformanceController"/>.
        /// </summary>
        /// <param name="expressionBuilder">The expression builder for this controller.</param>
        /// <param name="mapper">The mapping service for this controller.</param>
        /// <param name="modelService">The model service for this controller.</param>
        /// <param name="queryService">The query service for this controller.</param>
        /// <param name="logger">The logging service for this controller.</param>
        public InvestmentPerformanceController(
            IExpressionBuilder expressionBuilder,
            IMapper mapper,
            IModelCollectionService<InvestmentPerformanceEntry> modelService,
            IQueryService queryService,
            ILogger logger) : base(expressionBuilder, mapper, modelService, queryService, logger)
        {
        }

        /// <inheritdoc/>
        protected override Expression<Func<InvestmentPerformanceEntry, bool>> ParentPredicate(int id) 
            => x => x.AccountObjectId == id;

        /// <inheritdoc/>
        protected override async 
            Task<(IEnumerable<InvestmentPerformanceEntry>, Account, PaginationData)> SelectAsync(
                Expression<Func<InvestmentPerformanceEntry, bool>> predicate,
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
        protected override bool VerifyParent(IEnumerable<InvestmentPerformanceDto> changes, int parent)
            => changes.All(x => x.AccountBaseId == parent);
    }
}
