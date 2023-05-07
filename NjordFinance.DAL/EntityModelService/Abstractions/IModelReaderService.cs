using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NjordFinance.EntityModelService.Abstractions
{
    /// <summary>
    /// An implementation that provides read operations for <typeparamref name="T"/> models.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IModelReaderService<T>
        where T: class, new()
    {
        /// <summary>
        /// Checks a model with the given <paramref name="id"/> exists.
        /// </summary>
        /// <param name="id">The integer key to match.</param>
        /// <returns>True if a model whose primary key matches <paramref name="id"/>, else false.</returns>
        bool ModelExists(int? id);

        /// <summary>
        /// Checks the given <paramref name="model"/> exists.
        /// </summary>
        /// <param name="model">The <typeparamref name="T"/> model to match.</param>
        /// <returns>True if <paramref name="model"/> is found, else false.</returns>
        bool ModelExists(T model);

        /// <summary>
        /// Selects the instance of <typeparamref name="T"/> that matches the given
        /// <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The integer key to match.</param>
        /// <returns></returns>
        Task<T> ReadAsync(int? id);

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
