using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EulerFinancial.Data
{
    public interface IModelService<T>
        where T : class, new()
    {
        Task<bool> CreateAsync(T model);

        Task<T> ReadAsync(int? id);

        Task<bool> UpdateAsync(T model);

        Task<bool> DeleteAsync(T model);

        bool ModelExists(int? id);

        bool ModelExists(T model);

        /// <summary>
        /// Select all records.
        /// </summary>
        /// <returns>A <see cref="IList{T}"/> representing all records in the data store.</returns>
        Task<IList<T>> SelectAllAsync();

        /// <summary>
        /// Select the first record matching the given <paramref name="predicate"/>.
        /// </summary>
        /// <param name="predicate">The <see cref="Expression{Func{T}}"/> used to determine results.</param>
        /// <returns>A <see cref="IList{T}"/> representing the first record matching the predicate.</returns>
        Task<T> SelectOneAsync(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Selects records matching the given <paramref name="predicate"/>, 
        /// with the count limited to the value of <paramref name="maxCount"/>.
        /// </summary>
        /// <param name="predicate">The <see cref="Expression{Func{T}}"/> used to determine results.</param>
        /// <param name="maxCount">The maximum count of results to return. Default is zero.</param>
        /// <returns>A <see cref="IList{T}"/> representing the records matching the predicate, limited to a maximum count.</returns>
        Task<IList<T>> SelectWhereAysnc(Expression<Func<T, bool>> predicate, int maxCount = 0);
    }
}
