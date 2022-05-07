using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NjordFinance.ModelService.Abstractions
{
    /// <summary>
    /// Worker class for servicing CRUD requests against 
    /// a data store of <typeparamref name="T"/> models. That are 
    /// worked one at a time.
    /// </summary>
    /// <typeparam name="T">The model type.</typeparam>
    public interface IModelServiceSingle<T>
        where T : class, new()
    {
        /// <summary>
        /// Gets the <see cref="IModelReaderService{T}"/> for this service.
        /// </summary>
        IModelReaderService<T> Reader { get; }

        /// <summary>
        /// Gets the <see cref="IModelWriterService{T}"/> for this service.
        /// </summary>
        IModelWriterService<T> Writer { get; }
    }
}
