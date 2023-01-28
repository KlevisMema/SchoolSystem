#region Usings

using MediatR;
using Microsoft.AspNetCore.Mvc; 

#endregion

namespace SchoolSystem.BLL.MediatrService.Queries.Subject.Queries
{
    /// <summary>
    ///      Get all subjects query class which inherit from IRequest that holds an object result as a response.
    /// </summary>
    public class GetAllSubjectsQuery : IRequest<ObjectResult>
    {
        /// <summary>
        ///     Instansiate GetAllSubjectsQuery with no parameters
        /// </summary>
        public GetAllSubjectsQuery() { }
    }
}