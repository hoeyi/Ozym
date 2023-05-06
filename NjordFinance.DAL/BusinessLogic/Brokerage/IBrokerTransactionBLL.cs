using NjordFinance.EntityModel;
using System.Collections.Generic;
using System;

namespace NjordFinance.BusinessLogic.Brokerage
{
    public interface IBrokerTransactionBLL
    {
        /// <summary>
        /// Gets the read-only collection of <see cref="BrokerTransaction"/> entries 
        /// for this instance.
        /// </summary>
        IReadOnlyCollection<BrokerTransaction> Entries { get; }

        /// <summary>
        /// Adds a new transaction to the collection.
        /// </summary>
        /// <returns>A new instance of <see cref="BrokerTransaction"/>.</returns>
        BrokerTransaction AddTransaction();

        /// <summary>
        /// Gets the collection of <see cref="BrokerTaxLot"/> for this instance, subject to the 
        /// value(s) of <see cref="TaxLotStatus"/> provided.
        /// </summary>
        /// <param name="taxLotStatus">The status of the tax lot to return.
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="BrokerTaxLot"/>.</returns>
        /// <exception cref="NotSupportedException">The value of passed to 
        /// <paramref name="taxLotStatus"/> is not valid for this method.</exception>
        IEnumerable<BrokerTaxLot> GetTaxLots(TaxLotStatus taxLotStatus);

        void RemoveTransaction(BrokerTransaction model);

        void RevertRemoveTransaction(BrokerTransaction model);

        ITransactionUpdateResponse UpdateTransactionCode(BrokerTransaction model, int newId);

        ITransactionUpdateResponse PostAllocation(AllocationInstructionTable instructions);
    }
}