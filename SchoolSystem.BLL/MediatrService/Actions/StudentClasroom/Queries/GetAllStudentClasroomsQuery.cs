#region Usings

using MediatR;
using Microsoft.AspNetCore.Mvc; 

#endregion

namespace SchoolSystem.BLL.MediatrService.Actions.StudentClasroom.Queries
{
    /// <summary>
    ///      Get all student clasrooms query class which inherit from IRequest that holds an object result as a response.
    /// </summary>
    public class GetAllStudentClasroomsQuery : IRequest<ObjectResult>
    {
        /// <summary>
        ///     Instansiate GetAllStudentClasroomsQuery with no parameters
        /// </summary>
        public GetAllStudentClasroomsQuery() { }
    }
}