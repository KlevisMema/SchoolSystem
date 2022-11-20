using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.DTO.ViewModels.Teacher;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.MediatrService.Actions.Teacher.Commads;


namespace SchoolSystem.BLL.MediatrService.Handlers.Teacher.CommandsHandler
{
    public class CreateTeacherCommandHandler : IRequestHandler<CreateTeacherCommand, ObjectResult>
    {
        private readonly ICrudService<TeacherViewModel, CreateUpdateTeacherViewModel> _teacherService;
        private readonly IControllerStatusCodeResponse<TeacherViewModel, List<TeacherViewModel>> _statusCodeResponse;

        public CreateTeacherCommandHandler
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
            CreateTeacherCommand request,
            CancellationToken cancellationToken
        )
        {
            var createTeacher = await _teacherService.PostRecord(request._createUpdateTeacherViewModel, cancellationToken);
            return _statusCodeResponse.ControllerResponse(createTeacher);
        }
    }
}