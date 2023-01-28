#region Usings

using MediatR;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace SchoolSystem.BLL.MediatrService.Actions.Issues.Queries
{
    /// <summary>
    ///      Get issue query class which inherit from IRequest that holds an object result as a response.
    /// </summary>
    public class GetIssueByIdQuery : IRequest<ObjectResult>
    {
        /// <summary>
        ///     Id of the issue 
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        ///     Instansiate GetIssueByIdQuery passing the issue id as parameter
        /// </summary>
        /// <param name="id"> Id of the issue passed to the constructor </param>
        public GetIssueByIdQuery
        (
            Guid id
        )
        {
            Id = id;
        }
    }
}