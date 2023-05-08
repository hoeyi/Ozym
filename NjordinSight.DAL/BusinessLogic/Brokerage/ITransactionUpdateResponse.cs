using NjordinSight.EntityModel;

namespace NjordinSight.BusinessLogic.Brokerage
{
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