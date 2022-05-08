using NjordFinance.Model;
using NjordFinance.ModelService;
using Microsoft.Extensions.Logging;
using NjordFinance.Controllers.Abstractions;

namespace NjordFinance.Controllers
{
    /// <summary>
    /// A derived MVC controller for <see cref="Account"/> objects.
    /// </summary>
    public partial class AccountsController : ModelController<Account>
    {
        /// <summary>
        /// Creates a new <see cref="AccountsController"/> instance.
        /// </summary>
        /// <param name="modelService"></param>
        /// <param name="logger"></param>
        public AccountsController(
            IModelService<Account> modelService, 
            ILogger logger)
            : base(modelService, logger)
        {
        }

        /// <inheritdoc/>
        protected override string CreatedActionName => "GetAccount";
    }
}
