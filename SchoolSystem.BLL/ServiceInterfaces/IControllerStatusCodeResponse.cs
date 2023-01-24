using Microsoft.AspNetCore.Mvc;
using SchoolSystem.BLL.ResponseService;

namespace SchoolSystem.BLL.ServiceInterfaces
{
    /// <summary>
    ///     Generic interface that has methods to return a Object result 
    /// </summary>
    /// <typeparam name="T"> A single object  if the return type consist on a single of object  </typeparam>
    /// <typeparam name="ListT"> A list of object if the return type consist on a list of object </typeparam>
    public interface IControllerStatusCodeResponse<T, ListT>
        where T : class
        where ListT : List<T>
    {
        /// <summary>
        ///     Returns a type of resposne of a list of data 
        /// </summary>
        /// <param name="obj"> List of object </param>
        /// <returns> A ObjectResult response </returns>
        ObjectResult ControllerResponse(Response<ListT> obj);
        /// <summary>
        ///     Returns a type of resposne of a single of data 
        /// </summary>
        /// <param name="obj"> Object data </param>
        /// <returns> A ObjectResult response </returns>
        ObjectResult ControllerResponse(Response<T> obj);
    }
}