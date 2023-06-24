using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NjordinSight.DataTransfer.Common;
using NjordinSight.EntityModel;
using NjordinSight.EntityModelService;
using Microsoft.Extensions.Logging;
using Ichosys.DataModel.Expressions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NjordinSight.Api.Controllers
{
    /// <inheritdoc/>
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class AccountsController : ApiController<AccountDto, Account>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountsController"/> class.
        /// </summary>
        /// <param name="expressionBuilder"></param>
        /// <param name="mapper"></param>
        /// <param name="modelService"></param>
        /// <param name="logger"></param>
        public AccountsController(
            IExpressionBuilder expressionBuilder,
            IMapper mapper,
            IModelService<Account> modelService,
            ILogger logger)
            : base(expressionBuilder, mapper, modelService, logger)
        {
        }
    }
}
