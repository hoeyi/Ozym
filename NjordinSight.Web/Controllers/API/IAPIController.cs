using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NjordinSight.Web.Controllers.API
{
    /// <summary>
    /// Defines required members for an API controller.
    /// </summary>
    /// <typeparam name="T">The record type worked by the controller.</typeparam>
    interface IAPIController<T>
    {
        /// <summary>
        /// Creates the given <typeparamref name="T"/> record.
        /// </summary>
        /// <param name="value">A JSON-serialized <typeparamref name="T"/>.</param>
        /// <returns>An <see cref="IActionResult"/>.</returns>
        Task<IActionResult> PostAsync([FromBody] string value);

        /// <summary>
        /// Gets the <typeparamref name="T"/> record matching <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The primary key or unique identifier of the record.</param>
        /// <returns>An <see cref="ActionResult{TValue}"/> containing the matched 
        /// <typeparamref name="T"/> model.</returns>
        Task<ActionResult<T>> GetAsync(int id);

        /// <summary>
        /// Updates the given <typeparamref name="T"/> record.
        /// </summary>
        /// <param name="id">The primary key or unique identifier of the record.</param>
        /// <param name="value">A JSON-serialized <typeparamref name="T"/>.</param>
        /// <returns>An <see cref="IActionResult"/>.</returns>
        Task<IActionResult> UpdateAsync(int id, [FromBody] string value);

        /// <summary>
        /// Deletes the given <typeparamref name="T"/> record.
        /// </summary>
        /// <param name="id">The primary key or unique identifier of the record.</param>
        /// <returns>An <see cref="IActionResult"/>.</returns>
        Task<IActionResult> DeleteAsync(int id);

        /// <summary>
        /// Returns an enumerable collection of <typeparamref name="T"/> records.
        /// </summary>
        /// <returns>An <see cref="ActionResult{TValue}"/> containing the collection.</returns>
        Task<ActionResult<IEnumerable<T>>> IndexAsync();
    }

    /// <summary>
    /// Represents an example implement of a basic web API.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    class ExampleApiController : ControllerBase, IAPIController<string>
    {
        // DELETE api/ExampleApi/5
        [HttpDelete("{id:int}")]
        public Task<IActionResult> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
        
        // GET api/ExampleApi/5
        [HttpGet("{id:int}")]
        public Task<ActionResult<string>> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        // GET: api/ExampleApi
        [HttpGet]
        public Task<ActionResult<IEnumerable<string>>> IndexAsync()
        {
            throw new NotImplementedException();
        }

        // POST api/<ValuesController>
        [HttpPost]
        public Task<IActionResult> PostAsync([FromBody] string value)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id:int}")]
        public Task<IActionResult> UpdateAsync(int id, [FromBody] string value)
        {
            throw new NotImplementedException();
        }
    }
}
