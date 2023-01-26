#region Usings

using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.DTO.ViewModels.Attendance;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.MediatrService.Actions.Attendance.Commands;

#endregion

namespace SchoolSystem.BLL.MediatrService.Handlers.Attendance.CommandHandler
{
    /// <summary>
    ///     Update attendance command handler class which implements IRequestHandler which gets the get update attendance command and object result as response 
    /// </summary>
    public class UpdateAttendanceCommandHandler : IRequestHandler<UpdateAttendanceCommand, ObjectResult>
    {
        /// <summary>
        ///     ICrudService interface 
        /// </summary>
        private readonly ICrudService<AttendanceViewModel, CreateUpdateAttendanceViewModel> _attendanceService;
        /// <summary>
        ///     IControllerStatusCodeResponse interface
        /// </summary>
        private readonly IControllerStatusCodeResponse<AttendanceViewModel, List<AttendanceViewModel>> _statusCodeResponse;

        /// <summary>
        ///     Services injection
        /// </summary>
        /// <param name="attendanceService"> Attendance service  </param>
        /// <param name="statusCodeResponse"> Status code service </param>
        public UpdateAttendanceCommandHandler
        (
            ICrudService<AttendanceViewModel, CreateUpdateAttendanceViewModel> attendanceService,
            IControllerStatusCodeResponse<AttendanceViewModel, List<AttendanceViewModel>> statusCodeResponse
        )
        {
            _attendanceService = attendanceService;
            _statusCodeResponse = statusCodeResponse;
        }

        /// <summary>
        ///     Handle the update attendance command
        /// </summary>
        /// <param name="request"> Request parameters </param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> A Object result response </returns>
        public async Task<ObjectResult> Handle
        (
            UpdateAttendanceCommand request,
            CancellationToken cancellationToken
        )
        {
            var updatedAttendance = await _attendanceService.PutRecord(request.Id, request.CreateUpdateAttendanceViewModel, cancellationToken);
            return _statusCodeResponse.ControllerResponse(updatedAttendance);
        }
    }
}