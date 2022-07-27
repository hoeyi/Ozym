using System;

namespace NjordFinance.Web.Components.CRUD
{
    /// <summary>
    /// Describes the result stemming from completion of a modal form.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ModalEventArgs<T> : EventArgs
    {
        /// <summary>
        /// Describes the result of a modal dialog form.
        /// </summary>
        public enum ModalResult
        {
            CreateSubmitted,

            DeleteSubmitted,

            UpdateSubmitted,

            RequestCancelled
        }

        /// <summary>
        /// Gets the <typeparamref name="T"/> that is model object of the modal form.
        /// </summary>
        public T Model { get; init; }

        /// <summary>
        /// Gets the result of the modal form.
        /// </summary>
        public ModalResult Result { get; init; }
    }
}
