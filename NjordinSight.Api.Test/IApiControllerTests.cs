using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NjordinSight.Api.Controllers;

namespace NjordinSight.Api.Test
{
    /// <summary>
    /// Represents unit-tests for adquate coverage of a RESTful API controller implementing 
    /// <see cref="IApiController{TObject}"/>.
    /// </summary>
    /// <typeparam name="TObject"></typeparam>
    public interface IApiControllerTests<TObject>
    {
        /// <summary>
        /// Tests the DELETE method with a valid id and expects an ActionResult with status 
        /// [204 - No Content].
        /// </summary>
        Task Delete_With_Valid_Id_Return_NoContent();

        /// <summary>
        /// Tests the DELETE method with an invalid id and expects an ActionResult with status 
        /// [404 - Not Found].
        /// </summary>
        Task Delete_With_Invalid_Id_Return_NotFound();

        /// <summary>
        /// Tests the DELETE method with an invalid id and expects an ActionResult with status 
        /// [409 - Conflict].
        /// </summary>
        Task Delete_Failed_For_Client_Error_Return_Conflict();

        /// <summary>
        /// Tests the DELETE method with an invalid id and expects an ActionResult with status 
        /// [500 - Internal Error].
        /// </summary>
        Task Delete_Failed_For_Server_Error_Return_InternalError();

        /// <summary>
        /// Tests the GET method with an invalid id and expects an ActionResult with status 
        /// [404 - NotFound].
        /// </summary>
        Task Get_With_Invalid_Id_Return_NotFound();

        /// <summary>
        /// Tests the GET method with a valid id and expects an ActionResult containing an
        /// instance of <typeparamref name="TObject"/> as a result.
        /// </summary>
        Task Get_With_Valid_Id_Return_ActionResult();

        /// <summary>
        /// Tests the GET method with valid query parameters, page number, and page size, and 
        /// expects an ActionResult with status [200 - OK] containing an IEnumerable of 
        /// <typeparamref name="TObject"/> as a result.
        /// </summary>
        Task Get_With_Valid_QueryParams_In_Body_Return_ActionResult();

        /// <summary>
        /// Tests the InitDefault method and expects an ActionResult containing the initialized 
        /// instance of <typeparamref name="TObject"/> as a result.
        /// </summary>
        Task InitDefault_Return_ActionResult();

        /// <summary>
        /// Tests the POST method with an invalid model and expects an ActionResult with status 
        /// [400 - Bad Request].
        /// </summary>
        Task Post_With_Invalid_Model_Return_BadRequest();

        /// <summary>
        /// Tests the POST method with a valid model and expects an ActionResult with status 
        /// [201 - Created] containing the created <typeparamref name="TObject"/> as a result.
        /// </summary>
        Task Post_With_Valid_Model_Return_ActionResult();

        /// <summary>
        /// Tests the POST method to the [controller]/search endpoint with invalid query parameters
        /// and expects an ActionResult with status [400 - Bad Request] as a result.
        /// </summary>
        Task PostSearch_With_Invalid_QueryParams_Return_BadRequest();

        /// <summary>
        /// Tests the POST method to the [controller]/search endpoint with valid parameter object 
        /// as the body, page number/size as parameters,  and expects an ActionResult with status 
        /// [200 - OK] containing an <see cref="IEnumerable{T}"/> of <typeparamref name="TObject"/> as 
        /// a result.
        /// </summary>
        Task PostSearch_With_Valid_QueryParams_Return_ActionResult();

        /// <summary>
        /// Tests the PUT method with encountering a concurrency exception where the model no longer 
        /// exists and returns an ActionResult with status [404 - Not Found].
        /// </summary>
        Task Put_Encounters_Concurrency_Error_ModelNoLongerExists_Returns_NotFound();

        /// <summary>
        /// Tests the PUT method with an invalid id and expects an ActionResult with status 
        /// [404 - Not Found].
        /// </summary>
        Task Put_With_Invalid_Id_Return_NotFound();

        /// <summary>
        /// Tests the PUT method with an invalid model and expects an ActionResult with status 
        /// [400 - Bad Request] as a result.
        /// </summary>
        Task Put_With_Mismatched_Id_Return_BadRequest();

        /// <summary>
        /// Tests the PUT method with a valid id and model, and expects an ActionResult with status 
        /// [200 - OK] containing the updated <typeparamref name="TObject"/> as a result.
        /// </summary>
        Task Put_With_Valid_Id_And_Model_Return_ActionResult();
    }
}
