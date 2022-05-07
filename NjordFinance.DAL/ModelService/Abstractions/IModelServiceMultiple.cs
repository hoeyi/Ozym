using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using NjordFinance.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace NjordFinance.ModelService.Abstractions
{
    /// <summary>
    /// Worker class for servicing CRUD requests against a data store of 
    /// <typeparamref name="T"/> models that are children of a parent object.
    /// </summary>
    /// <typeparam name="T">The model type.</typeparam>
    public interface IModelServiceMultiple<T>
        where T : class, new()
    {
        /// <summary>
        /// Gets the <see cref="IModelReaderService{T}"/> for this service.
        /// </summary>
        IModelReaderService<T> Reader { get; }

        /// <summary>
        /// Gets the <see cref="IModelWriterBatchService{T}"/> for this service.
        /// </summary>
        IModelWriterBatchService<T> Writer { get; }

        /// <summary>
        /// Configures the service for use under the pre-defined parent 
        /// with id equal to <paramref name="parentId"/>.
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns>True if the configuration was successful, else false.</returns>
        bool ForParent(int parentId);
    }
}