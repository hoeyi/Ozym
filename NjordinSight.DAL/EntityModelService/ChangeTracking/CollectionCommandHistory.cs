using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NjordinSight.UserInterface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NjordinSight.EntityModelService.ChangeTracking
{
    /// <summary>
    /// Represents a collection of commands supporting 'undo' and 'redo' actions.
    /// </summary>
    internal class CollectionCommandHistory<T> : ICollectionCommandHistory
    {
        private readonly List<(ICommand, CommandHistoryEntry)> _commands = new();

        // The index identifying the current position. Default is -1, indicating no position.
        private int _index = -1;

        /// <inheritdoc/>
        public CommandHistoryEntry? Current =>
            _index > -1 && _index < _commands.Count ? _commands[_index].Item2 : null;

        /// <inheritdoc/>
        public bool CanUndo => _commands.Count > 0 && _index > -1;

        /// <inheritdoc/>
        public bool CanRedo => _commands.Count > 0 && _index < _commands.Count - 1;

        /// <inheritdoc/>
        public int Count => _commands.Count;

        /// <inheritdoc/>
        public void AddThenExecute(ICommand command)
        {
            if (command is null)
                throw new ArgumentNullException(paramName: nameof(command));

            // If the user has moved backward and is now adding commands, 
            // we clear the difference between the current posiition and the 
            // end of the collection.
            if (_index < _commands.Count - 1 && _commands.Count > 0)
                _commands.RemoveRange(_index, _commands.Count - _index);

            _index++;
            (ICommand, CommandHistoryEntry) commandEntry =
                (command, new() { Index = _index, Description = command.Description });

            try
            {
                _commands.Add(commandEntry);
                command.Execute();
            }
            // If an exception is thrown, decrement the alterd index and re-throw. 
            // If the caller recovers from the exception, 
            catch(Exception)
            {
                // Check the command history and remove the last entry if it matches 
                // the item given.
                if (_commands.Count > 0 && _commands[^1] == commandEntry)
                    _commands.RemoveAt(_commands.Count - 1);

                throw;
            }
            finally
            {
                // Reset the index to the last entry.
                _index = _commands.Count - 1;
            }
        }

        /// <inheritdoc/>
        public void UndoCommand()
        {
            // If undo is not possible
            if (CanUndo)
            {
                _commands[_index].Item1.Undo();
                _index--;
            }
            else
                throw new InvalidOperationException(
                    FormatInvalidOperationExceptionMessage());
        }

        /// <inheritdoc/>
        public void RedoCommand()
        {
            // Redo a command if supported, else throw exception.
            if (CanRedo)
            {
                _commands[_index + 1].Item1.Execute();
                _index++;
            }
            else
                throw new InvalidOperationException(
                    FormatInvalidOperationExceptionMessage());
        }

        private string FormatInvalidOperationExceptionMessage(
            [CallerMemberName] string methodName = "")
        {
            return string.Format(
                ChangeTrackingStrings.CollectionCommandHistory_InvalidOperationException,
                methodName,
                $"{{{nameof(Count)}: {Count}; {nameof(_index)}: {_index}}}");
        }
    }
}
