using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EulerFinancial.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace EulerFinancial.ModelService
{
    /// <summary>
    /// Worker class for servicing CRUD requests against a data store of 
    /// <typeparamref name="T"/> models.
    /// </summary>
    /// <typeparam name="T">The model type.</typeparam>
    public interface IBatchModelService<T>
        where T : class, new()
    {
        /// <summary>
        /// Creates the default instance of <typeparamref name="T"/>.
        /// </summary>
        /// <returns>A model <typeparamref name="T"/> with default values.</returns>
        Task<T> GetDefault();

        /// <summary>
        /// Initializes the intance with the given parent key. Call this method before all others.
        /// </summary>
        /// <param name="parentKey">The key for the parent of objects passed through this service.</param>
        /// <returns>An <see cref="IActionResult"/> representing the returned status code.
        /// </returns>
        /// <remarks>Calls to other methods fail if this method has not been successfully called 
        /// first.</remarks>
        bool Initialize(object parentKey);

        /// <summary>
        /// Checks the given model for presence in the service context.
        /// </summary>
        /// <param name="model">The model to check.</param>
        /// <returns>True if the given model exists, else false.</returns>
        bool ModelExists(T model);

        /// <summary>
        /// Attaches the given model to the service context as an addition.
        /// </summary>
        /// <param name="model">The model to add.</param>
        /// <returns>True if the entry state is added, else
        /// false.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="model"/> was null.</exception>
        /// <exception cref="InvalidOperationException"><see cref="this.ParentKey"/> is not valid 
        /// for this call.</exception>/// 
        bool AddPendingSave(T model);

        /// <summary>
        /// Attaches the given model to the service context as a deletion.
        /// </summary>
        /// <param name="model">The model to add.</param>
        /// <returns>True if the entry state is deleted, else
        /// false.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="model"/> was null.</exception>
        /// <exception cref="InvalidOperationException"><see cref="this.ParentKey"/> is not valid 
        /// for this call.</exception>/// 
        bool DeletePendingSave(T model);

        /// <summary>
        /// Saves pending changes within the service context to the data store.
        /// </summary>
        /// <returns>A task that represents the asynchronous save operation. The task result 
        /// contains the number of state entries written to the database.</returns>
        /// <exception cref="InvalidOperationException"><see cref="this.ParentKey"/> is not valid 
        /// for this call.</exception>/// 
        /// <exception cref="ModelUpdateException">An error occured when writing changes to the 
        /// data store.</exception>
        Task<int> SaveChanges();

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
        /// <exception cref="InvalidOperationException"><see cref="ParentKey"/> is not valid 
        /// for this call.</exception>/// 
        Task<List<T>> SelectWhereAysnc(
            Expression<Func<T, bool>> predicate, int maxCount = 0);
    }
}