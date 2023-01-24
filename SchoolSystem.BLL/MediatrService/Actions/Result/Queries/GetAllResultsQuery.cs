#region Usings

using MediatR;
using Microsoft.AspNetCore.Mvc; 

#endregion

namespace SchoolSystem.BLL.MediatrService.Actions.Result.Queries
{
    /// <summary>
    ///      Get all results query class which inherit from IRequest that holds an object result as a response.
    /// </summary>
    public class GetAllResultsQuery : IRequest<ObjectResult>
    {
        /// <summary>
        ///     Instansiate GetAllResultsQuery with no parameters
        /// </summary>
        public GetAllResultsQuery() { }
    }
}