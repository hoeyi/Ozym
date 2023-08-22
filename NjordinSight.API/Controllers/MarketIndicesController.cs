using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NjordinSight.DataTransfer.Common;
using NjordinSight.EntityModel;
using NjordinSight.EntityModelService;
using Microsoft.Extensions.Logging;
using Ichosys.DataModel.Expressions;

namespace NjordinSight.Api.Controllers
{
    /// <inheritdoc/>
    [ApiController]
    [Route("api/v{version:apiVersion}/market-indices")]
    [ApiVersion("1.0")]
    public class MarketIndicesController : ApiController<MarketIndexDto, MarketIndex>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MarketIndicesController"/> class.
        /// </summary>
        /// <param name="expressionBuilder">The <see cref="IExpressionBuilder"/> for this instance.</param>
        /// <param name="mapper">The <see cref="IMapper"/> for this instance.</param>
        /// <param name="modelService">The <see cref="IModelService{T}"/> for this instance.</param>
        /// <param name="logger">The <see cref="ILogger"/> for this instance.</param>
        public MarketIndicesController(
            IExpressionBuilder expressionBuilder,
            IMapper mapper,
            IModelService<MarketIndex> modelService,
            ILogger logger)
            : base(expressionBuilder, mapper, modelService, logger)
        {
        }
    }
}
