#region Usings

using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.DTO.ViewModels.Issue;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.MediatrService.Actions.Issues.Commands;

#endregion

namespace SchoolSystem.BLL.MediatrService.Handlers.Issues.CommandsHandler
{
    /// <summary>
    ///     Update issue command handler class which implements IRequestHandler which gets the get update issue command and object result as response 
    /// </summary>
    public class UpdateIssueCommandHandler : IRequestHandler<UpdateIssueCommand, ObjectResult>
    {
        /// <summary>
        ///     ICrudService interface 
        /// </summary>
        private readonly ICrudService<IssueViewModel, CreateUpdateIssueViewModel> _issueService;
        /// <summary>
        ///     IControllerStatusCodeResponse interface
        /// </summary>
        private readonly IControllerStatusCodeResponse<IssueViewModel, List<IssueViewModel>> _statusCodeResponse;

        /// <summary>
        ///     Services injection
        /// </summary>
        /// <param name="issueService"> Issue service  </param>
        /// <param name="statusCodeResponse"> Status code service </param>
        public UpdateIssueCommandHandler
        (
            ICrudService<IssueViewModel, CreateUpdateIssueViewModel> issueService,
            IControllerStatusCodeResponse<IssueViewModel, List<IssueViewModel>> statusCodeResponse
        )
        {
            _statusCodeResponse = statusCodeResponse;
            _issueService = issueService;
        }

        /// <summary>
        ///     Handle the update issue command
        /// </summary>
        /// <param name="request"> Request parameters </param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> A Object result response </returns>
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
