#region Usings

using MediatR;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace SchoolSystem.BLL.MediatrService.Actions.Teacher.Queries
{
    /// <summary>
    ///      Get all teachers query class which inherit from IRequest that holds an object result as a response.
    /// </summary>
    public class GetAllTeachersQuery : IRequest<ObjectResult>
    {
        /// <summary>
        ///     Instansiate GetAllTeachersQuery with no parameters
        /// </summary>
        public GetAllTeachersQuery() { }
    }
}