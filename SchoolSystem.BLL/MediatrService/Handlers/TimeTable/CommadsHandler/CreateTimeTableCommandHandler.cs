using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.DTO.ViewModels.TimeTable;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.MediatrService.Actions.TimeTable.Commands;

namespace SchoolSystem.BLL.MediatrService.Handlers.TimeTable.CommadsHandler
{
    public class CreateTimeTableCommandHandler : IRequestHandler<CreateTimeTableCommand, ObjectResult>
    {
        private readonly ICrudService<TimeTableViewModel, CreateUpdateTimeTableViewModel> _timeTableService;
        private readonly IControllerStatusCodeResponse<TimeTableViewModel, List<TimeTableViewModel>> _statusCodeResponse;

        public CreateTimeTableCommandHandler
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
            CreateTimeTableCommand request,
            CancellationToken cancellationToken
        )
        {
            var createTimeTable = await _timeTableService.PostRecord(request._createTimeTable, cancellationToken);
            return _statusCodeResponse.ControllerResponse(createTimeTable);
        }
    }
}