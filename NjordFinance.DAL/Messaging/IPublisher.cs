using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NjordFinance.Messaging
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
