using System;

namespace NjordinSight.ChangeTracking
{
    /// <summary>
    /// Represents a collection of commands supporting 'undo' and 'redo' actions changing the 
    /// state of <typeparamref name="T"/> objects.
    /// </summary>
    public interface ICommandHistory<T>
    {
        /// <summary>
        /// Returns true if the next undo operation is valid for the current state, else false.
        /// </summary>
        bool CanUndo { get; }

        /// <summary>
        /// Returns true if the next redo operation is valid for the current state, else false.
        /// </summary>
        bool CanRedo { get; }

        /// <summary>
        /// Gets the count of entries in the history.
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Gets the <see cref="CommandHistoryEntry"/> record representing the history collection's 
        /// current position.
        /// </summary>
        CommandHistoryEntry? Current { get; }

        /// <summary>
        /// Adds the command to the history then executes the command.
        /// </summary>
        /// <param name="command">A command affect the state of an object. </param>
        void AddThenExecute(ICommand<T> command);

        /// <summary>
        /// Clears the command history of all entries.
        /// </summary>
        void Clear();

        /// <summary>
        /// Re-applies the most recently undone command.
        /// </summary>
        /// <exception cref="InvalidOperationException"><see cref="RedoCommand"/> is 
        /// called on an empty command history.</exception>
        void RedoCommand();

        /// <summary>
        /// Reverts the most recently applied command.
        /// </summary>
        /// <exception cref="InvalidOperationException"><see cref="UndoCommand"/> is 
        /// called on an empty command history.</exception>
        void UndoCommand();
    }
}
