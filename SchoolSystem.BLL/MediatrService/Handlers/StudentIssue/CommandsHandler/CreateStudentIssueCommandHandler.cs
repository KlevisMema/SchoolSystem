using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.DTO.ViewModels.StudentIssues;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.MediatrService.Actions.StudentIssue.Commands;

namespace SchoolSystem.BLL.MediatrService.Handlers.StudentIssue.CommandsHandler
{
    public class CreateStudentIssueCommandHandler : IRequestHandler<CreateStudentIssueCommand, ObjectResult>
    {
        private readonly ICrudService<StudentIssueViewModel, CreateUpdateStudentIssueViewModel> _studentIssueService;
        private readonly IControllerStatusCodeResponse<StudentIssueViewModel, List<StudentIssueViewModel>> _statusCodeResponse;

        public CreateStudentIssueCommandHandler
        (
            ICrudService<StudentIssueViewModel, CreateUpdateStudentIssueViewModel> studentIssueService,
            IControllerStatusCodeResponse<StudentIssueViewModel, List<StudentIssueViewModel>> statusCodeResponse
        )
        {
            _statusCodeResponse = statusCodeResponse;
            _studentIssueService = studentIssueService;
        }

        public async Task<ObjectResult> Handle
        (
            CreateStudentIssueCommand request,
            CancellationToken cancellationToken
        )
        {
            var createStudentIssue = await _studentIssueService.PostRecord(request._createStudentIssue, cancellationToken);
            return _statusCodeResponse.ControllerResponse(createStudentIssue);
        }
    }
}