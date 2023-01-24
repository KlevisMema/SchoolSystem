#region Usings

using MediatR;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace SchoolSystem.BLL.MediatrService.Actions.Issues.Commands
{
    /// <summary>
    ///     Delete issue commad class which inherit from IRequest that holds an object result as a response.
    /// </summary>
    public class DeleteIssueCommand : IRequest<ObjectResult>
    {

        /// <summary>
        ///     Id of the issue 
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        ///    Instansiate DeleteIssueCommand passing the issue Id as parameter 
        /// </summary>
        /// <param name="id"> Id of the issue passed to the constructor </param>
        public DeleteIssueCommand
        (
            Guid id
        )
        {
            Id = id;
        }
    }
}