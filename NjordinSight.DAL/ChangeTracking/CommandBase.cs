using System;
using System.Collections.Generic;

namespace NjordinSight.ChangeTracking
{
    /// <summary>
    /// Base class representing an action performed on an <see cref="ICollection{T}"/>.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal abstract class CommandBase<T> : ICommand<T>
    {
        private Func<T, bool> DoAction { get; init; }

        private Func<T, bool> UndoAction { get; init; }

        private T ActionInput { get; init; }

        public CommandBase(
            Func<T, bool> doActionDelegate,
            Func<T, bool> undoActionDelegate,
            T actionInput,
            string description)
        {
            if (doActionDelegate is null)
                throw new ArgumentNullException(paramName: nameof(doActionDelegate));

            if (undoActionDelegate is null)
                throw new ArgumentNullException(paramName: nameof(undoActionDelegate));

            if (actionInput is null)
                throw new ArgumentNullException(paramName: nameof(actionInput));

            if (string.IsNullOrEmpty(description))
                throw new ArgumentNullException(paramName: nameof(description));

            DoAction = doActionDelegate;
            UndoAction = undoActionDelegate;
            ActionInput = actionInput;
            Description = description;
        }

        /// <inheritdoc/>
        public string Description { get; }

        /// <inheritdoc/>
        public T TrackedItem => ActionInput;

        /// <inheritdoc/>
        public virtual bool Execute() => DoAction(ActionInput);

        /// <inheritdoc/>
        public virtual bool Undo() => UndoAction(ActionInput);
    }

    /// <summary>
    /// Represents an 'add' action for a collection.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class AddCommand<T> : CommandBase<T>
    {
        /// <summary>
        /// Creates a new instance of <see cref="AddCommand{T}"/>.
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="item"></param>
        /// <param name="description"></param>
        public AddCommand(ICollection<T> collection, T item, string description)
            : base(
                  doActionDelegate: (x) =>
                  {
                      collection.Add(x);
                      return true;
                  },
                  undoActionDelegate: (x) => collection.Remove(x),
                  actionInput: item,
                  description: description)
        {
        }
    }

    /// <summary>
    /// Represents a 'remove' action for a collection.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class RemoveCommand<T> : CommandBase<T>
    {
        public RemoveCommand(ICollection<T> collection, T item, string description)
            : base(
                  doActionDelegate: (x) => collection.Remove(x),
                  undoActionDelegate: (x) =>
                  {
                      collection.Add(x);
                      return true;
                  },
                  actionInput: item,
                  description: description)
        {
        }
    }
}
