using System.Collections.Generic;

namespace Ozym.ChangeTracking
{
    /// <summary>
    /// A service to report tracked changes for a collection inserts and deletes, but not 
    /// updates.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IChangeTracker<T>
    {
        /// <summary>
        /// Gets the <see cref="ChangeCollection{T}"/> representing the changes from the 
        /// current session.
        /// </summary>
        /// <returns></returns>
        ChangeCollection<T> GetChanges();

        /// <summary>
        /// Returns true if this tracker has changes in its history, else false.
        /// </summary>
        bool HasChanges { get; }
    }


    /// <summary>
    /// Container class for passing added and removed <typeparamref name="T"/> instances.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ChangeCollection<T>
    {
        /// <summary>
        /// Gets the set of <typeparamref name="T"/> that are added to the initial 
        /// collection, less items removed in the same session.
        /// </summary>
        public ISet<T> Added { get; init; }

        /// <summary>
        /// Gets the set of <typeparamref name="T"/> that are removed from the initial 
        /// collection, less items added in the same session.
        /// </summary>
        public ISet<T> Removed { get; init; }
    }
}
