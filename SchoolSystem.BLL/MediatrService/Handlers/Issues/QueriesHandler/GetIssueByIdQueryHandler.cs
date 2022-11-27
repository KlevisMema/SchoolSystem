using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.DTO.ViewModels.Issue;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.MediatrService.Actions.Issues.Queries;

namespace SchoolSystem.BLL.MediatrService.Handlers.Issues.QueriesHandler
{
    internal class GetIssueByIdQueryHandler : IRequestHandler<GetIssueByIdQuery, ObjectResult>
    {
        private readonly ICrudService<IssueViewModel, CreateUpdateIssueViewModel> _issueService;
        private readonly IControllerStatusCodeResponse<IssueViewModel, List<IssueViewModel>> _statusCodeResponse;

        public GetIssueByIdQueryHandler
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
            GetIssueByIdQuery request,
            CancellationToken cancellationToken
        )
        {
            var issue = await _issueService.GetRecord(request.Id, cancellationToken);
            return _statusCodeResponse.ControllerResponse(issue);
        }
    }
}