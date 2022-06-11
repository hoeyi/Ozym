using NjordFinance.ModelService.Abstractions;
using System;

namespace NjordFinance.ModelService
{
    /// <summary>
    /// A serivce implementation responsible for reading and writing models. Edit requests 
    /// are processed as a batch for changed models.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IModelBatchService<T> : 
            IModelBaseService<T>,
            IModelReaderService<T>, 
            IModelWriterBatchService<T>
        where T : class, new()
    {
        /// <summary>
        /// Configures the service to work all models as children of a model 
        /// with an id equal to value of <paramref name="parentId"/>.
        /// </summary>
        /// <param name="parentId"></param>
        /// <param name="e">The exception describing the reason configuration failed, or null 
        /// if successful.</param>
        /// <returns>True, if the operation is successful, else false.</returns>
        bool ForParent(int parentId, out NotSupportedException e);
    }
}
