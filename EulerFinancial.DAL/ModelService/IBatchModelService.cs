using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EulerFinancial.ModelService
{
    /// <summary>
    /// Worker class for servicing CRUD requests against a data store of 
    /// <typeparamref name="T"/> models.
    /// </summary>
    /// <typeparam name="T">The model type.</typeparam>
    public interface IBatchModelService<T, TParentKey>
        where T : class, new()
        where TParentKey: struct
    {
        /// <summary>
        /// Attaches the given model to the service context as an addition.
        /// </summary>
        /// <param name="model">The model to add.</param>
        /// <param name="parentKey">The <typeparamref name="TParentKey"/> key for the parent 
        /// of objects worked using this service.</param>
        /// <returns>True if the entry state returns <see cref="EntityState.Added"/>, else
        /// false.</returns>
        /// <exception cref="InvalidOperationException">The <paramref name="parentKey"/> provided 
        /// is consistent with other calls to this servcie.</exception>
        bool Add(T model, TParentKey parentKey);

        /// <summary>
        /// Attaches the given model to the service context as a deletion.
        /// </summary>
        /// <param name="model">The model to add.</param>
        /// <param name="parentKey">The <typeparamref name="TParentKey"/> key for the parent 
        /// of objects worked using this service.</param>
        /// <returns>True if the entry state returns <see cref="EntityState.Deleted"/>, else
        /// false.</returns>
        /// <exception cref="InvalidOperationException">The <paramref name="parentKey"/> provided 
        /// is consistent with other calls to this servcie.</exception>
        bool Delete(T model, TParentKey parentKey);

        /// <summary>
        /// Saves pending changes within the service context to the data store.
        /// </summary>
        /// <returns>A task that represents the asynchronous save operation. The task result 
        /// contains the number of state entries written to the database.</returns>
        /// <exception cref="InvalidOperationException">The <paramref name="parentKey"/> provided 
        /// is consistent with other calls to this servcie.</exception>/// 
        Task<int> SaveChanges();

        /// <summary>
        /// Selects records matching the given <paramref name="predicate"/>, 
        /// with the count limited to the value of <paramref name="maxCount"/>.
        /// </summary>
        /// <param name="predicate">The <see cref="Expression{Func{T}}"/> used to determine 
        /// results.</param>
        /// <param name="parentKey">The <typeparamref name="TParentKey"/> key for the parent 
        /// of objects worked using this service.</param>
        /// <param name="maxCount">The maximum count of results to return. Default is zero.</param>
        /// <returns>A <see cref="IList{T}"/> representing the records matching the predicate, 
        /// limited to a maximum count.</returns>
        /// <exception cref="InvalidOperationException">The <paramref name="parentKey"/> provided 
        /// is consistent with other calls to this servcie.</exception>
        Task<List<T>> SelectWhereAysnc(
            Expression<Func<T, bool>> predicate, TParentKey parentKey, int maxCount = 0);
    }
}