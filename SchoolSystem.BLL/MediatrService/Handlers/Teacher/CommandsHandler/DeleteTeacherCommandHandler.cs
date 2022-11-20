using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.DTO.ViewModels.Teacher;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.MediatrService.Actions.Teacher.Commads;

namespace SchoolSystem.BLL.MediatrService.Handlers.Teacher.CommandsHandler
{
    public class DeleteTeacherCommandHandler : IRequestHandler<DeleteTeacherCommand, ObjectResult>
    {
        private readonly ICrudService<TeacherViewModel, CreateUpdateTeacherViewModel> _teacherService;
        private readonly IControllerStatusCodeResponse<TeacherViewModel, List<TeacherViewModel>> _statusCodeResponse;
        public DeleteTeacherCommandHandler
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
            DeleteTeacherCommand request,
            CancellationToken cancellationToken
        )
        {
            var deleteTeacher = await _teacherService.DeleteRecord(request.Id, cancellationToken);
            return _statusCodeResponse.ControllerResponse(deleteTeacher);
        }
    }
}