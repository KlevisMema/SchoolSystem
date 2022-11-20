using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.DTO.ViewModels.Attendance;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.MediatrService.Actions.Attendance.Commands;

namespace SchoolSystem.BLL.MediatrService.Handlers.Attendance.CommandHandler
{
    public class DeleteAttendanceCommandHandler : IRequestHandler<DeleteAttendanceCommand, ObjectResult>
    {
        private readonly ICrudService<AttendanceViewModel, CreateUpdateAttendanceViewModel> _attendanceService;
        private readonly IControllerStatusCodeResponse<AttendanceViewModel, List<AttendanceViewModel>> _statusCodeResponse;

        public DeleteAttendanceCommandHandler
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
            DeleteAttendanceCommand request,
            CancellationToken cancellationToken
        )
        {
            var deleteAttendance = await _attendanceService.DeleteRecord(request.Id, cancellationToken);
            return _statusCodeResponse.ControllerResponse(deleteAttendance);
        }
    }
}