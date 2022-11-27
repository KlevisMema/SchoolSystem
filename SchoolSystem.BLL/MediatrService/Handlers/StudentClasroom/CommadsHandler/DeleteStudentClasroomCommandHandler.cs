using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.DTO.ViewModels.StudentClasroom;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.MediatrService.Actions.StudentClasroom.Commands;

namespace SchoolSystem.BLL.MediatrService.Handlers.StudentClasroom.CommadsHandler
{
    public class DeleteStudentClasroomCommandHandler : IRequestHandler<DeleteStudentClasroomCommand, ObjectResult>
    {
        private readonly ICrudService<StudentClasroomViewModel, CreateUpdateStudentClasroomViewModel> _studentClasroomService;
        private readonly IControllerStatusCodeResponse<StudentClasroomViewModel, List<StudentClasroomViewModel>> _statusCodeResponse;

        public DeleteStudentClasroomCommandHandler
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
            DeleteStudentClasroomCommand request,
            CancellationToken cancellationToken
        )
        {
            var deleteStudentClasroom = await _studentClasroomService.DeleteRecord(request.Id, cancellationToken);
            return _statusCodeResponse.ControllerResponse(deleteStudentClasroom);
        }
    }
}