using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EulerFinancial.Controllers
{
    /// <summary>
    /// Represents an object responsible for directing application flow
    /// when reading, writing, or deleting records.
    /// </summary>
    /// <typeparam name="T">The <see cref="T"/> type worked by the contoller.</typeparam>
    public interface IController<T>
        where T : class, new()
    {
        /// <summary>
        /// Creates the default instance of <typeparamref name="T"/>.
        /// </summary>
        /// <returns>The generated <typeparamref name="T"/>.</returns>
        Task<T> GetDefault();

        /// <summary>
        /// Creates the given <paramref name="model"/>.
        /// </summary>
        /// <param name="model"></param>
        /// <returns>The added record, refreshed with data store values.</returns>
        Task<ActionResult<T>> CreateAsync(T model);

        /// <summary>
        /// Selects the instance of <typeparamref name="T"/> that matches the given
        /// <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The integer key to match.</param>
        /// <returns></returns>
        Task<ActionResult<T>> ReadAsync(int? id);

        /// <summary>
        /// Updates the given <paramref name="model"/>.
        /// </summary>
        /// <param name="model">The <typeparamref name="T"/> model to update.</param>
        /// <returns></returns>
        Task<ActionResult<T>> UpdateAsync(int? id, T model);

        /// <summary>
        /// Deletes the given <paramref name="model"/>.
        /// </summary>
        /// <param name="model">The <typeparamref name="T"/> model to delete.</param>
        /// <returns><see cref="true"/> if the operation is successful, else false.</returns>
        Task<IActionResult> DeleteAsync(T model);

        /// <summary>
        /// Select all records.
        /// </summary>
        /// <returns>A <see cref="IList{T}"/> representing all records in the data store.</returns>
        Task<ActionResult<IList<T>>> SelectAllAsync();

        /// <summary>
        /// Select the first record matching the given <paramref name="predicate"/>.
        /// </summary>
        /// <param name="predicate">The <see cref="Expression{Func{T}}"/> used to determine results.</param>
        /// <returns>A <see cref="IList{T}"/> representing the first record matching the predicate.</returns>
        Task<ActionResult<T>> SelectOneAsync(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Selects records matching the given <paramref name="predicate"/>, 
        /// with the count limited to the value of <paramref name="maxCount"/>.
        /// </summary>
        /// <param name="predicate">The <see cref="Expression{Func{T}}"/> used to determine results.</param>
        /// <param name="maxCount">The maximum count of results to return. Default is zero.</param>
        /// <returns>A <see cref="IList{T}"/> representing the records matching the predicate, limited to a maximum count.</returns>
        Task<ActionResult<IList<T>>> SelectWhereAysnc(
            Expression<Func<T, bool>> predicate, int maxCount = 0);
    }
}
