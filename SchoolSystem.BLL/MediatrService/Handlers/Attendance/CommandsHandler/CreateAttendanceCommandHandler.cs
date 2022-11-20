using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.DTO.ViewModels.Attendance;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.MediatrService.Actions.Attendance.Commands;

namespace SchoolSystem.BLL.MediatrService.Handlers.Attendance.CommandHandler
{
    public class CreateAttendanceCommandHandler : IRequestHandler<CreateAttendanceCommand, ObjectResult>
    {
        private readonly ICrudService<AttendanceViewModel, CreateUpdateAttendanceViewModel> _attendanceService;
        private readonly IControllerStatusCodeResponse<AttendanceViewModel, List<AttendanceViewModel>> _statusCodeResponse;

        public CreateAttendanceCommandHandler
        (
            ICrudService<AttendanceViewModel, CreateUpdateAttendanceViewModel> attendanceService,
            IControllerStatusCodeResponse<AttendanceViewModel, List<AttendanceViewModel>> statusCodeResponse
        )
        {
            _attendanceService = attendanceService;
            _statusCodeResponse = statusCodeResponse;
        }
        public async Task<ObjectResult> Handle
        (
            CreateAttendanceCommand request,
            CancellationToken cancellationToken
        )
        {
            var updatedAttendance = await _attendanceService.PostRecord(request.CreateUpdateAttendanceViewModel, cancellationToken);
            return _statusCodeResponse.ControllerResponse(updatedAttendance);
        }
    }
}