using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.DTO.ViewModels.Student;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.MediatrService.Actions.Student.Queries;

namespace SchoolSystem.BLL.MediatrService.Handlers.Student.QueriesHandler
{
    public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, ObjectResult>
    {
        private readonly ICrudService<StudentViewModel, CreateUpdateStudentViewModel> _studentService;
        private readonly IControllerStatusCodeResponse<StudentViewModel, List<StudentViewModel>> _statusCodeResponse;

        public GetStudentByIdQueryHandler
        (
            ICrudService<StudentViewModel, CreateUpdateStudentViewModel> studentService,
            IControllerStatusCodeResponse<StudentViewModel, List<StudentViewModel>> statusCodeResponse
        )
        {
            _statusCodeResponse = statusCodeResponse;
            _studentService = studentService;
        }

        public async Task<ObjectResult> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await _studentService.GetRecord(request.Id, cancellationToken);
            return _statusCodeResponse.ControllerResponse(student);
        }
    }
}