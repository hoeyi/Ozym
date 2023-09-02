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
    [Route("api/v{version:apiVersion}/market-indices/{id}/rates")]
    [ApiVersion("1.0")]
    public class MarketIndexPricesController : ApiCollectionController<
        MarketIndexPriceDtoBase, MarketIndexPrice, MarketIndexDto, MarketIndex>
    {
        /// <summary>
        /// Creates a new instance of <see cref="MarketIndexPricesController"/>.
        /// </summary>
        /// <param name="expressionBuilder">The expression builder for this controller.</param>
        /// <param name="mapper">The mapping service for this controller.</param>
        /// <param name="modelService">The model service for this controller.</param>
        /// <param name="queryService">The query service for this controller.</param>
        /// <param name="logger">The logging service for this controller.</param>
        public MarketIndexPricesController(
            IExpressionBuilder expressionBuilder,
            IMapper mapper,
            IModelCollectionService<MarketIndexPrice> modelService,
            IQueryService queryService,
            ILogger logger) : base(expressionBuilder, mapper, modelService, queryService, logger)
        {
        }

        /// <inheritdoc/>
        protected override Expression<Func<MarketIndexPrice, bool>> ParentPredicate(int id)
            => x => x.MarketIndexId == id;

        /// <inheritdoc/>
        protected override async
            Task<(IEnumerable<MarketIndexPrice>, MarketIndex, PaginationData)> SelectAsync(
                Expression<Func<MarketIndexPrice, bool>> predicate,
                int parentId,
                int pageNumber,
                int pageSize)
        {
            var (items, pagination) = await ModelService.SelectAsync(predicate, pageNumber, pageSize);
            var parent = await QueryService.GetSingleAsync<MarketIndex>(
                predicate: x => x.IndexId == parentId);

            return (items, parent, pagination);
        }

        /// <inheritdoc/>
        protected override bool VerifyParent(
            IEnumerable<(MarketIndexPriceDtoBase, TrackingState)> changes,
            int parent)
                => changes.Any(x => x.Item1.MarketIndexId != parent);
    }
}
