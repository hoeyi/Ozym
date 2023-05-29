using Microsoft.AspNetCore.Mvc;
using NjordinSight.EntityModelService.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NjordinSight.Web.Controllers
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
        /// <returns>The action response wrapping the generated <typeparamref name="T"/>.</returns>
        Task<ActionResult<T>> GetDefaultAsync();

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
        /// <returns>A <see cref="IEnumerable{T}"/> representing all records in the data store.</returns>
        Task<ActionResult<IEnumerable<T>>> SelectAllAsync();

        /// <summary>
        /// Selects records matching the given <paramref name="predicate"/>, 
        /// with the count limited to the value of <paramref name="maxCount"/>.
        /// </summary>
        /// <param name="predicate">The <see cref="Expression{Func{T}}"/> used to determine results.</param>
        /// <param name="maxCount">The maximum count of results to return. Default is zero.</param>
        /// <returns>A <see cref="IEnumerable{T}"/> representing the records matching the predicate, limited to a maximum count.</returns>
        Task<ActionResult<IEnumerable<T>>> SelectWhereAysnc(
            Expression<Func<T, bool>> predicate, int maxCount = 0);

        /// <summary>
        /// Selects records matching the given <paramref name="predicate"/>, limited to the given
        /// page index, and page size.
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns>An <see cref="ActionResult{TValue}"/> whose value is a tuple containing 
        /// and enumeration of results and metadata about the query.</returns>
        Task<ActionResult<(IEnumerable<T>, PaginationData)>> SelectAsync(
            Expression<Func<T, bool>> predicate, int pageNumber = 1, int pageSize = 20);

        /// <summary>
        /// Represents the <see cref="IQueryController"/> instance used for retrieving data-transfer 
        /// objects representing valid foreign-key value options.
        /// </summary>
        IQueryController ReferenceQueries { get; }
    }
}
