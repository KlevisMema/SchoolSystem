using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.DTO.ViewModels.Clasroom;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.MediatrService.Actions.Attendance.Queries;
using SchoolSystem.BLL.MediatrService.Actions.Clasroom.Queries;

namespace SchoolSystem.BLL.MediatrService.Handlers.Clasroom.QueriesHandler
{
    public class GetAllClasroomsQueryHandler : IRequestHandler<GetAllClasroomsQuery, ObjectResult>
    {
        private readonly ICrudService<ClasroomViewModel, CreateUpdateClasroomViewModel> _clasroomService;
        private readonly IControllerStatusCodeResponse<ClasroomViewModel, List<ClasroomViewModel>> _statusCodeResponse;

        public GetAllClasroomsQueryHandler
        (
           ICrudService<ClasroomViewModel, CreateUpdateClasroomViewModel> clasroomService,
           IControllerStatusCodeResponse<ClasroomViewModel, List<ClasroomViewModel>> statusCodeResponse
        )
        {
            _clasroomService = clasroomService;
            _statusCodeResponse = statusCodeResponse;
        }

        public async Task<ObjectResult> Handle
        (
            GetAllClasroomsQuery request,
            CancellationToken cancellationToken
        )
        {
            var clasroom = await _clasroomService.GetRecords(cancellationToken);
            return _statusCodeResponse.ControllerResponse(clasroom);
        }
    }
}