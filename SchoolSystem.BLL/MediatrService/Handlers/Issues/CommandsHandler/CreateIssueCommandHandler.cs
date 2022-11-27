using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.DTO.ViewModels.Issue;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.MediatrService.Actions.Issues.Commands;

namespace SchoolSystem.BLL.MediatrService.Handlers.Issues.CommandsHandler
{
    public class CreateIssueCommandHandler : IRequestHandler<CreateIssueCommand, ObjectResult>
    {
        private readonly ICrudService<IssueViewModel, CreateUpdateIssueViewModel> _issueService;
        private readonly IControllerStatusCodeResponse<IssueViewModel, List<IssueViewModel>> _statusCodeResponse;

        public CreateIssueCommandHandler
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
            CreateIssueCommand request,
            CancellationToken cancellationToken
        )
        {
            var createIssue = await _issueService.PostRecord(request._createIssue, cancellationToken);
            return _statusCodeResponse.ControllerResponse(createIssue);
        }
    }
}