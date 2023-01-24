#region Usings

using MediatR;
using Microsoft.AspNetCore.Mvc; 

#endregion

namespace SchoolSystem.BLL.MediatrService.Actions.TimeTable.Queries
{
    /// <summary>
    ///      Get all time tables query class which inherit from IRequest that holds an object result as a response.
    /// </summary>
    public class GetAllTimeTablesQuery : IRequest<ObjectResult>
    {
        /// <summary>
        ///     Instansiate GetAllTimeTablesQuery with no parameters
        /// </summary>
        public GetAllTimeTablesQuery() { }
    }
}