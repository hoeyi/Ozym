using Microsoft.Extensions.Logging;
using NjordFinance.Controllers.Abstractions;
using NjordFinance.Model;
using NjordFinance.ModelService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NjordFinance.Controllers
{
    /// <inheritdoc/>
    public class AccountCustodiansController : ModelController<AccountCustodian>
    {
        /// <summary>
        /// Creates a new <see cref="AccountCustodiansController"/> instance.
        /// </summary>
        /// <param name="modelService"></param>
        /// <param name="logger"></param>
        public AccountCustodiansController(
            IModelService<AccountCustodian> modelService,
            ILogger logger)
            : base(modelService, logger)
        {
        }

        /// <inheritdoc/>
        protected override string CreatedActionName => "GetAccountCustodian";
    }
}
