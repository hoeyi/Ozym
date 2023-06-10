using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NjordinSight.Web.Controllers.Abstractions;
using NjordinSight.EntityModel;
using NjordinSight.EntityModelService;
using NjordinSight.EntityModelService.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NjordinSight.BusinessLogic.Brokerage;
using NjordinSight.EntityModelService.Abstractions;

namespace NjordinSight.Web.Controllers
{
    public class BrokerTransactionController : 
        ModelCollectionController<BrokerTransaction, int>, IBrokerTransactionController
    {
        private IBrokerTransactionBLL _transactionBLL;

        public BrokerTransactionController(
            IModelCollectionService<BrokerTransaction, int> modelService,
            IQueryService queryService,
            ILogger logger) : base(modelService, queryService, logger)
        {
        }

        /// <inheritdoc/>
        public async Task<ActionResult<BrokerTransaction>> AddNewAsync()
        {
            var newModel = _transactionBLL.AddTransaction();
            await UpdateTransactionCodeAsync(newModel, newModel.TransactionCodeId);

            await AddAsync(newModel);

            return newModel;
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

        /// <inheritdoc/>
        public async Task<IEnumerable<BrokerTransaction>> LoadRecordsAsync(int parent)
        {
            var forParentResult = await ForParent(parent);

            if(forParentResult is OkResult)
            {
                var transactionCodesTask = ReferenceQueries
                    .GetManyAsync<BrokerTransactionCode>(x => true);
                var transactionsTask = SelectAllAsync();
                var parentTask = ReferenceQueries.GetSingleAsync<Account>(
                    predicate: a => a.AccountId == parent,
                    path: a => a.AccountNavigation);

                var tasks = Task.WhenAll(transactionCodesTask, transactionsTask, parentTask);

                await tasks;

                if(tasks.Status == TaskStatus.RanToCompletion)
                {
                    var transactionsResult = await transactionsTask;
                    var codesResult = await transactionCodesTask;
                    var parentResult = await parentTask;

                    _transactionBLL = new BrokerTransactionBLL(
                        transactionsResult.Value.OrderByDescending(x => x.TradeDate).ToList(),
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
        public async Task<IActionResult> PostAllocationInstructionAsync(
            AllocationInstructionTable instruction)
        {
            var postTask = Task.Run(() => _transactionBLL.PostAllocation(instruction));

            var result = await postTask;

            if(result.UpdateStatus == TransactionUpdateStatus.Completed)
            {
                foreach(var transaction in result.ResponseObject)
                {
                    await AddAsync(transaction);
                }
            }
            return result.UpdateStatus switch
            {
                TransactionUpdateStatus.Completed => Accepted(result.UpdateStatus),
                TransactionUpdateStatus.Faulted => Conflict(result),
                _ => throw new InvalidOperationException(),
            };
        }

        /// <inheritdoc/>
        public async Task<IActionResult> UpdateTransactionCodeAsync(
            BrokerTransaction model, int newId)
        {
            static ITransactionUpdateResponse<AllocationInstructionTable> ConvertToAllocationResponse(
                ITransactionUpdateResponse response)
            {
                if (response is ITransactionUpdateResponse<AllocationInstructionTable>
                    allcoationResponse)
                    return allcoationResponse;
                else return null;
            };

            static ITransactionUpdateResponse<InvalidOperationException> ConvertToErrorResponse(
                ITransactionUpdateResponse response)
            {
                if (response is ITransactionUpdateResponse<InvalidOperationException>
                    errorResponse)
                    return errorResponse;
                else return null;
            };

            var updateTransactionCodeTask = Task.Run(() =>
            {
                var response  = _transactionBLL.UpdateTransactionCode(model, newId);

                IActionResult result = response.UpdateStatus switch
                {
                    TransactionUpdateStatus.Completed => Accepted(),
                    
                    TransactionUpdateStatus.PendingAdditionalDetail => Accepted(),
                    
                    TransactionUpdateStatus.PendingLotClosure => 
                        Accepted(ConvertToAllocationResponse(response)),

                    TransactionUpdateStatus.Faulted => 
                        Conflict(ConvertToErrorResponse(response)),

                    _ => throw new InvalidOperationException()
                };

                return result;
            });

            var actionResult = await updateTransactionCodeTask;

            return actionResult;
        }
    }
}
