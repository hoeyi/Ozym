using Ozym.EntityModel;

namespace Ozym.BusinessLogic.Brokerage
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
}