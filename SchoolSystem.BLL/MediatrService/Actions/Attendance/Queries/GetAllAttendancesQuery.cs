using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SchoolSystem.BLL.MediatrService.Actions.Attendance.Queries
{
    public class GetAllAttendancesQuery : IRequest<ObjectResult>
    {
    }
}