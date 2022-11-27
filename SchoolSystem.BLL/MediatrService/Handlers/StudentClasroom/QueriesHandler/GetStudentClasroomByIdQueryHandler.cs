using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.DTO.ViewModels.StudentClasroom;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.MediatrService.Actions.StudentClasroom.Queries;

namespace SchoolSystem.BLL.MediatrService.Handlers.StudentClasroom.QueriesHandler
{
    public class GetStudentClasroomByIdQueryHandler : IRequestHandler<GetStudentClasroomByIdQuery, ObjectResult>
    {
        private readonly ICrudService<StudentClasroomViewModel, CreateUpdateStudentClasroomViewModel> _studentClasroomService;
        private readonly IControllerStatusCodeResponse<StudentClasroomViewModel, List<StudentClasroomViewModel>> _statusCodeResponse;

        public GetStudentClasroomByIdQueryHandler
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
            GetStudentClasroomByIdQuery request,
            CancellationToken cancellationToken
        )
        {
            var studentClasroom = await _studentClasroomService.GetRecord(request.Id, cancellationToken);
            return _statusCodeResponse.ControllerResponse(studentClasroom);
        }
    }
}