using Ichosys.DataModel.Annotations;
using Ozym.EntityModel.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Ozym.DataTransfer.Common.Generic
{
    /// <summary>
    /// Base class for collections of attribute member entries that are children 
    /// of a composite entity uniquely identified by a composite key constructed from <see cref="ModelAttributeDtoBase"/>, 
    /// and <typeparamref name="TParentEntity"/> identifiers, as well as a <see cref="DateTime"/>.
    /// </summary>
    /// <typeparam name="TChildEntity">The entity type this view model represents.</typeparam>
    /// <typeparam name="TParentEntity">The entity type that is the parent of the 
    /// <typeparamref name="TChildEntity"/> entries in this model.</typeparam>
    /// <exception cref="ArgumentNullException">The value for a required parameter was a null 
    /// reference.</exception>
    /// <remarks>Conceptually, the key definition for a grouping can be thought of as a tuple combining the instances, 
    /// e.g., (<typeparamref name="TParentEntity"/>, <see cref="ModelAttributeDtoBase"/>, <see cref="DateTime"/>). In practice, 
    /// the database key is most likely built from the identifiers, e.g., 
    /// (<see cref="int"/>, <see cref="int" />, <see cref="DateTime"/>).</remarks>
    public abstract partial class AttributeEntryWeightedGrouping<TParentEntity, TChildEntity>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AttributeEntryWeightedGrouping{TParentEntity, TChildEntity}"/> class.
        /// </summary>
        /// <param name="parentObject"></param>
        /// <param name="parentAttribute"></param>
        /// <param name="effectiveDate"></param>
        /// <exception cref="ArgumentNullException"></exception>
        protected AttributeEntryWeightedGrouping(
            TParentEntity parentObject,
            ModelAttributeDtoBase parentAttribute, 
            DateTime effectiveDate)
        {
            if (parentObject is null)
                throw new ArgumentNullException(paramName: nameof(parentObject));

            if (parentAttribute is null)
                throw new ArgumentNullException(paramName: nameof(parentAttribute));

            ParentObject = parentObject;
            ParentAttribute = parentAttribute;
            this.effectiveDate = effectiveDate;
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

        /// <summary>
        /// Gets the delegate for selecting the weight attribute for the 
        /// <typeparamref name="TChildEntity"/> type.
        /// </summary>
        protected abstract Func<TChildEntity, decimal> WeightSelector { get; }

        /// <summary>
        /// Gets the collection of <typeparamref name="TChildEntity"/> representing the children 
        /// of <see cref="TParentEntity"/>.
        /// </summary>
        private ICollection<TChildEntity> ParentEntryCollection => ParentEntryMemberSelector(ParentObject);
        
        /// <summary>
        /// Sets the effective date of the given <typeparamref name="TChildEntity"/> entry to the 
        /// given <see cref="DateTime"/> value.
        /// </summary>
        /// <param name="entry"></param>
        /// <param name="effectiveDate"></param>
        /// <returns>True, if the update was successful, else false.</returns>
        protected abstract bool UpdateEntryEffectiveDate(TChildEntity entry, DateTime effectiveDate);
    }

    #region IAttributeEntryWeightedGrouping implementation
    public abstract partial class AttributeEntryWeightedGrouping<TParentEntity, TChildEntity> :
        IAttributeEntryWeightedGrouping<TParentEntity, TChildEntity>
    {
        private DateTime effectiveDate;

        /// <inheritdoc/>
        [Display(
            Name = nameof(AttributeEntryGrouping_SR.EffectiveDate_Name),
            Description = nameof(AttributeEntryGrouping_SR.EffectiveDate_Description),
            ResourceType = typeof(AttributeEntryGrouping_SR))]
        public DateTime EffectiveDate
        {
            get { return effectiveDate; }
            set
            {
                if(effectiveDate != value)
                {
                    if(!Entries.All(x => UpdateEntryEffectiveDate(x, value)))
                    {
                        string msg = string.Format(
                            Strings.AttributeEntryGrouping_EffectiveDate_InconsistentSet,
                            nameof(EffectiveDate));

                        throw new InvalidOperationException(message: msg);
                    }
                    effectiveDate = value;
                }
            }
        }

        /// <inheritdoc/>
        public bool IsEmpty => !Entries.Any();

        /// <inheritdoc/>
        public IEnumerable<TChildEntity> Entries => ParentEntryCollection.Where(EntrySelector);

        /// <inheritdoc/>
        public ModelAttributeDtoBase ParentAttribute { get; init; }

        /// <inheritdoc/>
        public TParentEntity ParentObject { get; private set; }

        /// <inheritdoc/>
        [ExactValue(1D)]
        [Display(
            Name = nameof(ModelDisplay.AttributeEntryCollectionViewModel_SumOfWeights_Name),
            ResourceType = typeof(ModelDisplay))]
        public decimal SumOfMemberWeights => Entries.Sum(WeightSelector);

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

            foreach(var entry in groupEntries)
                result = RemoveEntry(entry);

            return result;
        }
    }
    #endregion
}