using NjordFinance.Model;
using System.Collections.Generic;
using System;

namespace NjordFinance.BusinessLogic
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

        ITransactionCodeUpdateResponse UpdateTransactionCode(BrokerTransaction model, int newId);
    }

    public interface ITransactionCodeUpdateResponse
    {
        TransactionUpdateStatus UpdateStatus { get; }
    }

#nullable enable
    public interface ITransactionCodeUpdateResponse<T> : ITransactionCodeUpdateResponse
        where T : class?
    {
        T ResponseObject { get; }
    }
#nullable disable

    /// <summary>
    /// Represents the response received after initiating a change to the 
    /// <see cref="BrokerTransactionCode"/> member of a <see cref="BrokerTransaction"/> record.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class TransactionCodeUpdateResponse<T> : ITransactionCodeUpdateResponse
    {
        public TransactionUpdateStatus UpdateStatus { get; init; } 

        public T ReponseObject { get; init; }
    }

    /// <summary>
    /// Represents the possible statuses of a request to change the <see cref="BrokerTransactionCode"/> 
    /// member of a <see cref="BrokerTransaction"/> record.
    /// </summary>
    public enum TransactionUpdateStatus
    {
        /// <summary>
        /// The update succeeded and no further action is required.
        /// </summary>
        Completed,

        /// <summary>
        /// The update requires instruction on which tax lots to close before proceeding.
        /// </summary>
        PendingLotClosure,

        /// <summary>
        /// The update fails due. Paired with an exception response object to provide reason for 
        /// the failure.
        /// </summary>
        Faulted
    }
}