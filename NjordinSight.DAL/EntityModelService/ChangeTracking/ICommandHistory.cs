using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NjordinSight.EntityModelService.ChangeTracking
{
    /// <summary>
    /// Represents a read-only description of an an entry in a 
    /// <see cref="ICollectionCommandHistory"/>.
    /// </summary>
    public readonly record struct CommandHistoryEntry
    {
        public int Index { get; init; }

        public string Description { get; init; }
    }

    /// <summary>
    /// Represents a collection of commands supporting 'undo' and 'redo' actions.
    /// </summary>
    internal interface ICollectionCommandHistory
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
        /// <param name="command">Am <see cref="ICommand"/> acting on an 
        /// <see cref="ICollection{T}"/>.</param>
        void AddThenExecute(ICommand command);

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
