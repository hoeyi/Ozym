using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NjordFinance.Controllers
{
    /// <summary>
    /// Represents the controller for a given <typeparamref name="T"/> model.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBatchController<T>
        where T: class, new()
    {
        /// <summary>
        /// Initializes the intance with the given parent key. Call this method before all others.
        /// </summary>
        /// <param name="parentKey">The key for the parent of objects passed through this service.
        /// </param>
        /// <returns>An <see cref="IActionResult"/> representing the returned status code.
        /// </returns>
        /// <remarks>Calls to other methods fail if this method has not been successfully called 
        /// first.</remarks>
        IActionResult Initialize(object parentKey);

        /// <summary>
        /// Adds the model pending a call to <see cref="SaveChangesAsync"/>.
        /// </summary>
        /// <param name="model">The model to add.</param>
        /// <returns>True if the entry state is added, else
        /// false.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="model"/> was null.</exception>
        /// <exception cref="InvalidOperationException"> parent key is not valid for this call.
        /// </exception>
        Task<IActionResult> AddAsync(T model);

        /// <summary>
        /// Deletes the model pending a call to <see cref="SaveChangesAsync"/>.
        /// </summary>
        /// <param name="model">The model to add.</param>
        /// <returns>True if the entry state is deleted, else
        /// false.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="model"/> was null.</exception>
        /// <exception cref="InvalidOperationException"> parent key is not valid for this call.
        /// </exception>
        Task<IActionResult> DeleteAsync(T model);

        /// <summary>
        /// Creates the default instance of <typeparamref name="T"/>.
        /// </summary>
        /// <returns>The action response wrapping the generated <typeparamref name="T"/>.</returns>
        Task<ActionResult<T>> GetDefaultAsync();

        /// <summary>
        /// Saves pending changes within the service context to the data store.
        /// </summary>
        /// <returns>A task that represents the asynchronous save operation.</returns>
        /// <exception cref="InvalidOperationException"> parent key is not valid for this call.
        /// </exception>
        Task<ActionResult> SaveChangesAsync();

        /// <summary>
        /// Selects records matching the given <paramref name="predicate"/>, 
        /// with the count limited to the value of <paramref name="maxCount"/>.
        /// </summary>
        /// <param name="predicate">The <see cref="Expression{Func{T}}"/> used to determine 
        /// results.</param>
        /// <param name="maxCount">The maximum count of results to return. Default is zero.</param>
        /// <returns>A <see cref="IList{T}"/> representing the records matching the predicate, 
        /// limited to a maximum count.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="predicate"/> was null.</exception>
        /// <exception cref="InvalidOperationException"> parent key is not valid for this call.
        /// </exception>
        Task<ActionResult<IList<T>>> SelectWhereAysnc(
            Expression<Func<T, bool>> predicate, int maxCount = 0);
    }
}
