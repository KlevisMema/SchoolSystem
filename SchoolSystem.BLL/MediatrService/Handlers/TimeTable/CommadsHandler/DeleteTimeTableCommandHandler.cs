using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.DTO.ViewModels.TimeTable;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.MediatrService.Actions.TimeTable.Commands;

namespace SchoolSystem.BLL.MediatrService.Handlers.TimeTable.CommadsHandler
{
    public class DeleteTimeTableCommandHandler : IRequestHandler<DeleteTimeTableCommand, ObjectResult>
    {
        private readonly ICrudService<TimeTableViewModel, CreateUpdateTimeTableViewModel> _timeTableService;
        private readonly IControllerStatusCodeResponse<TimeTableViewModel, List<TimeTableViewModel>> _statusCodeResponse;

        public DeleteTimeTableCommandHandler
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
            DeleteTimeTableCommand request,
            CancellationToken cancellationToken
        )
        {
            var deleteTimeTable = await _timeTableService.DeleteRecord(request.Id, cancellationToken);
            return _statusCodeResponse.ControllerResponse(deleteTimeTable);
        }
    }
}