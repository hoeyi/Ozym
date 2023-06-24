using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NjordinSight.ChangeTracking;
using NjordinSight.UserInterface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NjordinSight.ChangeTracking
{
    /// <summary>
    /// Represents a collection of commands supporting 'undo' and 'redo' actions changing the 
    /// state of <typeparamref name="T"/> objects.
    /// </summary>
    public partial class CommandHistory<T> : ICommandHistory<T>
    {
        private readonly List<(ICommand<T>, CommandHistoryEntry)> _commands = new();

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
        public void AddThenExecute(ICommand<T> command)
        {
            if (command is null)
                throw new ArgumentNullException(paramName: nameof(command));

            // If the user has moved backward and is now adding commands, 
            // we clear the difference between the current posiition and the 
            // end of the collection.
            if (_index < _commands.Count - 1 && _commands.Count > 0)
                _commands.RemoveRange(_index, _commands.Count - _index);

            _index++;
            (ICommand<T>, CommandHistoryEntry) commandEntry =
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
        public void Clear() => _commands.Clear();

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

    public partial class CommandHistory<T> : IChangeTracker<T>
    {
        /// <inheritdoc/>
        public bool HasChanges => _commands.Count > 0;

        /// <inheritdoc/>
        public ChangeCollection<T> GetChanges()
        {
            var changeCollection = new ChangeCollection<T>()
            {
                Added = Added(),
                Removed = Removed()
            };

            return changeCollection;
        }

        /// <summary>
        /// Gets the set of <typeparamref name="T"/> that are added to the initial 
        /// collection, less items removed in the same session.
        /// </summary>
        /// <returns>An <see cref="ISet{T}"/>.</returns>
        private ISet<T> Added()
        {
            var added = GetCommittedCommands<AddCommand<T>>();
            var removed = GetCommittedCommands<RemoveCommand<T>>();

            // Adjust additions for items that were subsequently removed.
            // Subtract from 'added' items that exist in 'removed' with a higher index.
            var addedLessRemoved = added
                .Where(x => !removed.Any(
                    y => y.Item1.TrackedItem.Equals(x.Item1.TrackedItem) 
                        && y.Item2.Index > x.Item2.Index))
                .Select(x => x.Item1.TrackedItem);

            return new HashSet<T>(addedLessRemoved);
        }

        /// <summary>
        /// Gets the set of <typeparamref name="T"/> that are removed from the initial 
        /// collection, less items added in the same session.
        /// </summary>
        /// <returns>An <see cref="ISet{T}"/>.</returns>
        private ISet<T> Removed()
        {
            var added = GetCommittedCommands<AddCommand<T>>();
            var removed = GetCommittedCommands<RemoveCommand<T>>();

            // Adjust removals for items that were previously added.
            // Subtract from 'removed' items that exist in 'added' with a lower index.
            var remmovedLessAdded = removed
                .Where(r => !added.Any(
                    a => a.Item1.TrackedItem.Equals(r.Item1.TrackedItem)
                        && a.Item2.Index < r.Item2.Index))
                .Select(x => x.Item1.TrackedItem);

            return new HashSet<T>(remmovedLessAdded);
        }

        /// <summary>
        /// Gets the collection of commands in the history that are on or before the current index.
        /// </summary>
        /// <typeparam name="TCommand"></typeparam>
        /// <returns>An <see cref="IEnumerable{T}"/> of 
        /// <see cref="(ICommand{T}, CommandHistoryEntry)"/></returns>
        private IEnumerable<(ICommand<T>, CommandHistoryEntry)> GetCommittedCommands<TCommand>()
            where TCommand : ICommand<T>
            => _commands.Where(x => x.Item2.Index <= _index && x.Item1.IsType<T, TCommand>());
    }

    internal static class EnumExtensions
    {
        public static bool IsType<T, TCommand>(this ICommand<T> command)
        {
            if (command is TCommand)
                return true;
            else
                return false;
        }
    }

}
