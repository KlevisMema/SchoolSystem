using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using SchoolSystem.BLL.ServiceInterfaces;

namespace SchoolSystem.BLL.ResponseService
{
    /// <summary>
    /// Generic method 
    /// </summary>
    public class ControllerStatusCodeResponse<T, ListT> : ControllerBase, IControllerStatusCodeResponse<T, ListT>
    where T : class
    where ListT : List<T>
    {
        /// <param name="obj">Object that will come from a controller</param>
        /// <returns>Status code that came from service layer</returns>
        public ObjectResult ControllerResponse(Response<T> obj)
        {

            return obj.StatusCode switch
            {
                HttpStatusCode.NotFound => NotFound(obj.Message),
                HttpStatusCode.BadRequest => BadRequest(obj.Message),
                HttpStatusCode.OK => Ok(obj.Value is null ? obj.Message : obj.Value),
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
