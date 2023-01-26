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
    ///     Create issue command handler class which implements IRequestHandler which gets the get create issue command and object result as response 
    /// </summary>
    public class CreateIssueCommandHandler : IRequestHandler<CreateIssueCommand, ObjectResult>
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
        public CreateIssueCommandHandler
        (
            ICrudService<IssueViewModel, CreateUpdateIssueViewModel> issueService,
            IControllerStatusCodeResponse<IssueViewModel, List<IssueViewModel>> statusCodeResponse
        )
        {
            _statusCodeResponse = statusCodeResponse;
            _issueService = issueService;
        }

        /// <summary>
        ///     Handle the create issue command
        /// </summary>
        /// <param name="request"> Request parameters </param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> A Object result response </returns>
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