using System.Threading.Tasks;

namespace NjordFinance.ModelService.Abstractions
{
    /// <summary>
    /// An implementation that provides write operations for <typeparamref name="T"/> models.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IModelWriterService<T>
        where T : class, new()
    {
        /// <summary>
        /// Creates the given <paramref name="model"/>.
        /// </summary>
        /// <param name="model"></param>
        /// <returns>The added record, refreshed with data store values.</returns>
        Task<T> CreateAsync(T model);

        /// <summary>
        /// Creates the default instance of <typeparamref name="T"/>.
        /// </summary>
        /// <returns>A model <typeparamref name="T"/> with default values.</returns>
        Task<T> GetDefaultAsync();

        /// <summary>
        /// Updates the given <paramref name="model"/>.
        /// </summary>
        /// <param name="model">The <typeparamref name="T"/> model to update.</param>
        /// <returns></returns>
        Task<bool> UpdateAsync(T model);

        /// <summary>
        /// Deletes the given <paramref name="model"/>.
        /// </summary>
        /// <param name="model">The <typeparamref name="T"/> model to delete.</param>
        /// <returns>True if the operation is successful, else false.</returns>
        Task<bool> DeleteAsync(T model);
    }
}
