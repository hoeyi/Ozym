using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ozym.EntityModelService.Abstractions
{
    /// <summary>
    /// An implementation that provides write operations for a batch of 
    /// <typeparamref name="T"/> models.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IModelCollectionWriterService<T>
        where T : class, new()
    {
        /// <summary>
        /// Adds, updates, or delets the given collections.
        /// </summary>
        /// <param name="insert">The collection of <typeparamref name="T"/> to insert.</param>
        /// <param name="updates">The collection of <typeparamref name="T"/> to update.</param>
        /// <param name="deletes">The collection of <typeparamref name="T"/> to delete.</param>
        /// <returns>The <see cref="int"/> giving the total count of <typeparamref name="T"/> records 
        /// inserted, updated, or deleted.</returns>
        Task<int> AddUpdateDeleteAsync(
            IEnumerable<T> insert, IEnumerable<T> updates, IEnumerable<T> deletes);
    }
}
