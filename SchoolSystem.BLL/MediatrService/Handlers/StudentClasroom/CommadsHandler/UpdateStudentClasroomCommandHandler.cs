using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.DTO.ViewModels.StudentClasroom;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.MediatrService.Actions.StudentClasroom.Commands;

namespace SchoolSystem.BLL.MediatrService.Handlers.StudentClasroom.CommadsHandler
{
    public class UpdateStudentClasroomCommandHandler : IRequestHandler<UpdateStudentClasroomCommand, ObjectResult>
    {
        private readonly ICrudService<StudentClasroomViewModel, CreateUpdateStudentClasroomViewModel> _studentClasroomService;
        private readonly IControllerStatusCodeResponse<StudentClasroomViewModel, List<StudentClasroomViewModel>> _statusCodeResponse;

        public UpdateStudentClasroomCommandHandler
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
            UpdateStudentClasroomCommand request,
            CancellationToken cancellationToken
        )
        {
            var updatedAttendance = await _studentClasroomService.PutRecord(request.Id, request._updateStudentClasroom, cancellationToken);
            return _statusCodeResponse.ControllerResponse(updatedAttendance);
        }
    }
}