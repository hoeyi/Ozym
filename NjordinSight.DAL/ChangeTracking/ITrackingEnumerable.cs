using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace NjordinSight.ChangeTracking
{
    /// <summary>
    /// Represents a collection supporting binding, change history, and command reversion for types 
    /// supporting reference equality.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ITrackingEnumerable<T> : IEnumerable<T>
        where T : class, INotifyPropertyChanged
    {
        /// <summary>
        /// Gets or sets the item at the given index.
        /// </summary>
        /// <param name="index">The zero-based index of the item to get or set.</param>
        /// <returns>The <typeparamref name="T"/> at the specified index.</returns>
        T this[int index] { get; set; }

        /// <summary>
        /// Gets or sets the object responsible for tracking calls of <see cref="Add(T)"/> and 
        /// <see cref="Remove(T)"/>.
        /// </summary>
        ICommandHistory<T> CommandHistory { get; init; }

        /// <summary>
        /// Gets the number of items in the collection.
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Returns true if the underlying collection has had items added or removed, or if any 
        /// item in the collection has been modified.
        /// </summary>
        bool HasChanges { get; }

        /// <summary>
        /// Adds the given item to the collection.
        /// </summary>
        /// <param name="item">The <typeparamref name="T"/> to add.</param>
        void Add(T item);

        /// <summary>
        /// Gets the collection of items and their tracking states. Excluded items unchanged.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{T}"/> of 
        /// (<typeparamref name="T"/>, <see cref="TrackingState"/>).</returns>
        IEnumerable<(T, TrackingState)> GetChanges();

        /// <summary>
        /// Removes the given item from the collection.
        /// </summary>
        /// <param name="item">The <typeparamref name="T"/> to remove.</param>
        /// <returns>True if the item is removed, or false if the item was not found.</returns>
        bool Remove(T item);

        /// <summary>
        /// Resets the tracking collection using the given list for the initial collection.
        /// </summary>
        /// <param name="list">An <see cref="IList{T}"/> for the new tracked collection.</param>
        void ResetList(IList<T> list);

        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}