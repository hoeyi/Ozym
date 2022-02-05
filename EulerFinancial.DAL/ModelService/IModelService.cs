using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EulerFinancial.ModelService
{
    /// <summary>
    /// Worker class for servicing CRUD requests against 
    /// a data store of <typeparamref name="T"/> models.
    /// </summary>
    /// <typeparam name="T">The model type.</typeparam>
    public interface IModelService<T>
        where T : class, new()
    {
        /// <summary>
        /// Creates the default instance of <typeparamref name="T"/>.
        /// </summary>
        /// <returns>A model <typeparamref name="T"/> with default values.</returns>
        Task<T> GetDefaultAsync();

        /// <summary>
        /// Creates the given <paramref name="model"/>.
        /// </summary>
        /// <param name="model"></param>
        /// <returns>The added record, refreshed with data store values.</returns>
        Task<T> CreateAsync(T model);

        /// <summary>
        /// Selects the instance of <typeparamref name="T"/> that matches the given
        /// <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The integer key to match.</param>
        /// <returns></returns>
        Task<T> ReadAsync(int? id);

        /// <summary>
        /// Updates the given <paramref name="model"/>.
        /// </summary>
        /// <param name="model">The <typeparamref name="T"/> model to update.</param>
        /// <returns></returns>
        Task<bool> UpdateAsync(T model);

        /// <summary>
        /// Deletes the given <paramref name="model"/>.
        /// </summary>
        /// <param name="model">The <typeparamref name="T"/> model to delete.</param>
        /// <returns><see cref="true"/> if the operation is successful, else false.</returns>
        Task<bool> DeleteAsync(T model);

        /// <summary>
        /// Checks a model with the given <paramref name="id"/> exists.
        /// </summary>
        /// <param name="id">The integer key to match.</param>
        /// <returns></returns>
        bool ModelExists(int? id);

        /// <summary>
        /// Checks the given <paramref name="model"/> exists.
        /// </summary>
        /// <param name="model">The <typeparamref name="T"/> model to match.</param>
        /// <returns>True if <paramref name="model"/> is found, else false.</returns>
        bool ModelExists(T model);

        /// <summary>
        /// Select all records.
        /// </summary>
        /// <returns>A <see cref="IList{T}"/> representing all records in the data store.</returns>
        Task<List<T>> SelectAllAsync();

        /// <summary>
        /// Selects records matching the given <paramref name="predicate"/>, 
        /// with the count limited to the value of <paramref name="maxCount"/>.
        /// </summary>
        /// <param name="predicate">The <see cref="Expression{Func{T}}"/> used to determine results.</param>
        /// <param name="maxCount">The maximum count of results to return. Default is zero.</param>
        /// <returns>A <see cref="IList{T}"/> representing the records matching the predicate, limited to a maximum count.</returns>
        Task<List<T>> SelectWhereAysnc(Expression<Func<T, bool>> predicate, int maxCount = 0);
    }
}
