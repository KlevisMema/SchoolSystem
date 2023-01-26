#region Usings

using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.DTO.ViewModels.TimeTable;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.MediatrService.Actions.TimeTable.Commands;

#endregion

namespace SchoolSystem.BLL.MediatrService.Handlers.TimeTable.CommadsHandler
{
    /// <summary>
    ///     Update time table command handler class which implements IRequestHandler which gets the get update time table command and object result as response 
    /// </summary>
    public class UpdateTimeTableCommandHandler : IRequestHandler<UpdateTimeTableCommand, ObjectResult>
    {
        /// <summary>
        ///     ICrudService interface 
        /// </summary>
        private readonly ICrudService<TimeTableViewModel, CreateUpdateTimeTableViewModel> _timeTableService;
        /// <summary>
        ///     IControllerStatusCodeResponse interface
        /// </summary>
        private readonly IControllerStatusCodeResponse<TimeTableViewModel, List<TimeTableViewModel>> _statusCodeResponse;

        /// <summary>
        ///     Services injection
        /// </summary>
        /// <param name="timeTableService"> Time table service  </param>
        /// <param name="statusCodeResponse"> Status code service </param>
        public UpdateTimeTableCommandHandler
        (
            ICrudService<TimeTableViewModel, CreateUpdateTimeTableViewModel> timeTableService,
            IControllerStatusCodeResponse<TimeTableViewModel, List<TimeTableViewModel>> statusCodeResponse
        )
        {
            _timeTableService = timeTableService;
            _statusCodeResponse = statusCodeResponse;
        }

        /// <summary>
        ///     Handle the update time table command
        /// </summary>
        /// <param name="request"> Request parameters </param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> A Object result response </returns>
        public async Task<ObjectResult> Handle
        (
            UpdateTimeTableCommand request,
            CancellationToken cancellationToken
        )
        {
            var updatedTimeTable = await _timeTableService.PutRecord(request.Id, request._updateTimeTable, cancellationToken);
            return _statusCodeResponse.ControllerResponse(updatedTimeTable);
        }
    }
}