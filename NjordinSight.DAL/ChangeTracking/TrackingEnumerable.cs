using Ichosys.DataModel.Annotations;
using MathNet.Numerics.Financial;
using NjordinSight.EntityModel.Metadata;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NjordinSight.ChangeTracking
{
    /// <summary>
    /// Provides a collection supporting binding, change history, and command reversion for types 
    /// supporting reference equality.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class TrackingEnumerable<T> : ITrackingEnumerable<T>
        where T : class, INotifyPropertyChanged
    {
        private readonly HashSet<T> _modifiedItems = new();
        private readonly HashSet<T> _removedItems = new();
        private readonly HashSet<T> _addedItems = new();

        /// <summary>
        /// Initializes a new empty instance of <see cref="TrackingEnumerable{T}"/>.
        /// </summary>
        public TrackingEnumerable()
            : this(new List<T>())
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="TrackingEnumerable{T}"/> with the specified list.
        /// </summary>
        /// <param name="list"></param>
        public TrackingEnumerable(IList<T> list)
        {
            var cmd = new CommandHistory<T>();

            CommandHistory = cmd;

            ModelNoun = typeof(T).GetCustomAttribute<NounAttribute>();

            Items = new(list);
            Items.ListChanged += Items_ListChanged;
        }

        private BindingList<T> Items { get; set; }

        private NounAttribute ModelNoun { get; init; }

        /// <summary>
        /// Gets the class name for type parameter of this instance.
        /// </summary>
        private string TypeName { get; } = typeof(T).Name;

        /// <summary>
        /// Handles the <see cref="BindingList{T}.ListChanged"/> event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Items_ListChanged(object sender, ListChangedEventArgs e)
        {
            switch (e.ListChangedType)
            {
                case ListChangedType.Reset:
                    break;
                case ListChangedType.ItemAdded:
                    _addedItems.Add(Items[e.NewIndex]);
                    break;
                case ListChangedType.ItemDeleted:
                    break;
                case ListChangedType.ItemMoved:
                    break;
                case ListChangedType.ItemChanged:
                    _modifiedItems.Add(Items[e.NewIndex]);
                    break;
                case ListChangedType.PropertyDescriptorAdded:
                    break;
                case ListChangedType.PropertyDescriptorDeleted:
                    break;
                case ListChangedType.PropertyDescriptorChanged:
                    break;
                default:
                    break;
            }
        }

        #region ITrackingEnumerable<T> implementation
        /// <inheritdoc/>
        public ICommandHistory<T> CommandHistory { get; init; }

        /// <inheritdoc/>
        public bool HasChanges =>
            _addedItems.Count + _modifiedItems.Count + _removedItems.Count > 0;

        /// <inheritdoc/>
        public T this[int index]
        {
            get { return Items[index]; }
            set
            {
                Items[index] = value;
            }
        }

        /// <inheritdoc/>
        public int Count => Items.Count;

        /// <inheritdoc/>
        public void Add(T item)
        {
            var addCommand = new AddCommand<T>(
                    collection: Items,
                    item: item,
                    description: string.Format(
                        TrackingEnumerable_SR.Add_Description,
                        ModelNoun?.GetSingular() ?? TypeName));

            CommandHistory.AddThenExecute(addCommand);
        }

        /// <inheritdoc/>
        public IEnumerable<(T, TrackingState)> GetChanges()
        {
            // Items present in the added collection that are present in the working collection
            // (i.e., items that were added and not subsequently removed).
            var addedItems = _addedItems
                .Where(x => Items.Contains(x))
                .Select(x => (x, TrackingState.Added));

            // Items present in the removed collection that are not present in the working 
            // collection (i.e., items that were removed and the command is not reverted).
            var removedItems = _removedItems
                .Where(x => !Items.Contains(x))
                .Select(x => (x, TrackingState.Removed));

            // Items present in the modified collection that are present in the working 
            // colleciton but not present in the added collection. (i.e., items that were modified 
            // and not subsequently removed and not added during the lifetime of the tracking class).
            var modifiedItems = _modifiedItems
                .Where(x => Items.Contains(x) && !_addedItems.Contains(x))
                .Select(x => (x, TrackingState.Updated));

            var changes = addedItems.Union(removedItems).Union(modifiedItems);

            return changes.ToList();
        }

        /// <inheritdoc/>
        public IEnumerator<T> GetEnumerator() => Items.GetEnumerator();

        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator() => Items.GetEnumerator();

        /// <inheritdoc/>
        public bool Remove(T item)
        {
            if (!Items.Contains(item))
                return false;

            var removeCommand = new RemoveCommand<T>(
                    collection: Items,
                    item: item,
                    description: string.Format(
                        TrackingEnumerable_SR.Remove_Description,
                        ModelNoun?.GetSingular() ?? TypeName));

            CommandHistory.AddThenExecute(removeCommand);
            _removedItems.Add(item);
            return true;
        }

        /// <inheritdoc/>
        public void ResetList(IList<T> list)
        {
            Items.Clear();
            _addedItems.Clear();
            _modifiedItems.Clear();
            _removedItems.Clear();

            Items = new(list);
        }
        #endregion
    }
}
