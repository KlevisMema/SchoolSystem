using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.DTO.ViewModels.StudentIssues;
using SchoolSystem.BLL.MediatrService.Actions.StudentIssue.Queries;

namespace SchoolSystem.BLL.MediatrService.Handlers.StudentIssue.QueriesHandler
{
    public class GetStudentIssueByIdQueryHandler : IRequestHandler<GetStudentIssuesByIdQuery, ObjectResult>
    {
        private readonly GetRecordFromCompositeKeysTable<StudentIssueViewModel> _studentIssueService;
        private readonly IControllerStatusCodeResponse<StudentIssueViewModel, List<StudentIssueViewModel>> _statusCodeResponse;

        public GetStudentIssueByIdQueryHandler
        (
            GetRecordFromCompositeKeysTable<StudentIssueViewModel> studentIssueService,
            IControllerStatusCodeResponse<StudentIssueViewModel, List<StudentIssueViewModel>> statusCodeResponse
        )
        {
            _statusCodeResponse = statusCodeResponse;
            _studentIssueService = studentIssueService;
        }

        public async Task<ObjectResult> Handle
        (
            GetStudentIssuesByIdQuery request,
            CancellationToken cancellationToken
        )
        {
            var studentIssue = await _studentIssueService.GetRecordCompositeKeysTable(request.IssueId, request.StudentId, cancellationToken);
            return _statusCodeResponse.ControllerResponse(studentIssue);
        }
    }
}