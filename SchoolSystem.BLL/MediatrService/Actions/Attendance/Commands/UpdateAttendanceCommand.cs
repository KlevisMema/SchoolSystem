using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.DTO.ViewModels.Attendance;

namespace SchoolSystem.BLL.MediatrService.Actions.Attendance.Commands
{
    public class UpdateAttendanceCommand : IRequest<ObjectResult>
    {
        public Guid Id { get; set; }
        public CreateUpdateAttendanceViewModel CreateUpdateAttendanceViewModel { get; set; }

        public UpdateAttendanceCommand
        (
            Guid id,
            CreateUpdateAttendanceViewModel createUpdateAttendanceViewModel
        )
        {
            Id = id;
            CreateUpdateAttendanceViewModel = createUpdateAttendanceViewModel;
        }
    }
}