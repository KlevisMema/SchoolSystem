#region Usings

using MediatR;
using SchoolSystem.BLL.ResponseService;

#endregion

namespace SchoolSystem.BLL.MediatrService.Actions.Issues.Queries
{
    /// <summary>
    ///     Get issue query class which inherit from IRequest that holds an CustomMesageResponse as a response.
    /// </summary>
    public class DoesIssueExistsQuery : IRequest<CustomMesageResponse>
    {
        /// <summary>
        ///     Id of the issue 
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        ///     Instansiate DoesIssueExistsQuery passing the issue id as parameter
        /// </summary>
        /// <param name="id"> Id of the issue passed to the constructor </param>
        public DoesIssueExistsQuery
        (
            Guid id
        )
        {
            Id = id;
        }
    }
}