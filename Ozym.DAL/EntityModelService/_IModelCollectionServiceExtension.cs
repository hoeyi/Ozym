using Ozym.EntityModelService.Abstractions;
using System;

namespace Ozym.EntityModelService
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
        public static IModelCollectionService<T, int> WithParent<T>(
            this IModelCollectionService<T, int> service, int parentId)
            where T : class, new()
        {
            service.SetParent(parentId);

            return service;
        }

        /// <summary>
        /// Configures the service to work all models as children of a composite
        /// </summary>
        /// <param name="parent">The parent record.</param>
        /// if successful.</param>
        /// <returns>True, if the operation is successful, else false.</returns>
        public static IModelCollectionService<T, TParent> WithParent<T, TParent>(
            this IModelCollectionService<T, TParent> service, TParent parent)
                        where T : class, new()
        {
            service.SetParent(parent);

            return service;
        }
    }
}
