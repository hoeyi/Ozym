using System;

namespace EulerFinancial.Exceptions
{
    /// <summary>
    /// Represents errors that occur when updating the model data store.
    /// </summary>
    /// <remarks>Access the inner exception for the underlying exception that caused this 
    /// exception to be thrown.</remarks>
    internal class ModelUpdateException : Exception
    {
        public ModelUpdateException() : base() { }

        public ModelUpdateException(string message) : base(message) { }

        public ModelUpdateException(string message, Exception innerException) 
            : base(message, innerException) { }
    }
}
