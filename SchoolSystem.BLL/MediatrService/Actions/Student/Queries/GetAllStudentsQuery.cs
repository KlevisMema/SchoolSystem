#region Usings

using MediatR;
using Microsoft.AspNetCore.Mvc; 

#endregion

namespace SchoolSystem.BLL.MediatrService.Actions.Student.Queries
{
    /// <summary>
    ///      Get all students query class which inherit from IRequest that holds an object result as a response.
    /// </summary>
    public class GetAllStudentsQuery : IRequest<ObjectResult>
    {
        /// <summary>
        ///     Instansiate GetAllStudentsQuery with no parameters
        /// </summary>
        public GetAllStudentsQuery() { }
    }
}