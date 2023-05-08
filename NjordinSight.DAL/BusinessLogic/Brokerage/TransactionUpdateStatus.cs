using NjordinSight.EntityModel;

namespace NjordinSight.BusinessLogic.Brokerage
{
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