using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.DTO.ViewModels.Issue;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.MediatrService.Actions.Issues.Commands;

namespace SchoolSystem.BLL.MediatrService.Handlers.Issues.CommandsHandler
{
    public class DeleteIssueCommandHandler : IRequestHandler<DeleteIssueCommand, ObjectResult>
    {
        private readonly ICrudService<IssueViewModel, CreateUpdateIssueViewModel> _issueService;
        private readonly IControllerStatusCodeResponse<IssueViewModel, List<IssueViewModel>> _statusCodeResponse;

        public DeleteIssueCommandHandler
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
            DeleteIssueCommand request,
            CancellationToken cancellationToken
        )
        {
            var deleteIssue = await _issueService.DeleteRecord(request.Id, cancellationToken);
            return _statusCodeResponse.ControllerResponse(deleteIssue);
        }
    }
}