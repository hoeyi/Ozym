using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NjordFinance.Model.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;

namespace NjordFinance.Model.ViewModel.Generic
{
    /// <summary>
    /// Serves as the base class for collections of attribute member entries that are children 
    /// of a given <see cref="ModelAttribute"/>.
    /// </summary>
    /// <typeparam name="TChildEntity">The entity type this view model represents.</typeparam>
    /// <typeparam name="TParentEntity">The entity type that is the parent of the 
    /// <typeparamref name="TChildEntity"/> entries in this model.</typeparam>
    /// <exception cref="ArgumentNullException">The value for a required parameter was a null 
    /// reference.</exception>
    public abstract partial class AttributeEntryGrouping<TParentEntity, TChildEntity>
    {
        protected AttributeEntryGrouping(
            TParentEntity parentObject, 
            ModelAttribute parentAttribute, 
            DateTime effectiveDate)
        {
            if (parentObject is null)
                throw new ArgumentNullException(paramName: nameof(parentObject));

            if (parentAttribute is null)
                throw new ArgumentNullException(paramName: nameof(parentAttribute));

            ParentObject = parentObject;
            ParentAttribute = parentAttribute;
            EffectiveDate = effectiveDate;
        }

        /// <summary>
        /// Gets the delegate for selecting the collection of entries for the parent object of this 
        /// grouping.
        /// </summary>
        protected abstract Func<TParentEntity, ICollection<TChildEntity>> ParentEntryMemberFor { get; }

        /// <summary>
        /// Gets the delegate for selecting the <typeparamref name="TChildEntity"/> entries in this 
        /// grouping.
        /// </summary>
        protected abstract Func<TChildEntity, bool> EntrySelector { get; }

        /// <summary>
        /// Gets the delegate for selecting the weight attribute for the 
        /// <typeparamref name="TChildViewModel"/> type.
        /// </summary>
        protected abstract Func<TChildEntity, decimal> WeightSelector { get; }

        /// <summary>
        /// Gets the collection of <typeparamref name="TChildEntity"/> representing the children 
        /// of <see cref="ParentObject"/>.
        /// </summary>
        private ICollection<TChildEntity> ParentEntryCollection => ParentEntryMemberFor(ParentObject);
        
        /// <summary>
        /// Sets the effective date of the given <typeparamref name="TChildEntity"/> entry to the 
        /// given <see cref="DateTime"/> value.
        /// </summary>
        /// <param name="entry"></param>
        /// <param name="effectiveDate"></param>
        /// <returns>True, if the update was successful, else false.</returns>
        protected abstract bool UpdateEffectiveDate(TChildEntity entry, DateTime effectiveDate);
    }

    #region IAttributeGrouping implementation
    public abstract partial class AttributeEntryGrouping<TParentEntity, TChildEntity> :
        IAttributeEntryGrouping<TParentEntity, TChildEntity>
        where TParentEntity : class, new()
        where TChildEntity : class, new()
    {
        private DateTime effectiveDate;

        [Display(
            Name = nameof(ModelDisplay.AttributeEntryViewModel_EffectiveDate_Name),
            ResourceType = typeof(ModelDisplay))]
        public DateTime EffectiveDate
        {
            get { return effectiveDate; }
            set
            {
                if(effectiveDate != value)
                {
                    if(Entries.All(x => UpdateEffectiveDate(x, value)))
                    {
                        effectiveDate = value;
                    }
                    else
                    {
                        throw new InvalidOperationException();
                    }
                }
            }
        }

        public bool IsEmpty => !Entries.Any();

        public IEnumerable<TChildEntity> Entries => ParentEntryCollection.Where(EntrySelector);

        public ModelAttribute ParentAttribute { get; init; }

        public TParentEntity ParentObject { get; private set; }

        [ExactValue(1D)]
        [Display(
            Name = nameof(ModelDisplay.AttributeEntryCollectionViewModel_SumOfWeights_Name),
            ResourceType = typeof(ModelDisplay))]
        public decimal SumOfMemberWeights => Entries.Sum(WeightSelector);

        public abstract TChildEntity AddNewEntry();

        public void AddRange(TChildEntity[] entries)
        {
            if(entries.Any())
                foreach (var entry in entries.Where(e => e is not null))
                    ParentEntryCollection.Add(entry);
        }

        public void AddEntry(TChildEntity entry) => ParentEntryCollection.Add(entry);

        public bool RemoveEntry(TChildEntity entry) => ParentEntryCollection.Remove(entry);

        public bool RemoveAll() => Entries.All(x => RemoveEntry(x));
    }
    #endregion
}