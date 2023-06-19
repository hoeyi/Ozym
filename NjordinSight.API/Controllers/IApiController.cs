using Microsoft.AspNetCore.Mvc;
using NjordinSight.DataTransfer.Common.Query;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NjordinSight.Api.Controllers
{
    /// <summary>
    /// Represents a RESTful API controller for <typeparamref name="TObject"/> objects.
    /// </summary>
    /// <typeparam name="TObject"></typeparam>
    public interface IApiController<TObject>
    {
    #pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        Task<IActionResult> DeleteAsync(int id);

        Task<ActionResult<TObject>> GetAsync(int id);
        
        Task<ActionResult<IEnumerable<TObject>>> GetAsync(
            [FromBody] ParameterDto<TObject> queryParameter, 
            int pageNumber = 1, 
            int pageSize = 20);

        Task<ActionResult<TObject>> InitDefaultAsync();

        Task<ActionResult<TObject>> PostAsync(TObject model);

        
        Task<ActionResult<TObject>> PutAsync(int id, TObject model);
    #pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    }
}