using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.DTO.ViewModels.Issue;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.MediatrService.Actions.Issues.Queries;

namespace SchoolSystem.BLL.MediatrService.Handlers.Issues.QueriesHandler
{
    public class GetAllIssuesQueryHandler : IRequestHandler<GetAllIssuesQuery, ObjectResult>
    {
        private readonly ICrudService<IssueViewModel, CreateUpdateIssueViewModel> _issueService;
        private readonly IControllerStatusCodeResponse<IssueViewModel, List<IssueViewModel>> _statusCodeResponse;

        public GetAllIssuesQueryHandler
        (
            ICrudService<IssueViewModel, CreateUpdateIssueViewModel> issueService,
            IControllerStatusCodeResponse<IssueViewModel, List<IssueViewModel>> statusCodeResponse
        )
        {
            _statusCodeResponse = statusCodeResponse;
            _issueService = issueService;
        }

        public async Task<ObjectResult> Handle
        (
            GetAllIssuesQuery request,
            CancellationToken cancellationToken
        )
        {
            var issues = await _issueService.GetRecords(cancellationToken);
            return _statusCodeResponse.ControllerResponse(issues);
        }
    }
}