using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.BLL.ResponseService;
using SchoolSystem.DTO.ViewModels.Teacher;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.MediatrService.Actions.Teacher.Queries;
using SchoolSystem.BLL.ServiceInterfaces;

namespace SchoolSystem.BLL.MediatrService.Handlers.Teacher.QueriesHandler
{
    public class GetTeacherByIdQueryHandler : IRequestHandler<GetTeacherByIdQuery, ObjectResult>
    {
        private readonly ICrudService<TeacherViewModel, CreateUpdateTeacherViewModel> _teacherService;
        private readonly IControllerStatusCodeResponse<TeacherViewModel, List<TeacherViewModel>> _statusCodeResponse;

        public GetTeacherByIdQueryHandler
        (
            ICrudService<TeacherViewModel, CreateUpdateTeacherViewModel> teacherService,
            IControllerStatusCodeResponse<TeacherViewModel, List<TeacherViewModel>> statusCodeResponse
        )
        {
            _teacherService = teacherService;
            _statusCodeResponse = statusCodeResponse;
        }

        public async Task<ObjectResult> Handle(GetTeacherByIdQuery request, CancellationToken cancellationToken)
        {
            var teacher = await _teacherService.GetRecord(request.Id, cancellationToken);
            return _statusCodeResponse.ControllerResponse(teacher);
        }
    }
}
