using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.DTO.ViewModels.TimeTable;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.MediatrService.Actions.TimeTable.Queries;

namespace SchoolSystem.BLL.MediatrService.Handlers.TimeTable.QueriesHandler
{
    public class GetTimeTableByIdQueryHandler : IRequestHandler<GetTimeTableByIdQuery, ObjectResult>
    {
        private readonly ICrudService<TimeTableViewModel, CreateUpdateTimeTableViewModel> _timeTableService;
        private readonly IControllerStatusCodeResponse<TimeTableViewModel, List<TimeTableViewModel>> _statusCodeResponse;

        public GetTimeTableByIdQueryHandler
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
            GetTimeTableByIdQuery request, 
            CancellationToken cancellationToken
        )
        {
            var timeTable = await _timeTableService.GetRecord(request.Id, cancellationToken);
            return _statusCodeResponse.ControllerResponse(timeTable);
        }
    }
}