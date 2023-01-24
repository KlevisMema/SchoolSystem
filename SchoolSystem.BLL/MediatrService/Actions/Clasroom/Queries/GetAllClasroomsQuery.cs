#region Usings

using MediatR;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace SchoolSystem.BLL.MediatrService.Actions.Clasroom.Queries
{
    /// <summary>
    ///      Get all clasrooms query class which inherit from IRequest that holds an object result as a response.
    /// </summary>
    public class GetAllClasroomsQuery : IRequest<ObjectResult>
    {
        /// <summary>
        ///     Instansiate GetAllClasroomsQuery with no parameters
        /// </summary>
        public GetAllClasroomsQuery() { }
    }
}