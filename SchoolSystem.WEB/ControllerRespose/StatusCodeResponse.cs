using Microsoft.AspNetCore.Mvc;
using SchoolSystem.BLL.ResponseService;
using System.Net;

namespace SchoolSystem.API.ControllerRespose
{
    /// <summary>
    /// Generic method 
    /// </summary>
    public class StatusCodeResponse<T> : ControllerBase where T : class
    {
        /// <param name="obj">Object that will come from a controller</param>
        /// <returns>Status code that came from service layer</returns>
        public ObjectResult ControllerResponse(Response<T> obj)
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