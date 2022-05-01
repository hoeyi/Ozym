using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NjordFinance.Reference
{
    /// <summary>
    /// Represents a worker class for reading models from the data store.
    /// </summary>
    public interface IReferenceDataService
    {
        /// <summary>
        /// Returns a single <typeparamref name="T"/> from the data store, or throws an exception 
        /// if the sequence does not return a single result.
        /// </summary>
        /// <typeparam name="T">The model type to return.</typeparam>
        /// <param name="predicate">The expression to match the <typeparamref name="T"/>.</param>
        /// <param name="includeNavigationPath">The path for the navigation property to include. 
        /// The default is null, which does not load related data.</param>
        /// <returns>The <typeparamref name="T"/> instance that matches the 
        /// <paramref name="predicate"/>.</returns>
        Task<T> GetSingleAsync<T>(
            Expression<Func<T, bool>> predicate, 
            string includeNavigationPath = null) where T : class, new();

        /// <summary>
        /// Gets all <typeparamref name="T"/> instances that are saved in the data store.
        /// </summary>
        /// <typeparam name="T">The model type to return.</typeparam>
        /// <returns><see cref="IList{T}"/>.</returns>
        Task<IList<T>> GetAllAsync<T>() where T : class, new();

        /// <summary>
        /// Gets all <typeparamref name="T"/> instances matching the given predicate that are 
        /// saved in the data store.
        /// </summary>
        /// <typeparam name="T">The model type to return.</typeparam>
        /// <param name="predicate">The expression to filter results.</param>
        /// <returns><see cref="IList{T}"/> whose elements match the 
        /// <paramref name="predicate"/>.</returns>
        Task<IList<T>> GetWhereAsync<T>(Expression<Func<T, bool>> predicate) where T : class, new();
    }
}
