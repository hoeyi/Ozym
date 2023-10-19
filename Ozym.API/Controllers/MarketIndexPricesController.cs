using Asp.Versioning;
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
