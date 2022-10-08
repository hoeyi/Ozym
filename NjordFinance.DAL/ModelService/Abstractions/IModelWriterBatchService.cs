using System;
using System.Threading.Tasks;

namespace NjordFinance.ModelService.Abstractions
{
    /// <summary>
    /// An implementation that provides write operations for a batch of 
    /// <typeparamref name="T"/> models.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IModelWriterBatchService<T>
        where T : class, new()
    {
        /// <summary>
        /// Returns true if changes have not been saved.
        /// </summary>
        bool IsDirty { get; }

        /// <summary>
        /// Attaches the given model to the service context as an addition.
        /// </summary>
        /// <param name="model">The model to add.</param>
        /// <returns>True if the entry state is added, else
        /// false.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="model"/> was null.</exception>
        /// <exception cref="InvalidOperationException"></exception>
        bool AddPendingSave(T model);

        /// <summary>
        /// Attaches the given model to the service context as a deletion.
        /// </summary>
        /// <param name="model">The model to add.</param>
        /// <returns>True if the entry state is deleted, else
        /// false.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="model"/> was null.</exception>
        /// <exception cref="InvalidOperationException"></exception>
        bool DeletePendingSave(T model);

        /// <summary>
        /// Creates the default instance of <typeparamref name="T"/>.
        /// </summary>
        /// <returns>A model <typeparamref name="T"/> with default values.</returns>
        Task<T> GetDefaultAsync();

        /// <summary>
        /// Saves pending changes within the service context to the data store.
        /// </summary>
        /// <returns>A task that represents the asynchronous save operation. The task result 
        /// contains the number of state entries written to the database.</returns>
        /// <exception cref="InvalidOperationException"><see cref="this.ParentKey"/> is not valid 
        /// for this call.</exception>/// 
        /// <exception cref="ModelUpdateException">An error occured when writing changes to the 
        /// data store.</exception>
        Task<int> SaveChangesAsync();
    }
}
