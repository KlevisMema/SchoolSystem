#region Usings

using MediatR;
using Microsoft.AspNetCore.Mvc; 

#endregion

namespace SchoolSystem.BLL.MediatrService.Actions.StudentIssue.Queries
{
    /// <summary>
    ///      Get student issue query class which inherit from IRequest that holds an object result as a response.
    /// </summary>
    public class GetStudentIssuesByIdQuery : IRequest<ObjectResult>
    {
        /// <summary>
        ///     Id of the student  
        /// </summary>
        public Guid StudentId { get; set; }
        /// <summary>
        ///     Id of the issue 
        /// </summary>
        public Guid IssueId { get; set; }

        /// <summary>
        ///     Instansiate GetStudentIssuesByIdQuery passing the student issue id and issue id as parameters
        /// </summary>
        /// <param name="StudentId"> Id of the student passed to the constructor </param>
        /// <param name="IssueId"> Id of the issue passed to the constructor </param>
        public GetStudentIssuesByIdQuery
        (
            Guid StudentId,
            Guid IssueId
        )
        {
            this.StudentId = StudentId;
            this.IssueId = IssueId;
        }
    }
}