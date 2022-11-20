using Microsoft.AspNetCore.Mvc;
using SchoolSystem.BLL.ResponseService;

namespace SchoolSystem.BLL.ServiceInterfaces
{
    public interface IControllerStatusCodeResponse<T, ListT>
        where T : class
        where ListT : List<T>
    {
        ObjectResult ControllerResponse(Response<ListT> obj);
        ObjectResult ControllerResponse(Response<T> obj);
    }
}