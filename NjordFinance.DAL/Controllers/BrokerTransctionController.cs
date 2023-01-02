using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NjordFinance.Controllers.Abstractions;
using NjordFinance.Model;
using NjordFinance.ModelService;
using NjordFinance.ModelService.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace NjordFinance.Controllers
{
    public class BrokerTransctionController : ModelBatchController<BrokerTransaction>
    {
        public BrokerTransctionController(
            IModelBatchService<BrokerTransaction> modelService, 
            IQueryService queryService, 
            ILogger logger) : base(modelService, queryService, logger)
        {
        }

        public async Task<IActionResult> UpdateTransactionCodeAsync(
            BrokerTransaction model, int newId)
        {
            throw new NotImplementedException();
        }
    }
}
