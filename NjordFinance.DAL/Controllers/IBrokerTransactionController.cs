using Microsoft.AspNetCore.Mvc;
using NjordFinance.BusinessLogic;
using NjordFinance.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NjordFinance.Controllers
{
    public interface IBrokerTransactionController : IBatchController<BrokerTransaction>
    {

        Task<IActionResult> AddNewAsync();

        Task<IEnumerable<BrokerTransaction>> LoadRecordsAsync(int parentId);

        /// <summary>
        /// Gets the collection of <see cref="BrokerTaxLot"/> for this instance, subject to the 
        /// value(s) of <see cref="TaxLotStatus"/> provided.
        /// </summary>
        /// <param name="taxLotStatus">The status of the tax lot to return.
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="BrokerTaxLot"/>.</returns>
        /// <exception cref="NotSupportedException">The value of passed to 
        /// <paramref name="taxLotStatus"/> is not valid for this method.</exception>
        Task<ActionResult<IEnumerable<BrokerTaxLot>>> GetTaxLots(TaxLotStatus taxLotStatus);

        /// <summary>
        /// Updates the transaction code for a given <see cref="BrokerTransaction"/>according 
        /// to the new identifier given.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="newId"></param>
        /// <returns></returns>
        Task<IActionResult> UpdateTransactionCodeAsync(BrokerTransaction model, int newId);

        Task<IActionResult> PostAllocationInstruction(
            BrokerTransaction model, IEnumerable<AllocationInstruction> instructions);

        Task<IActionResult> CloseTransactionVersusLotAsync(
            BrokerTransaction model, BrokerTaxLot taxLot);
    }
}