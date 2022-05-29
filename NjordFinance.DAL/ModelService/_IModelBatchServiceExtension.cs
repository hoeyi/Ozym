using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NjordFinance.ModelService
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
            if (service.ForParent(parentId))
                return service;
            else
                throw new InvalidOperationException();
        }
    }
}
