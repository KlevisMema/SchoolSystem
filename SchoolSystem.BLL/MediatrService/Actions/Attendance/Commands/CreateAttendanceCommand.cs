using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.DTO.ViewModels.Attendance;

namespace SchoolSystem.BLL.MediatrService.Actions.Attendance.Commands
{
    public class CreateAttendanceCommand : IRequest<ObjectResult>
    {
        public CreateUpdateAttendanceViewModel CreateUpdateAttendanceViewModel { get; set; }

        public CreateAttendanceCommand
        (
            CreateUpdateAttendanceViewModel createUpdateAttendanceViewModel
        )
        {
            CreateUpdateAttendanceViewModel = createUpdateAttendanceViewModel;
        }
    }
}