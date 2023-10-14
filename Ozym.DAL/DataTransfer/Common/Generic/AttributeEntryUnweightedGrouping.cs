using Ichosys.DataModel.Annotations;
using Ozym.EntityModel;
using Ozym.EntityModel.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Ozym.DataTransfer.Common.Generic
{
    /// <summary>
    /// Base class for collections of attribute member entries that are children 
    /// of a <typeparamref name="TParentEntity"/> with a key constructed from <see cref="ModelAttribute"/>, 
    /// and <typeparamref name="TParentEntity"/> identifiers, as well as a <see cref="DateTime"/>.
    /// </summary>
    /// <typeparam name="TChildEntity">The entity type this view model represents.</typeparam>
    /// <typeparam name="TParentEntity">The entity type that is the parent of the 
    /// <typeparamref name="TChildEntity"/> entries in this model.</typeparam>
    /// <exception cref="ArgumentNullException">The value for a required parameter was a null 
    /// reference.</exception>
    /// <remarks>Conceptually, the key definition for a grouping can be thought of as a tuple combining the instances, 
    /// e.g., (<typeparamref name="TParentEntity"/>, <see cref="ModelAttribute"/>, <see cref="DateTime"/>). In practice, 
    /// the database key is most likely built from the identifiers, e.g., 
    /// (<see cref="int"/>, <see cref="int" />, <see cref="DateTime"/>).</remarks>
    public abstract partial class AttributeEntryUnweightedGrouping<TParentEntity, TChildEntity>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AttributeEntryUnweightedGrouping{TParentEntity, TChildEntity}"/> class.
        /// </summary>
        /// <param name="parentObject"></param>
        /// <param name="parentAttribute"></param>
        /// <exception cref="ArgumentNullException"></exception>
        protected AttributeEntryUnweightedGrouping(
            TParentEntity parentObject,
            ModelAttributeDtoBase parentAttribute)
        {
            if (parentObject is null)
                throw new ArgumentNullException(paramName: nameof(parentObject));

            if (parentAttribute is null)
                throw new ArgumentNullException(paramName: nameof(parentAttribute));

            ParentObject = parentObject;
            ParentAttribute = parentAttribute;
        }

        /// <summary>
        /// Gets the delegate for selecting the collection of entries for the parent object of this 
        /// grouping.
        /// </summary>
        protected abstract Func<TParentEntity, ICollection<TChildEntity>> ParentEntryMemberSelector { get; }

        /// <summary>
        /// Gets the delegate for selecting the <typeparamref name="TChildEntity"/> entries in this 
        /// grouping.
        /// </summary>
        protected abstract Func<TChildEntity, bool> EntrySelector { get; }

        protected abstract Func<TChildEntity, decimal> WeightSelector { get; }

        /// <summary>
        /// Gets the collection of <typeparamref name="TChildEntity"/> representing the children 
        /// of <see cref="TParentEntity"/>.
        /// </summary>
        private ICollection<TChildEntity> ParentEntryCollection => ParentEntryMemberSelector(ParentObject);
    }

    #region IAttributeGrouping implementation
    public abstract partial class AttributeEntryUnweightedGrouping<TParentEntity, TChildEntity> :
        IAttributeEntryUnweightedGrouping<TParentEntity, TChildEntity>
    {
        /// <inheritdoc/>
        public bool IsEmpty => !Entries.Any();

        /// <inheritdoc/>
        public IEnumerable<TChildEntity> Entries => ParentEntryCollection.Where(EntrySelector);

        /// <inheritdoc/>
        public ModelAttributeDtoBase ParentAttribute { get; init; }

        /// <inheritdoc/>
        public TParentEntity ParentObject { get; private set; }

        /// <inheritdoc/>
        [ExactValue(true,
            ErrorMessageResourceName = nameof(AttributeEntryGrouping_SR.SumOfWeights_InvalidWeight),
            ErrorMessageResourceType = typeof(AttributeEntryGrouping_SR))]
        [Display(
            Name = nameof(ModelDisplay.AttributeEntryCollectionViewModel_SumOfWeights_Name),
            ResourceType = typeof(ModelDisplay))]
        public bool EntryWeightsAreValid => Entries.All(x => WeightSelector(x) == 1M);

        /// <inheritdoc/>
        public abstract TChildEntity AddNewEntry();

        /// <inheritdoc/>
        public void AddRange(TChildEntity[] entries)
        {
            if(entries.Any())
                foreach (var entry in entries.Where(e => e is not null))
                    ParentEntryCollection.Add(entry);
        }

        /// <inheritdoc/>
        public void AddEntry(TChildEntity entry) => ParentEntryCollection.Add(entry);

        /// <inheritdoc/>
        public bool RemoveEntry(TChildEntity entry) => ParentEntryCollection.Remove(entry);

        /// <inheritdoc/>
        public bool RemoveAll()
        {
            // If empty or undefined, return false.
            if (!Entries?.Any() ?? false)
                return false;

            // Define items to be removed from parent collection.
            var groupEntries = Entries.ToList();

            bool result = false;

            foreach (var entry in groupEntries)
                result = RemoveEntry(entry);

            return result;
        }
    }
    #endregion
}