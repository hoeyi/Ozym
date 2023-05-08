using NjordinSight.EntityModelService.Abstractions;
using System;

namespace NjordinSight.EntityModelService
{
    /// <summary>
    /// A serivce implementation responsible for reading and writing models. Edit requests 
    /// are processed as a batch for changed models.
    /// </summary>
    /// <typeparam name="T">The record type.</typeparam>
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
        /// <param name="parentId">The integer id for the parent record.</param>
        /// <param name="e">The exception describing the reason configuration failed, or null 
        /// if successful.</param>
        /// <exception cref="Exception">The exception thrown indicating the reason 
        /// for the failure.</exception>
        /// <returns>True, if the operation is successful, else false.</returns>
        bool ForParent(int parentId, out Exception e);
    }

    /// <summary>
    /// A serivce implementation responsible for reading and writing models. Edit requests 
    /// are processed as a batch for changed models.
    /// </summary>
    /// <typeparam name="T">The record type.</typeparam>
    /// <typeparam name="TParent">The parent type.</typeparam>
    public interface IModelBatchService<T, TParent> : IModelBatchService<T>
        where T : class, new ()
    {
        /// <summary>
        /// Configures the service to work all models as children of a composite
        /// </summary>
        /// <param name="parent">The parent record.</param>
        /// <param name="e">The exception describing the reason configuration failed, or null 
        /// if successful.</param>
        /// <exception cref="Exception">The exception thrown indicating the reason 
        /// for the failure.</exception>
        /// <returns>True, if the operation is successful, else false.</returns>
        bool ForParent(TParent parent, out Exception e);
    }
}
