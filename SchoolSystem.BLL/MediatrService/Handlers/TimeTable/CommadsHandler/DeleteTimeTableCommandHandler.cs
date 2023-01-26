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
    ///     Delete time table command handler class which implements IRequestHandler which gets the get delete time table command and object result as response 
    /// </summary>
    public class DeleteTimeTableCommandHandler : IRequestHandler<DeleteTimeTableCommand, ObjectResult>
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
        public DeleteTimeTableCommandHandler
        (
            ICrudService<TimeTableViewModel, CreateUpdateTimeTableViewModel> timeTableService,
            IControllerStatusCodeResponse<TimeTableViewModel, List<TimeTableViewModel>> statusCodeResponse
        )
        {
            _timeTableService = timeTableService;
            _statusCodeResponse = statusCodeResponse;
        }

        /// <summary>
        ///     Handle the delete time table command
        /// </summary>
        /// <param name="request"> Request parameters </param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> A Object result response </returns>
        public async Task<ObjectResult> Handle
        (
            DeleteTimeTableCommand request,
            CancellationToken cancellationToken
        )
        {
            var deleteTimeTable = await _timeTableService.DeleteRecord(request.Id, cancellationToken);
            return _statusCodeResponse.ControllerResponse(deleteTimeTable);
        }
    }
}