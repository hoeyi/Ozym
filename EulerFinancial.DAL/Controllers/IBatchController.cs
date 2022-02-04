using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EulerFinancial.Controllers
{
    /// <summary>
    /// Represents the controller for a given <typeparamref name="T"/> model and parent key type 
    /// <typeparamref name="TParentKey"/>.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TParentKey"></typeparam>
    public interface IBatchController<T, TParentKey>
        where T: class, new()
        where TParentKey: struct
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
        IActionResult Initialize(TParentKey parentKey);

        /// <summary>
        /// Adds the model pending a call to <see cref="SaveChanges"/>.
        /// </summary>
        /// <param name="model">The model to add.</param>
        /// <returns>True if the entry state is added, else
        /// false.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="model"/> was null.</exception>
        /// <exception cref="InvalidOperationException"> parent key is not valid for this call.
        /// </exception>
        Task<IActionResult> Add(T model);

        /// <summary>
        /// Deletes the model pending a call to <see cref="SaveChanges"/>.
        /// </summary>
        /// <param name="model">The model to add.</param>
        /// <returns>True if the entry state is deleted, else
        /// false.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="model"/> was null.</exception>
        /// <exception cref="InvalidOperationException"> parent key is not valid for this call.
        /// </exception>
        Task<IActionResult> Delete(T model);

        /// <summary>
        /// Saves pending changes within the service context to the data store.
        /// </summary>
        /// <returns>A task that represents the asynchronous save operation. The task result 
        /// contains the number of state entries written to the database.</returns>
        /// <exception cref="InvalidOperationException"> parent key is not valid for this call.
        /// </exception>
        Task<ActionResult<int>> SaveChanges();

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
