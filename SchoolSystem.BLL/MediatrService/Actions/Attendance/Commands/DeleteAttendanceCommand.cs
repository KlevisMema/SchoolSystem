using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SchoolSystem.BLL.MediatrService.Actions.Attendance.Commands
{
    public class DeleteAttendanceCommand : IRequest<ObjectResult>
    {
        public Guid Id { get; set; }

        public DeleteAttendanceCommand
        (
            Guid id
        )
        {
            Id = id;
        }
    }
}