#region

using MediatR;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace SchoolSystem.BLL.MediatrService.Actions.Issues.Queries
{
    /// <summary>
    ///      Get all issues query class which inherit from IRequest that holds an object result as a response.
    /// </summary>
    public class GetAllIssuesQuery : IRequest<ObjectResult>
    {
        /// <summary>
        ///     Instansiate GetAllIssuesQuery with no parameters
        /// </summary>
        public GetAllIssuesQuery() { }
    }
}