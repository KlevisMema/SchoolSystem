using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.DTO.ViewModels.StudentIssues;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.MediatrService.Actions.StudentIssue.Queries;

namespace SchoolSystem.BLL.MediatrService.Handlers.StudentIssue.QueriesHandler
{
    public class GetAllStudentIssuesQueryHandler : IRequestHandler<GetAllStudentIssuesByIdQuery, ObjectResult>
    {
        private readonly ICrudService<StudentIssueViewModel, CreateUpdateStudentIssueViewModel> _studentIssueService;
        private readonly IControllerStatusCodeResponse<StudentIssueViewModel, List<StudentIssueViewModel>> _statusCodeResponse;

        public GetAllStudentIssuesQueryHandler
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
            GetAllStudentIssuesByIdQuery request,
            CancellationToken cancellationToken
        )
        {
            var studentIssues = await _studentIssueService.GetRecords(cancellationToken);
            return _statusCodeResponse.ControllerResponse(studentIssues);
        }
    }
}