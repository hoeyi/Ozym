using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// Gets the effective date for entries in this collection.
        /// </summary>
        DateTime EffectiveDate { get; set; }

        /// <summary>
        /// Gets the collection of <typeparamref name="TEntry"/> entries in this model.
        /// </summary>
        IList<TEntryEntity> Entries { get; }

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
        /// Gets the sum of all entry weights in this grouping.
        /// </summary>
        public decimal SumOfMemberWeights { get; }
    }
}
