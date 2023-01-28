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
    ///     Delete issue command handler class which implements IRequestHandler which gets the get delete issue command and object result as response 
    /// </summary>
    public class DeleteIssueCommandHandler : IRequestHandler<DeleteIssueCommand, ObjectResult>
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
        public DeleteIssueCommandHandler
        (
            ICrudService<IssueViewModel, CreateUpdateIssueViewModel> issueService,
            IControllerStatusCodeResponse<IssueViewModel, List<IssueViewModel>> statusCodeResponse
        )
        {
            _statusCodeResponse = statusCodeResponse;
            _issueService = issueService;
        }

        /// <summary>
        ///     Handle the delete issue command
        /// </summary>
        /// <param name="request"> Request parameters </param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> A Object result response </returns>
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