using System;

namespace NjordinSight.EntityModelService
{
    public static class IModelBatchServiceExtension
    {
        /// <summary>
        /// Configures the service to work all models as children of a model 
        /// with an id equal to value of <paramref name="parentId"/>.
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns>The service instance.</returns>
        /// <exception cref="InvalidOperationException">Service initialization with the 
        /// given parent id failed.</exception>
        public static IModelBatchService<T> WithParent<T>(
            this IModelBatchService<T> service, int parentId)
            where T : class, new()
        {
            if (service.ForParent(parentId, out Exception _))
                return service;
            else
                throw new InvalidOperationException();
        }

        /// <summary>
        /// Configures the service to work all models as children of a composite
        /// </summary>
        /// <param name="parent">The parent record.</param>
        /// if successful.</param>
        /// <returns>True, if the operation is successful, else false.</returns>
        public static IModelBatchService<T, TParent> WithParent<T, TParent>(
            this IModelBatchService<T, TParent> service, TParent parent)
                        where T : class, new()
        {
            if (service.ForParent(parent, out Exception _))
                return service;
            else
                throw new InvalidOperationException();
        }
    }
}
