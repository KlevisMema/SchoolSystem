using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.DTO.ViewModels.StudentClasroom;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.MediatrService.Actions.StudentClasroom.Queries;


namespace SchoolSystem.BLL.MediatrService.Handlers.StudentClasroom.QueriesHandler
{
    public class GetAllStudentClasroomsQueryHandler : IRequestHandler<GetAllStudentClasroomsQuery, ObjectResult>
    {
        private readonly ICrudService<StudentClasroomViewModel, CreateUpdateStudentClasroomViewModel> _studentClasroomService;
        private readonly IControllerStatusCodeResponse<StudentClasroomViewModel, List<StudentClasroomViewModel>> _statusCodeResponse;

        public GetAllStudentClasroomsQueryHandler
        (
            ICrudService<StudentClasroomViewModel, CreateUpdateStudentClasroomViewModel> studentClasroomService,
            IControllerStatusCodeResponse<StudentClasroomViewModel, List<StudentClasroomViewModel>> statusCodeResponse
        )
        {
            _statusCodeResponse = statusCodeResponse;
            _studentClasroomService = studentClasroomService;
        }

        public async Task<ObjectResult> Handle
        (
            GetAllStudentClasroomsQuery request,
            CancellationToken cancellationToken
        )
        {
            var studentClasrooms = await _studentClasroomService.GetRecords(cancellationToken);
            return _statusCodeResponse.ControllerResponse(studentClasrooms);
        }
    }
}