using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.DTO.ViewModels.Issue;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.MediatrService.Actions.Issues.Commands;

namespace SchoolSystem.BLL.MediatrService.Handlers.Issues.CommandsHandler
{
    public class UpdateIssueCommandHandler : IRequestHandler<UpdateIssueCommand, ObjectResult>
    {
        private readonly ICrudService<IssueViewModel, CreateUpdateIssueViewModel> _issueService;
        private readonly IControllerStatusCodeResponse<IssueViewModel, List<IssueViewModel>> _statusCodeResponse;

        public UpdateIssueCommandHandler
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
            UpdateIssueCommand request,
            CancellationToken cancellationToken
        )
        {
            var updatedIssue = await _issueService.PutRecord(request.Id, request._updateIssue, cancellationToken);
            return _statusCodeResponse.ControllerResponse(updatedIssue);
        }
    }
}
