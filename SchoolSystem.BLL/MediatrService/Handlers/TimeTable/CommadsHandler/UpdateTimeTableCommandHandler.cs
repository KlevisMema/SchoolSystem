using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.DTO.ViewModels.TimeTable;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.MediatrService.Actions.TimeTable.Commands;

namespace SchoolSystem.BLL.MediatrService.Handlers.TimeTable.CommadsHandler
{
    public class UpdateTimeTableCommandHandler : IRequestHandler<UpdateTimeTableCommand, ObjectResult>
    {
        private readonly ICrudService<TimeTableViewModel, CreateUpdateTimeTableViewModel> _timeTableService;
        private readonly IControllerStatusCodeResponse<TimeTableViewModel, List<TimeTableViewModel>> _statusCodeResponse;

        public UpdateTimeTableCommandHandler
        (
            ICrudService<TimeTableViewModel, CreateUpdateTimeTableViewModel> timeTableService,
            IControllerStatusCodeResponse<TimeTableViewModel, List<TimeTableViewModel>> statusCodeResponse
        )
        {
            _timeTableService = timeTableService;
            _statusCodeResponse = statusCodeResponse;
        }

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