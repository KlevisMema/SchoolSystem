#region Usings

using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.DTO.ViewModels.Attendance;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.MediatrService.Actions.Attendance.Queries;

#endregion

namespace SchoolSystem.BLL.MediatrService.Handlers.Attendance.QueriesHandler
{
    /// <summary>
    ///     Get attendances query handler class which implements IRequestHandler which gets the get attendances query and object result as response 
    /// </summary>
    public class GetAllAttendancesQueryHandler : IRequestHandler<GetAllAttendancesQuery, ObjectResult>
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
        public GetAllAttendancesQueryHandler
        (
            ICrudService<AttendanceViewModel, CreateUpdateAttendanceViewModel> attendanceService,
            IControllerStatusCodeResponse<AttendanceViewModel, List<AttendanceViewModel>> statusCodeResponse
        )
        {
            _attendanceService = attendanceService;
            _statusCodeResponse = statusCodeResponse;
        }

        /// <summary>
        ///     Handle the get attendances query
        /// </summary>
        /// <param name="request"> Request parameters </param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> A Object result response </returns>
        public async Task<ObjectResult> Handle
        (
            GetAllAttendancesQuery request,
            CancellationToken cancellationToken
        )
        {
            var attendances = await _attendanceService.GetRecords(cancellationToken);
            return _statusCodeResponse.ControllerResponse(attendances);
        }
    }
}