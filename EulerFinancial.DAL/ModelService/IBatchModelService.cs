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
    public interface IBatchModelService<T>
        where T : class, new()
    {
        /// <summary>
        /// Attaches the given model to the service context as an addition.
        /// </summary>
        /// <param name="model">The model to add.</param>
        /// <returns>True if the entry state returns <see cref="EntityState.Added"/>, else
        /// false.</returns>
        bool Add(T model);

        /// <summary>
        /// Attaches the given model to the service context as a deletion.
        /// </summary>
        /// <param name="model">The model to add.</param>
        /// <returns>True if the entry state returns <see cref="EntityState.Deleted"/>, else
        /// false.</returns>
        bool Delete(T model);

        /// <summary>
        /// Saves pending changes within the service context to the data store.
        /// </summary>
        /// <returns>A task that represents the asynchronous save operation. The task result 
        /// contains the number of state entries written to the database.</returns>
        Task<int> SaveChanges();

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