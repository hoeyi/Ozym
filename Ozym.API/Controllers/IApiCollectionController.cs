using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ozym.DataTransfer.Common.Query;
using Ozym.ChangeTracking;
using Ozym.DataTransfer.Common.Collections;

namespace Ozym.Api.Controllers
{
    /// <summary>
    /// Represents an API endpoint that facilitates searching and modifying collections of records.
    /// </summary>
    /// <typeparam name="TObject">Record type for the collection.</typeparam>
    /// <typeparam name="TParent">Record type for the parent.</typeparam>
    /// <typeparam name="TParentKey">Type for the primary key member of <typeparamref name="TParent"/>.
    /// </typeparam>
    public interface IApiCollectionController<TObject, TParent, TParentKey>
    {
        /// <summary>
        /// Gets the <typeparamref name="TObject"/> records, limited to the page index and size, 
        /// and a required integer route parameter 'id'.
        /// </summary>
        /// <param name="parentKey">Key value for the parent record.</param>
        /// <param name="pageNumber">The index of page to retrieve.</param>
        /// <param name="pageSize">The record limit for each page.</param>
        /// <returns>An <see cref="ActionResult{TValue}"/> whose value is an enumerable collection 
        /// of <typeparamref name="TObject"/> instances.</returns>
        Task<ActionResult<(IEnumerable<TObject>, TParent)>> IndexAsync(
            TParentKey parentKey, int pageNumber = 1, int pageSize = 20);

        /// <summary>
        /// Retrieves all records from the data store.
        /// </summary>
        /// <returns>An <see cref="ActionResult"/> whose value the collection of 
        /// <typeparamref name="TObject"/> records retrieved from the data store.</returns>
        Task<ActionResult<IEnumerable<TObject>>> GetAllAsync();

        /// <summary>
        /// Posts the search expression in the request body and returns the <typeparamref name="TObject"/> 
        /// records matching the expression, limited to the page index and size.
        /// </summary>
        /// <param name="paramDto"></param>
        /// <param name="pageNumber">The index of page to retrieve.</param>
        /// <param name="pageSize">The record limit for each page.</param>
        /// <returns>An <see cref="ActionResult{TValue}"/> whose value is an enumerable collection 
        /// of <typeparamref name="TObject"/> instances.</returns>
        /// <remarks>This method works around using GET methods with filters defined in the URI.
        /// Use this method to pass search parameters to the endpoint [controller]/search, where the
        /// response content gives the filtered result set.</remarks>
        Task<ActionResult<(IEnumerable<TObject>, TParent)>> PostSearchAsync(
            [FromBody] ParameterDto<TObject> paramDto,
            int pageNumber = 1, int pageSize = 20);

        /// <summary>
        /// Modifies the collection in the data store by applying the given inserts, updates, and 
        /// deletes.
        /// </summary>
        /// <param name="changes"><see cref="IDictionary{TKey, TValue}"/> containing the entries 
        /// to be added, modified, or deleted.</param>
        /// <returns>An <see cref="ActionResult"/>.</returns>
        Task<ActionResult> PostChangesAsync(IDictionary<TrackingState, IEnumerable<TObject>> changes);
    }

    /// <summary>
    /// Represents an API endpoint that facilitates searching and modifying collections of records.
    /// </summary>
    /// <typeparam name="TObject"></typeparam>
    public interface IApiCollectionController<TObject>
    {
        /// <summary>
        /// Gets the <typeparamref name="TObject"/> records, limited to the page index and size.
        /// </summary>
        /// <param name="pageNumber">The index of page to retrieve.</param>
        /// <param name="pageSize">The record limit for each page.</param>
        /// <returns>An <see cref="ActionResult{TValue}"/> whose value is an enumerable collection 
        /// of <typeparamref name="TObject"/> instances.</returns>
        Task<ActionResult<IEnumerable<TObject>>> GetAsync(int pageNumber = 1, int pageSize = 20);

        /// <summary>
        /// Retrieves all records from the data store.
        /// </summary>
        /// <returns>An <see cref="ActionResult"/> whose value the collection of 
        /// <typeparamref name="TObject"/> records retrieved from the data store.</returns>
        Task<ActionResult<IEnumerable<TObject>>> GetAllAsync();

        /// <summary>
        /// Modifies the collection in the data store by applying the given inserts, updates, and 
        /// deletes.
        /// </summary>
        /// <param name="changes"><see cref="IDictionary{TKey, TValue}"/> containing the entries 
        /// to be added, modified, or deleted.</param>
        /// <returns>An <see cref="ActionResult"/>.</returns>
        Task<ActionResult> PostChangesAsync(IDictionary<TrackingState, IEnumerable<TObject>> changes);
    }
}
