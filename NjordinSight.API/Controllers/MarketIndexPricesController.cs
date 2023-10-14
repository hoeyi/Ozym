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
    [Route("api/v{version:apiVersion}/market-indices/rates")]
    [ApiVersion("1.0")]
    public class MarketIndexPricesController : ApiCollectionController<
        MarketIndexPriceDtoBase, MarketIndexPrice>
    {
        /// <summary>
        /// Creates a new instance of <see cref="MarketIndexPricesController"/>.
        /// </summary>
        /// <param name="expressionBuilder">The expression builder for this controller.</param>
        /// <param name="mapper">The mapping service for this controller.</param>
        /// <param name="modelService">The model service for this controller.</param>
        /// <param name="logger">The logging service for this controller.</param>
        public MarketIndexPricesController(
            IExpressionBuilder expressionBuilder,
            IMapper mapper,
            IModelCollectionService<MarketIndexPrice> modelService,
            ILogger logger) : base(expressionBuilder, mapper, modelService, logger)
        {
        }
    }
}
