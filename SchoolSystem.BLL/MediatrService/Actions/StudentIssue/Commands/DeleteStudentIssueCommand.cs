#region Usings

using MediatR;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace SchoolSystem.BLL.MediatrService.Actions.StudentIssue.Commands
{
    /// <summary>
    ///     Delete student issue commad class which inherit from IRequest that holds an object result as a response.
    /// </summary>
    public class DeleteStudentIssueCommand : IRequest<ObjectResult>
    {
        /// <summary>
        ///     Id of the student issue 
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        ///    Instansiate DeleteStudentIssueCommand passing the student issue Id as parameter 
        /// </summary>
        /// <param name="id"> Id of the student issue passed to the constructor </param>
        public DeleteStudentIssueCommand
        (
            Guid id
        )
        {
            Id = id;
        }
    }
}