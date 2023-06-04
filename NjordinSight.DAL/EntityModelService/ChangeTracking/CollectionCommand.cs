using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NjordinSight.EntityModelService.ChangeTracking
{
    /// <summary>
    /// Base class representing an action performed on an <see cref="ICollection{T}"/>.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class CollectionCommand<T> : ICommand
    {
        protected ICollection<T> Collection { get; private init; }
        protected T Item { get; private init; }
        public CollectionCommand(
            ICollection<T> collection, 
            T item,
            string description)
        {
            if (string.IsNullOrEmpty(description))
                throw new ArgumentNullException(paramName: nameof(description));

            Collection = collection;
            Item = item;
            Description = description;
        }

        /// <inheritdoc/>
        public string Description { get; }

        /// <inheritdoc/>
        public abstract void Execute();

        /// <inheritdoc/>
        public abstract void Undo();
    }

    /// <summary>
    /// Represents an 'add' action for a collection.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class AddCommand<T> : CollectionCommand<T>, ICommand
    {
        /// <summary>
        /// Creates a new instance of <see cref="AddCommand{T}"/>.
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="item"></param>
        /// <param name="description"></param>
        public AddCommand(ICollection<T> collection, T item, string description)
            : base(collection, item, description)
        {
        }

        /// <inheritdoc/>
        public override void Execute()
        {
            Collection.Add(Item);
        }

        /// <inheritdoc/>
        public override void Undo()
        {
            Collection.Remove(Item);
        }
    }

    /// <summary>
    /// Represents a 'remove' action for a collection.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RemoveCommand<T> : CollectionCommand<T>, ICommand
    {
        public RemoveCommand(ICollection<T> collection, T item, string description)
            : base(collection, item, description)
        {
        }

        /// <inheritdoc/>
        public override void Execute()
        {
            Collection.Remove(Item);
        }

        /// <inheritdoc/>
        public override void Undo()
        {
            Collection.Add(Item);
        }
    }
}
