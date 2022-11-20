using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.DTO.ViewModels.Student;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.MediatrService.Actions.Student.Commands;


namespace SchoolSystem.BLL.MediatrService.Handlers.Student.CommandsHandler
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommad, ObjectResult>
    {
        private readonly ICrudService<StudentViewModel, CreateUpdateStudentViewModel> _studentService;
        private readonly IControllerStatusCodeResponse<StudentViewModel, List<StudentViewModel>> _statusCodeResponse;

        public CreateStudentCommandHandler
        (
            ICrudService<StudentViewModel, CreateUpdateStudentViewModel> studentService,
            IControllerStatusCodeResponse<StudentViewModel, List<StudentViewModel>> statusCodeResponse
        )
        {
            _studentService = studentService;
            _statusCodeResponse = statusCodeResponse;
        }

        public async Task<ObjectResult> Handle(CreateStudentCommad request, CancellationToken cancellationToken)
        {
            var createStudent = await _studentService.PostRecord(request._CreateUpdateStudentViewModel, cancellationToken);
            return _statusCodeResponse.ControllerResponse(createStudent);
        }
    }
}