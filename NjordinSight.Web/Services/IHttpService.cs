using NjordinSight.DataTransfer;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NjordinSight.ChangeTracking;
using Ichosys.DataModel.Expressions;
using AutoMapper.Configuration.Conventions;

namespace NjordinSight.Web.Services
{
    /// <summary>
    /// Interface representing methods for interacting with a RESTful web api.
    /// </summary>
    public interface IHttpService
    {
        /// <summary>
        /// Selects the <typeparamref name="TRecord"/> records matching the given 
        /// <paramref name="queryParameter"/>, limited to the given
        /// page index, and page size.
        /// </summary>
        /// <param name="queryParameter"><see cref="IQueryParameter{T}"/> instance describing the 
        /// query filter.</param>
        /// <param name="pageNumber">Index of the page of results to return.</param>
        /// <param name="pageSize">Limit to records returned in a single page.</param>
        /// <returns>A task containing the <see cref="IEnumerable{T}"/> of <typeparamref name="T"/> 
        /// matching the given predication and page parameters.</returns>
        Task<(IEnumerable<TRecord>, PaginationData)> SearchAsync<TRecord>(
            IQueryParameter<TRecord> queryParameter, int pageNumber = 1, int pageSize = 20);

        /// <summary>
        /// Get the <typeparamref name="TRecord"/> instanced identified by the given id value.
        /// </summary>
        /// <typeparam name="TRecord">The type of record.</typeparam>
        /// <param name="id">The unique identifier for the record.</param>
        /// <returns>An instance of <typeparamref name="TRecord"/> matching the value of 
        /// <paramref name="id"/>.</returns>
        Task<TRecord> GetAsync<TRecord>(int id);

        /// <summary>
        /// Retrieves all <typeparamref name="TRecord"/> records from the data store.
        /// </summary>
        /// <typeparam name="TRecord"></typeparam>
        /// <returns>An <see cref="IEnumerable{T}"/> of <typeparamref name="TRecord"/>.</returns>
        Task<IEnumerable<TRecord>> GetAllAsync<TRecord>();
    }

    /// <summary>
    /// Interface representing methods for interacting with a RESTful web api.
    /// </summary>
    /// <typeparam name="T">Is the class interacted with via this service.</typeparam>
    public interface IHttpService<T> : IHttpService
    {
        /// <summary>
        /// Deletes the <typeparamref name="T"/> resource matching the given identifier.
        /// </summary>
        /// <param name="id">Identifer of the resource to delete.</param>
        /// <returns>A task representing the completed operation.</returns>
        Task DeleteAsync(int id);

        /// <summary>
        /// Gets the <typeparamref name="T"/> resource matching the given identifier.
        /// </summary>
        /// <param name="id">The integer key to match.</param>
        /// <returns>The <typeparamref name="T"/> identified by <paramref name="id"/>.</returns>
        Task<T> GetAsync(int? id);

        /// <summary>
        /// Creates a default instance of <typeparamref name="T"/>.
        /// </summary>
        /// <returns>An instance of <typeparamref name="T"/>.
        Task<T> InitDefaultAsync();

        /// <summary>
        /// Posts the given <typeparamref name="T"/> resource to the data store.
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A task containing the <see cref="Uri"/> for the created resource.</returns>
        Task<Uri> PostAysnc(T model);

        /// <summary>
        /// Replaces the <typeparamref name="T"/> resource matching the given identifier.
        /// </summary>
        /// <param name="model">The <typeparamref name="T"/> model to update.</param>
        /// <returns>A task containing the <see cref="Uri"/> for the created resource.</returns>
        Task<Uri> PutAsync(int? id, T model);

        /// <summary>
        /// Selects records matching the given <paramref name="parameter"/>, limited to the given
        /// page index, and page size.
        /// </summary>
        /// <param name="parameter"><see cref="IQueryParameter{T}"/> instance describing the 
        /// query filter.</param>
        /// <param name="pageNumber">Index of the page of results to return.</param>
        /// <param name="pageSize">Limit to records returned in a single page.</param>
        /// <returns>A task containing the <see cref="IEnumerable{T}"/> of <typeparamref name="T"/> 
        /// matching the given predication and page parameters.</returns>
        Task<(IEnumerable<T>, PaginationData)> SearchAsync(
            IQueryParameter<T> parameter, int pageNumber = 1, int pageSize = 20);
    }

    /// <summary>
    /// Interface representing methods for interacting with a RESTful web api.
    /// </summary>
    /// <typeparam name="T">Is the class interacted with via this service.</typeparam>
    public interface IHttpCollectionService<T> : IHttpService
    {
        /// <summary>
        /// Modifies the collection in the data store by applying the given inserts, updates, and 
        /// deletes.
        /// </summary>
        /// <param name="changes">Enumerable collection of models being inserted, modified, or deleted.</param>
        /// <returns>A <see cref="Uri"/> given the location of the udpated resource.</returns>
        Task<Uri> PatchCollectionAsync(IEnumerable<(T, TrackingState)> changes);

        /// <summary>
        /// Selects records matching the given <paramref name="parameter"/>, limited to the given
        /// page index, and page size.
        /// </summary>
        /// <param name="parameter"><see cref="IQueryParameter{T}"/> instance describing the 
        /// query filter.</param>
        /// <param name="pageNumber">Index of the page of results to return.</param>
        /// <param name="pageSize">Limit to records returned in a single page.</param>
        /// <returns>A task containing the <see cref="IEnumerable{T}"/> of <typeparamref name="T"/> 
        /// matching the given predication and page parameters.</returns>
        Task<(IEnumerable<T>, PaginationData)> SearchAsync(
            IQueryParameter<T> parameter, int pageNumber = 1, int pageSize = 20);
    }

    /// <summary>
    /// Interface representing methods for interacting with a RESTful web api.
    /// </summary>
    /// <typeparam name="T">Is the class interacted with via this service.</typeparam>
    /// <typeparam name="TParentKey">Is the type of the parent key value.</typeparam>
    public interface IHttpCollectionService<T, TParentKey> : IHttpService
    {
        /// <summary>
        /// Modifies the collection in the data store by applying the given inserts, updates, and 
        /// deletes.
        /// </summary>
        /// <param name="changes">Enumerable collection of models being inserted, modified, or deleted.</param>
        /// <param name="parent"><typeparamref name="TParentKey"/> value identifying the parent record.</param>
        /// <returns>A <see cref="Uri"/> given the location of the udpated resource.</returns>
        public Task<Uri> PatchCollectionAsync(IEnumerable<(T, TrackingState)> changes, TParentKey parent);

        /// <summary>
        /// Selects records matching children of the parent record identified by the given id,
        /// filtered to the given <paramref name="parameter"/>, and limited to the given
        /// page index, and page size.
        /// </summary>
        /// <param name="parent">Id of the parent record to the queried collection.</param>
        /// <param name="parameter"><see cref="IQueryParameter{T}"/> instance describing the 
        /// query filter.</param>
        /// <param name="pageNumber">Index of the page of results to return.</param>
        /// <param name="pageSize">Limit to records returned in a single page.</param>
        /// <returns>A task containing the <see cref="IEnumerable{T}"/> of <typeparamref name="T"/> 
        /// matching the given predication and page parameters.</returns>
        Task<(IEnumerable<T>, TParent, PaginationData)> SearchAsync<TParent>(
            TParentKey parent, IQueryParameter<T> parameter, int pageNumber = 1, int pageSize = 20);
    }
}
