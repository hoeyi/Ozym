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
using NjordFinance.BusinessLogic;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json.Linq;

namespace NjordFinance.Controllers
{
    public class BrokerTransactionController : 
        ModelBatchController<BrokerTransaction>, IBrokerTransactionController
    {
        private IBrokerTransactionBLL _transactionBLL;

        public BrokerTransactionController(
            IModelBatchService<BrokerTransaction> modelService,
            IQueryService queryService,
            ILogger logger) : base(modelService, queryService, logger)
        {
        }

        /// <inheritdoc/>
        public async Task<IActionResult> AddNewAsync()
        {
            var newModel = _transactionBLL.AddTransaction();
            await UpdateTransactionCodeAsync(newModel, newModel.TransactionCodeId);

            return await AddAsync(newModel);
        }

        /// <inheritdoc/>
        public override async Task<IActionResult> DeleteOrDetachAsync(BrokerTransaction model)
        {
            _transactionBLL.RemoveTransaction(model);

            var result = await base.DeleteOrDetachAsync(model);
            
            return result;
        }
        /// <inheritdoc/>
        public async Task<ActionResult<IEnumerable<BrokerTaxLot>>> GetTaxLots(
            TaxLotStatus taxLotStatus)
        {
            var result = await Task.Run(() => _transactionBLL.GetTaxLots(taxLotStatus));

            return Ok(result);
        }

        public async Task<IEnumerable<BrokerTransaction>> LoadRecordsAsync(int parentId)
        {
            var forParentResult = await ForParent(parentId);

            if(forParentResult is OkResult)
            {
                var transactionCodesTask = ReferenceQueries
                    .GetManyAsync<BrokerTransactionCode>(x => true);
                var transactionsTask = SelectAllAsync();
                var parentTask = ReferenceQueries.GetSingleAsync<Account>(
                    predicate: a => a.AccountId == parentId,
                    path: a => a.AccountNavigation);

                var tasks = Task.WhenAll(transactionCodesTask, transactionsTask, parentTask);

                await tasks;

                if(tasks.Status == TaskStatus.RanToCompletion)
                {
                    var transactionsResult = await transactionsTask;
                    var codesResult = await transactionCodesTask;
                    var parentResult = await parentTask;

                    _transactionBLL = new BrokerTransactionBLL(
                        transactionsResult.Value,
                        codesResult.Value, 
                        parentResult.Value);

                    return _transactionBLL.Entries;
                }
                else
                {
                    throw tasks.Exception.Flatten();
                }

            }
            else
            {
                throw new InvalidOperationException();
            }

        }

        /// <inheritdoc/>
        public async Task<IActionResult> UpdateTransactionCodeAsync(
            BrokerTransaction model, int newId)
        {
            ITransactionCodeUpdateResponse<IEnumerable<BrokerTaxLot>> ConvertResponse(
                ITransactionCodeUpdateResponse response)
            {
                if (response is ITransactionCodeUpdateResponse<IEnumerable<BrokerTaxLot>>
                    taxLotResponse)
                    return taxLotResponse;
                else return null;
            };

            var updateTransactionCodeTask = Task.Run(() =>
            {
                var response  = _transactionBLL.UpdateTransactionCode(model, newId);

                return response.UpdateStatus switch
                {
                    TransactionUpdateStatus.Completed => Accepted(),
                    TransactionUpdateStatus.PendingLotClosure => Accepted(
                        ConvertResponse(response).ResponseObject)
                    _ => throw new InvalidOperationException()
                };
            });

            var actionResult = await updateTransactionCodeTask;

            return actionResult;
        }
    }
}
