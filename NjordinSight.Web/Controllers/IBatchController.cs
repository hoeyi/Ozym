using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NjordinSight.Web.Controllers
{
    /// <summary>
    /// Represents the controller for a given <typeparamref name="T"/> model.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBatchController<T>
        where T: class, new()
    {
        /// <summary>
        /// Represents the <see cref="IQueryController"/> instance used for retrieving data-transfer 
        /// objects representing valid foreign-key value options.
        /// </summary>
        IQueryController ReferenceQueries { get; }

        /// <summary>
        /// Initializes the intance with the given parent key. Call this method before all others.
        /// </summary>
        /// <param name="parentId">The key for the parent of models worked by this service.
        /// </param>
        /// <returns>An <see cref="IActionResult"/> representing the returned status code.
        /// </returns>
        /// <remarks>Calls to other methods fail if this method has not been successfully called 
        /// first.</remarks>
        Task<IActionResult> ForParent(int parentId);

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
        /// Deletes the model pending a call to <see cref="SaveChangesAsync"/>, or detach an
        /// unsaved model.
        /// </summary>
        /// <param name="model">The model to add.</param>
        /// <returns>True if the entry state is deleted, else
        /// false.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="model"/> was null.</exception>
        /// <exception cref="InvalidOperationException"> parent key is not valid for this call.
        /// </exception>
        Task<IActionResult> DeleteOrDetachAsync(T model);

        /// <summary>
        /// Creates the default instance of <typeparamref name="T"/>.
        /// </summary>
        /// <returns>The action response wrapping the generated <typeparamref name="T"/>.</returns>
        Task<ActionResult<T>> GetDefaultAsync();

        /// <summary>
        /// Checks the given model exists within the data store.
        /// </summary>
        /// <param name="model">The <typeparamref name="T"/> instance to search for.</param>
        /// <returns>True if the model's key exists in the data store, else false.</returns>
        Task<ActionResult<bool>> ModelExistsAsync(T model);

        /// <summary>
        /// Saves pending changes within the service context to the data store.
        /// </summary>
        /// <returns>A task that represents the asynchronous save operation.</returns>
        /// <exception cref="InvalidOperationException"> parent key is not valid for this call.
        /// </exception>
        Task<ActionResult> SaveChangesAsync();

        /// <summary>
        /// Selects all records accessible to this controller.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{T}"/> representing the records.</returns>
        Task<ActionResult<IEnumerable<T>>> SelectAllAsync();

        /// <summary>
        /// Selects records matching the given <paramref name="predicate"/>, 
        /// with the count limited to the value of <paramref name="maxCount"/>.
        /// </summary>
        /// <param name="predicate">The <see cref="Expression{Func{T}}"/> used to determine 
        /// results.</param>
        /// <param name="maxCount">The maximum count of results to return. Default is zero.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> representing the records matching the predicate, 
        /// limited to a maximum count.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="predicate"/> was null.</exception>
        /// <exception cref="InvalidOperationException"> parent key is not valid for this call.
        /// </exception>
        Task<ActionResult<IEnumerable<T>>> SelectWhereAsync(
            Expression<Func<T, bool>> predicate, int maxCount = 0);
    }
}
