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

        ITransactionUpdateResponse UpdateTransactionCode(BrokerTransaction model, int newId);
    }

    /// <summary>
    /// Represents the response received after initiating a change to a <see cref="BrokerTransaction"/> 
    /// record.
    /// </summary>
    public interface ITransactionUpdateResponse
    {
        /// <summary>
        /// Gets the <see cref="TransactionUpdateStatus"/> representing the status of the update.
        /// </summary>
        TransactionUpdateStatus UpdateStatus { get; }
    }

    /// <summary>
    /// Represents the response received after initiating a change to a <see cref="BrokerTransaction"/> 
    /// record.
    /// </summary>
    /// <typeparam name="T">The type of the <see cref="ResponseObject"/>.</typeparam>
    public interface ITransactionUpdateResponse<T> : ITransactionUpdateResponse
        where T : class
    {
        /// <summary>
        /// Gets the <typeparamref name="T"/> instance related to the response. Typically, an 
        /// instruction object that requires user input.
        /// </summary>
        T ResponseObject { get; }
    }

    /// <summary>
    /// Represents the response received after initiating a change to a <see cref="BrokerTransaction"/> 
    /// record.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class TransactionUpdateResponse<T> : ITransactionUpdateResponse, ITransactionUpdateResponse<T>
        where T : class
    {
        /// <inheritdoc/>
        public TransactionUpdateStatus UpdateStatus { get; init; }

        /// <inheritdoc/>
        public T ResponseObject { get; init; }
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
        /// The update is accepted but requires additional detail in order to proceed, e.g., the 
        /// transacted security or quantity has not been provided.
        /// </summary>
        PendingAdditionalDetail,

        /// <summary>
        /// The update fails due. Paired with an exception response object to provide reason for 
        /// the failure.
        /// </summary>
        Faulted
    }
}