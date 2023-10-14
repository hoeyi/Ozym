using System;

namespace Ozym.Messaging
{
    /// <summary>
    /// Represents an object responsible for publishing content to subscribers.
    /// </summary>
    public interface IPublisher<T>
    {
        /// <summary>
        /// Delegate responsible for handling pusblish events.
        /// </summary>
        event EventHandler<T> ContentPublished;
    }


}
