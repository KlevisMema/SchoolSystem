using Microsoft.AspNetCore.Mvc;
using SchoolSystem.BLL.ResponseService;
using System.Net;

namespace SchoolSystem.API.ControllerRespose
{
    /// <summary>
    /// Generic method 
    /// </summary>
    public class StatusCodeResponse<T, ListT> : ControllerBase where T : class
                                                               where ListT : List<T>
    {
        /// <param name="obj">Object that will come from a controller</param>
        /// <returns>Status code that came from service layer</returns>
        public ObjectResult ControllerResponse(Response<T> obj)
        {

            return obj.StatusCode switch
            {
                HttpStatusCode.OK => Ok(obj.Value is null ?  obj.Message : obj.Value ),
                HttpStatusCode.NotFound => NotFound(obj.Message),
                HttpStatusCode.BadRequest => BadRequest(obj.Message),
                _ => StatusCode(StatusCodes.Status500InternalServerError, obj.Message),
            };
        }

       /// <param name="obj">List of object that will come from a controller</param>
       /// <returns>The appropriate status code</returns>
        public ObjectResult ControllerResponse(Response<ListT> obj)
        {
            return obj.StatusCode switch
            {
                HttpStatusCode.OK => Ok(obj.Value),
                HttpStatusCode.NotFound => NotFound(obj.Message),
                HttpStatusCode.BadRequest => BadRequest(obj.Message),
                _ => StatusCode(StatusCodes.Status500InternalServerError, obj.Message),
            };
        }
    }
}