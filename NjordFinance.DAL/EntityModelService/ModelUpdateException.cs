using System;

namespace NjordFinance.EntityModelService
{
    /// <summary>
    /// Represents errors that occur when updating the model data store.
    /// </summary>
    /// <remarks>Access the inner exception for the underlying exception that caused this 
    /// exception to be thrown.</remarks>
    public class ModelUpdateException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ModelUpdateException"/> class.
        /// </summary>
        public ModelUpdateException() : base() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelUpdateException"/> class with a 
        /// specified error message.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        public ModelUpdateException(string message) : base(message) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelUpdateException"/> class with a 
        /// specified error message and a reference to the inner exception that is the cause of 
        /// this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, 
        /// or a null reference if no inner exception is specified.</param>
        public ModelUpdateException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
