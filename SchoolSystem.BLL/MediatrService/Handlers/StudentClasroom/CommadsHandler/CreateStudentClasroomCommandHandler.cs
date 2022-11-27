using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.DTO.ViewModels.StudentClasroom;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.MediatrService.Actions.StudentClasroom.Commands;

namespace SchoolSystem.BLL.MediatrService.Handlers.StudentClasroom.CommadsHandler
{
    public class CreateStudentClasroomCommandHandler : IRequestHandler<CreateStudentClasroomCommand, ObjectResult>
    {
        private readonly ICrudService<StudentClasroomViewModel, CreateUpdateStudentClasroomViewModel> _studentClasroomService;
        private readonly IControllerStatusCodeResponse<StudentClasroomViewModel, List<StudentClasroomViewModel>> _statusCodeResponse;

        public CreateStudentClasroomCommandHandler
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
            CreateStudentClasroomCommand request,
            CancellationToken cancellationToken
        )
        {
            var createStudentClasroom = await _studentClasroomService.PostRecord(request._createStudentClasroom, cancellationToken);
            return _statusCodeResponse.ControllerResponse(createStudentClasroom);
        }
    }
}