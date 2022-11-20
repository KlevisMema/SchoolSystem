using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.DTO.ViewModels.Teacher;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.MediatrService.Actions.Teacher.Commads;

namespace SchoolSystem.BLL.MediatrService.Handlers.Teacher.CommandsHandler
{
    public class UpdateTeacherCommandHandler : IRequestHandler<UpdateTeacherCommand, ObjectResult>
    {
        private readonly ICrudService<TeacherViewModel, CreateUpdateTeacherViewModel> _teacherService;
        private readonly IControllerStatusCodeResponse<TeacherViewModel, List<TeacherViewModel>> _statusCodeResponse;

        public UpdateTeacherCommandHandler
        (
            ICrudService<TeacherViewModel, CreateUpdateTeacherViewModel> teacherService,
            IControllerStatusCodeResponse<TeacherViewModel, List<TeacherViewModel>> statusCodeResponse
        )
        {
            _teacherService = teacherService;
            _statusCodeResponse = statusCodeResponse;
        }

        public async Task<ObjectResult> Handle
        (
            UpdateTeacherCommand request,
            CancellationToken cancellationToken
        )
        {
            var updatedTeacher = await _teacherService.PutRecord(request.Id, request._createUpdateTeacherViewModel, cancellationToken);
            return _statusCodeResponse.ControllerResponse(updatedTeacher);
        }
    }
}