using AutoMapper.Configuration.Conventions;
using Microsoft.AspNetCore.Mvc;
using Ozym.DataTransfer.Common.Query;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ozym.Api.Controllers
{
    /// <summary>
    /// Represents a RESTful API controller for <typeparamref name="TObject"/> objects.
    /// </summary>
    /// <typeparam name="TObject"></typeparam>
    public interface IApiController<TObject>
    {
        /// <summary>
        /// Submits a deletion request for the resource identified by the given id.
        /// </summary>
        /// <param name="id">The unique identifier for the resource to delete.</param>
        /// <returns>An <see cref="IActionResult"/> representing the response. 204 No Content is 
        /// returned if the requested completed successfully.</returns>
        Task<IActionResult> DeleteAsync(int id);

        /// <summary>
        /// Retrieves the resource identified by the given id.
        /// </summary>
        /// <param name="id">The unique identifier for the resource to retrieve.</param>
        /// <returns></returns>
        Task<ActionResult<TObject>> GetAsync(int id);

        /// <summary>
        /// Retrieves all records from the data store.
        /// </summary>
        /// <returns>An <see cref="ActionResult"/> whose value the collection of 
        /// <typeparamref name="TObject"/> records retrieved from the data store.</returns>
        Task<ActionResult<IEnumerable<TObject>>> GetAllAsync();

        /// <summary>
        /// Retrieves the collection matching the given page parameters.
        /// </summary>
        /// <param name="pageNumber">The index of page to retrieve.</param>
        /// <param name="pageSize">The record limit for each page.</param>
        /// <returns>An <see cref="ActionResult{TValue}"/> whose value is an enumerable collection 
        /// of <typeparamref name="TObject"/> instances.</returns>
        Task<ActionResult<IEnumerable<TObject>>> GetAsync(int pageNumber = 1, int pageSize = 20);

        /// <summary>
        /// Initializes a default instance for use in a post action.
        /// </summary>
        /// <returns>An <see cref="ActionResult{TValue}"/> whose value is the initialized 
        /// <typeparamref name="TObject"/>.</returns>
        Task<ActionResult<TObject>> InitDefaultAsync();

        /// <summary>
        /// Submits a post request to insert the given <typeparamref name="TObject"/> to the data 
        /// store.
        /// </summary>
        /// <param name="model">The instance to create.</param>
        /// <returns>The updated <typeparamref name="TObject"/> instance.</returns>
        Task<ActionResult<TObject>> PostAsync(TObject model);

        /// <summary>
        /// Submits a put request to replace the resource matching the given id with the model
        /// instance given.
        /// </summary>
        /// <param name="id">The unique identifier for the resource to replace.</param>
        /// <param name="model">The instance to replace the existing resource.</param>
        /// <returns></returns>
        /// <remarks>Only PUT methods are supported for updating records. PATCH method is 
        /// planned.</remarks>
        Task<ActionResult<TObject>> PutAsync(int id, TObject model);

        /// <summary>
        /// Posts the search expression in the request body and returns the <typeparamref name="TObject"/> 
        /// records matching the expression, limited to the page index and size
        /// </summary>
        /// <param name="queryParameter">The <see cref="ParameterDto{T}"/> describing the operation 
        /// to filter results.</param>
        /// <param name="pageNumber">The index of page to retrieve.</param>
        /// <param name="pageSize">The record limit for each page.</param>
        /// <returns>An <see cref="ActionResult{TValue}"/> whose value is an enumerable collection 
        /// of <typeparamref name="TObject"/> instances.</returns>
        /// <remarks>This method works around using GET methods with filters defined in the URI.
        /// Use this method to pass search parameters to the endpoint [controller]/search, where the
        /// response content gives the filtered result set.</remarks>
        Task<ActionResult<IEnumerable<TObject>>> PostSearchAsync(
            [FromBody] ParameterDto<TObject> queryParameter, int pageNumber = 1, int pageSize = 20);
    }
}