#region Usings

using MediatR;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace SchoolSystem.BLL.MediatrService.Actions.Attendance.Queries
{
    /// <summary>
    ///      Get all attendances query class which inherit from IRequest that holds an object result as a response.
    /// </summary>
    public class GetAllAttendancesQuery : IRequest<ObjectResult>
    {
        /// <summary>
        ///     Instansiate GetAllAttendancesQuery with no parameters
        /// </summary>
        public GetAllAttendancesQuery() { }
    }
}