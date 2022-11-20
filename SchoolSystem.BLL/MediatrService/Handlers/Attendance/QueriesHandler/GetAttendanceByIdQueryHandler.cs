using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.DTO.ViewModels.Attendance;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.MediatrService.Actions.Attendance.Queries;

namespace SchoolSystem.BLL.MediatrService.Handlers.Attendance.QueriesHandler
{
    public class GetAttendanceByIdQueryHandler : IRequestHandler<GetAttedanceByIdQuery, ObjectResult>
    {
        private readonly ICrudService<AttendanceViewModel, CreateUpdateAttendanceViewModel> _attendanceService;
        private readonly IControllerStatusCodeResponse<AttendanceViewModel, List<AttendanceViewModel>> _statusCodeResponse;

        public GetAttendanceByIdQueryHandler
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
            GetAttedanceByIdQuery request,
            CancellationToken cancellationToken
        )
        {
            var attendance = await _attendanceService.GetRecord(request.Id, cancellationToken);
            return _statusCodeResponse.ControllerResponse(attendance);
        }
    }
}