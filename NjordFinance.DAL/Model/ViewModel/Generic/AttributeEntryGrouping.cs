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
        private readonly List<TChildEntity> _entries = new();

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

            var initialEntries = SelectEntries(
                parentEntity: ParentObject,
                parentAttribute: ParentAttribute,
                effectiveDate: EffectiveDate);

            _entries.AddRange(initialEntries);
        }

        /// <summary>
        /// Gets the delegate for selecting the weight attribute for the 
        /// <typeparamref name="TChildViewModel"/> type.
        /// </summary>
        protected abstract Func<TChildEntity, decimal> WeightSelector { get; }
        
        /// <summary>
        /// Selects the <typeparamref name="TChildEntity"/> entries that are members of this 
        /// grouping.
        /// </summary>
        /// <param name="parentEntity">The parent <typeparamref name="TParentEntity"/>.</param>
        /// <param name="parentAttribute">The parent <see cref="ModelAttribute"/>.</param>
        /// <param name="effectiveDate">The date key for the grouping.</param>
        /// <returns></returns>
        protected abstract IEnumerable<TChildEntity> SelectEntries(
            TParentEntity parentEntity, ModelAttribute parentAttribute, DateTime effectiveDate);
    }

    #region IAttributeGrouping implementation
    public abstract partial class AttributeEntryGrouping<TParentEntity, TChildEntity> :
        IAttributeEntryGrouping<TParentEntity, TChildEntity>
        where TParentEntity : class, new()
        where TChildEntity : class, new()
    {
        [Display(
            Name = nameof(ModelDisplay.AttributeEntryViewModel_EffectiveDate),
            ResourceType = typeof(ModelDisplay))]
        public DateTime EffectiveDate { get; set; }

        public IList<TChildEntity> Entries => _entries;

        public ModelAttribute ParentAttribute { get; init; }

        public TParentEntity ParentObject { get; private set; }

        [ExactValue(1D)]
        [Display(
            Name = nameof(ModelDisplay.AttributeEntryCollectionViewModel_SumOfWeights),
            ResourceType = typeof(ModelDisplay))]
        public decimal SumOfMemberWeights => Entries.Sum(WeightSelector);
    }
    #endregion
}