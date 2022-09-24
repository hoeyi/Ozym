using System;
using System.Collections.Generic;
using System.Linq;

namespace NjordFinance.Model.ViewModel.Generic
{
    /// <summary>
    /// Represents a collection of <typeparamref name="TEntryEntity"/> that describe an instance 
    /// of <typeparamref name="TParentEntity"/>.
    /// </summary>
    /// <typeparam name="TEntryEntity"></typeparam>
    /// <typeparam name="TParentEntity"></typeparam>
    public interface IAttributeEntryGrouping<TParentEntity, TEntryEntity>
        where TParentEntity : class, new()
        where TEntryEntity : class, new()
    { 
        /// <summary>
        /// Gets the collection of <typeparamref name="TEntryEntity"/> entries in this model.
        /// </summary>
        IEnumerable<TEntryEntity> Entries { get; }

        /// <summary>
        /// Gets whether this <see cref="IAttributeEntryGrouping{TParentEntity, TEntryEntity}"/> is 
        /// an empty collection.
        /// </summary>
        bool IsEmpty { get; }

        /// <summary>
        /// Gets the <see cref="ModelAttribute"/> that is the parent for this view model.
        /// </summary>
        ModelAttribute ParentAttribute { get; }

        /// <summary>
        /// Gets the <typeparamref name="TParentEntity"/> model that is the parent object for this
        /// attribute entry collection. Generally, this is the model instance these attribute 
        /// entries describe.
        /// </summary>
        TParentEntity ParentObject { get; }

        /// <summary>
        /// Adds a new default instance of <typeparamref name="TEntryEntity"/>.
        /// </summary>
        /// <returns>The added <typeparamref name="TEntryEntity"/>.</returns>
        TEntryEntity AddNewEntry();

        /// <summary>
        /// Adds the given <typeparamref name="TEntryEntity"/> instance.
        /// </summary>
        /// <param name="entry"></param>
        void AddEntry(TEntryEntity entry);

        /// <summary>
        /// Adds the array of non-null <typeparamref name="TEntryEntity"/> instances.
        /// </summary>
        /// <param name="entries">The array of <typeparamref name="TEntryEntity"/> to add.</param>
        void AddRange(TEntryEntity[] entries);

        /// <summary>
        /// Removes an existing <typeparamref name="TEntryEntity"/> instance from the collection.
        /// </summary>
        /// <param name="entry">The <typeparamref name="TEntryEntity"/> to remove.</param>
        /// <returns>True if the removal is successful, else false.</returns>
        bool RemoveEntry(TEntryEntity entry);

        /// <summary>
        /// Removes all entries for this <see cref="IAttributeEntryGrouping{TParentEntity, TEntryEntity}"/>.
        /// </summary>
        /// <returns>True if removal for all entries was successful, else false.</returns>
        bool RemoveAll();
    }
}
