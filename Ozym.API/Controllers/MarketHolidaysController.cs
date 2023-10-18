using AutoMapper;
using Ichosys.DataModel.Expressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ozym.DataTransfer.Common;
using Ozym.EntityModel;
using Ozym.EntityModelService.Abstractions;

namespace Ozym.Api.Controllers
{
    /// <inheritdoc/>
    [ApiController]
    [Route("api/v{version:apiVersion}/holidays/observances")]
    [ApiVersion("1.0")]
    public class MarketHolidaysController 
        : ApiCollectionController<MarketHolidayObservanceDto, MarketHolidayObservance>
    {
        /// <summary>
        /// Creates a new instance of <see cref="MarketHolidaysController"/>.
        /// </summary>
        /// <param name="expressionBuilder">The expression helper service for this controller.</param>
        /// <param name="mapper">The mapping service for this controller.</param>
        /// <param name="modelService">The model service for this controller.</param>
        /// <param name="logger">The logging service for this controller.</param>
        public MarketHolidaysController(
            IExpressionBuilder expressionBuilder,
            IMapper mapper,
            IModelCollectionService<MarketHolidayObservance> modelService,
            ILogger logger) : base(expressionBuilder, mapper, modelService, logger)
        {
        }
    }
}
