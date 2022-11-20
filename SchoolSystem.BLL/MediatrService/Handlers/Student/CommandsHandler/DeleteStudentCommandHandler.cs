using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.DTO.ViewModels.Student;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.MediatrService.Actions.Student.Commands;


namespace SchoolSystem.BLL.MediatrService.Handlers.Student.CommandsHandler
{
    public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand, ObjectResult>
    {
        private readonly ICrudService<StudentViewModel, CreateUpdateStudentViewModel> _studentService;
        private readonly IControllerStatusCodeResponse<StudentViewModel, List<StudentViewModel>> _statusCodeResponse;

        public DeleteStudentCommandHandler
        (
            ICrudService<StudentViewModel, CreateUpdateStudentViewModel> studentService,
            IControllerStatusCodeResponse<StudentViewModel, List<StudentViewModel>> statusCodeResponse
        )
        {
            _statusCodeResponse = statusCodeResponse;
            _studentService = studentService;
        }

        public async Task<ObjectResult> Handle
        (
            DeleteStudentCommand request, CancellationToken cancellationToken
        )
        {
            var deleteStudent = await _studentService.DeleteRecord(request.Id, cancellationToken);
            return _statusCodeResponse.ControllerResponse(deleteStudent);
        }
    }
}