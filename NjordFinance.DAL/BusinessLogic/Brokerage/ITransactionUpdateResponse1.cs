using NjordFinance.EntityModel;

namespace NjordFinance.BusinessLogic.Brokerage
{
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
}