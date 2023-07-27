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
    [Route("api/v{version:apiVersion}/report-configurations")]
    [ApiVersion("1.0")]
    public class ReportConfigurationsController 
        : ApiController<ReportConfigurationDto, ReportConfiguration>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReportConfigurationsController"/> class.
        /// </summary>
        /// <param name="expressionBuilder">The <see cref="IExpressionBuilder"/> for this instance.</param>
        /// <param name="mapper">The <see cref="IMapper"/> for this instance.</param>
        /// <param name="modelService">The <see cref="IModelService{T}"/> for this instance.</param>
        /// <param name="logger">The <see cref="ILogger"/> for this instance.</param>
        public ReportConfigurationsController(
            IExpressionBuilder expressionBuilder,
            IMapper mapper,
            IModelService<ReportConfiguration> modelService,
            ILogger logger)
            : base(expressionBuilder, mapper, modelService, logger)
        {
        }
    }
}
