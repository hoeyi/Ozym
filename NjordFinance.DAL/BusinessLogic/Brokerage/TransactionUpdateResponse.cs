using NjordFinance.Model;

namespace NjordFinance.BusinessLogic.Brokerage
{
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
}