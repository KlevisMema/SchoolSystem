using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.DTO.ViewModels.Student;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.MediatrService.Actions.Student.Queries;

namespace SchoolSystem.BLL.MediatrService.Handlers.Student.QueriesHandler
{
    public class GetAllStudentsQueryHandler : IRequestHandler<GetAllStudentsQuery, ObjectResult>
    {
        private readonly ICrudService<StudentViewModel, CreateUpdateStudentViewModel> _studentService;
        private readonly IControllerStatusCodeResponse<StudentViewModel, List<StudentViewModel>> _statusCodeResponse;

        public GetAllStudentsQueryHandler
        (
            ICrudService<StudentViewModel, CreateUpdateStudentViewModel> studentService,
            IControllerStatusCodeResponse<StudentViewModel, List<StudentViewModel>> statusCodeResponse
        )
        {
            _studentService = studentService;
            _statusCodeResponse = statusCodeResponse;
        }

        public async Task<ObjectResult> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
        {
            var students = await _studentService.GetRecords(cancellationToken);
            return _statusCodeResponse.ControllerResponse(students);
        }
    }
}