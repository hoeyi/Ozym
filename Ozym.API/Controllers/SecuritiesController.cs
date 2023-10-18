using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Ozym.DataTransfer.Common;
using Ozym.EntityModel;
using Ozym.EntityModelService;
using Microsoft.Extensions.Logging;
using Ichosys.DataModel.Expressions;

namespace Ozym.Api.Controllers
{
    /// <inheritdoc/>
    [ApiController]
    [Route("api/v{version:apiVersion}/securities")]
    [ApiVersion("1.0")]
    public class SecuritiesController : ApiController<SecurityDto, Security>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="SecuritiesController"/> class.
        /// </summary>
        /// <param name="expressionBuilder">The <see cref="IExpressionBuilder"/> for this instance.</param>
        /// <param name="mapper">The <see cref="IMapper"/> for this instance.</param>
        /// <param name="modelService">The <see cref="IModelService{T}"/> for this instance.</param>
        /// <param name="logger">The <see cref="ILogger"/> for this instance.</param>
        public SecuritiesController(
            IExpressionBuilder expressionBuilder,
            IMapper mapper,
            IModelService<Security> modelService,
            ILogger logger)
            : base(expressionBuilder, mapper, modelService, logger)
        {
        }
    }
}
