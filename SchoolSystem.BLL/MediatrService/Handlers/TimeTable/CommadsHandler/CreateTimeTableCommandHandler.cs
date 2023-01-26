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
    ///     Create time table command handler class which implements IRequestHandler which gets the get create time table command and object result as response 
    /// </summary>
    public class CreateTimeTableCommandHandler : IRequestHandler<CreateTimeTableCommand, ObjectResult>
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
        public CreateTimeTableCommandHandler
        (
            ICrudService<TimeTableViewModel, CreateUpdateTimeTableViewModel> timeTableService,
            IControllerStatusCodeResponse<TimeTableViewModel, List<TimeTableViewModel>> statusCodeResponse
        )
        {
            _timeTableService = timeTableService;
            _statusCodeResponse = statusCodeResponse;
        }

        /// <summary>
        ///     Handle the create time table command
        /// </summary>
        /// <param name="request"> Request parameters </param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> A Object result response </returns>
        public async Task<ObjectResult> Handle
        (
            CreateTimeTableCommand request,
            CancellationToken cancellationToken
        )
        {
            var createTimeTable = await _timeTableService.PostRecord(request._createTimeTable, cancellationToken);
            return _statusCodeResponse.ControllerResponse(createTimeTable);
        }
    }
}