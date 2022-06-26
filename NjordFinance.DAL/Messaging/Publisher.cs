﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NjordFinance.Messaging
{
    /// <summary>
    /// Base class for generic publisher in a Publisher-Subscriber pattern.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Publisher<T> : IPublisher<T>
    {
        public event EventHandler<T> ContentPublished;

        /// <summary>
        /// Publish method wrapping invoking the publish delegate.
        /// </summary>
        /// <param name="content"></param>
        public virtual void OnPublish(T content) => ContentPublished?.Invoke(this, content);
    }
}
