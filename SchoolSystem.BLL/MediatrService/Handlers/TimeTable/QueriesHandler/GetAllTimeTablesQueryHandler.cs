using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.DTO.ViewModels.TimeTable;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.MediatrService.Actions.TimeTable.Queries;

namespace SchoolSystem.BLL.MediatrService.Handlers.TimeTable.QueriesHandler
{
    public class GetAllTimeTablesQueryHandler : IRequestHandler<GetAllTimeTablesQuery, ObjectResult>
    {
        private readonly ICrudService<TimeTableViewModel, CreateUpdateTimeTableViewModel> _timeTableService;
        private readonly IControllerStatusCodeResponse<TimeTableViewModel, List<TimeTableViewModel>> _statusCodeResponse;

        public GetAllTimeTablesQueryHandler
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
            GetAllTimeTablesQuery request,
            CancellationToken cancellationToken
        )
        {
            var timeTables = await _timeTableService.GetRecords(cancellationToken);
            return _statusCodeResponse.ControllerResponse(timeTables);
        }
    }
}