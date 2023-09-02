using AutoMapper;
using Ichosys.DataModel.Expressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NjordinSight.DataTransfer.Common;
using NjordinSight.EntityModel;
using NjordinSight.EntityModelService.Abstractions;

namespace NjordinSight.Api.Controllers
{
    /// <inheritdoc/>
    [ApiController]
    [Route("api/v{version:apiVersion}/exchanges")]
    [ApiVersion("1.0")]
    public class SecurityExchangesController
        : ApiCollectionController<SecurityExchangeDto, SecurityExchange>
    {
        /// <summary>
        /// Creates a new instance of <see cref="SecurityExchangesController"/>.
        /// </summary>
        /// <param name="expressionBuilder">The expression helper service for this controller.</param>
        /// <param name="mapper">The mapping service for this controller.</param>
        /// <param name="modelService">The model service for this controller.</param>
        /// <param name="logger">The logging service for this controller.</param>
        public SecurityExchangesController(
            IExpressionBuilder expressionBuilder,
            IMapper mapper,
            IModelCollectionService<SecurityExchange> modelService,
            ILogger logger) : base(expressionBuilder, mapper, modelService, logger)
        {
        }
    }
}
