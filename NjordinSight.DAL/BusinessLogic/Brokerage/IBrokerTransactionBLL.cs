using NjordinSight.DataTransfer.Common;
using System.Collections.Generic;
using System;

namespace NjordinSight.BusinessLogic.Brokerage
{
    public interface IBrokerTransactionBLL
    {
        /// <summary>
        /// Gets the collection of <see cref="BrokerTransactionDto"/> entries being modified.
        /// </summary>
        IEnumerable<BrokerTransactionDto> Entries { get; }

        /// <summary>
        /// Adds a new transaction to the collection.
        /// </summary>
        /// <returns>A new instance of <see cref="BrokerTransaction"/>.</returns>
        BrokerTransactionDto AddTransaction();

        /// <summary>
        /// Gets the collection of <see cref="BrokerTaxLot"/> for this instance, subject to the 
        /// value(s) of <see cref="TaxLotStatus"/> provided.
        /// </summary>
        /// <param name="taxLotStatus">The status of the tax lot to return.
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="BrokerTaxLot"/>.</returns>
        /// <exception cref="NotSupportedException">The value of passed to 
        /// <paramref name="taxLotStatus"/> is not valid for this method.</exception>
        IEnumerable<BrokerTaxLot> GetTaxLots(TaxLotStatus taxLotStatus);

        void RemoveTransaction(BrokerTransactionDto model);

        void RevertRemoveTransaction(BrokerTransactionDto model);

        ITransactionUpdateResponse UpdateTransactionCode(BrokerTransactionDto model, int newId);

        ITransactionUpdateResponse<IEnumerable<BrokerTransactionDto>> PostAllocation(
            AllocationInstructionTable instructions);
    }
}