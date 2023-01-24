#region Usings

using MediatR;
using Microsoft.AspNetCore.Mvc; 

#endregion

namespace SchoolSystem.BLL.MediatrService.Actions.StudentIssue.Queries
{
    /// <summary>
    ///      Get all student issues query class which inherit from IRequest that holds an object result as a response.
    /// </summary>
    public class GetAllStudentIssuesByIdQuery : IRequest<ObjectResult>
    {
        /// <summary>
        ///     Instansiate GetAllStudentIssuesByIdQuery with no parameters
        /// </summary>
        public GetAllStudentIssuesByIdQuery() { }
    }
}