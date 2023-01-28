#region Usings

using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.DTO.ViewModels.Issue;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.MediatrService.Actions.Issues.Queries;

#endregion

namespace SchoolSystem.BLL.MediatrService.Handlers.Issues.QueriesHandler
{
    /// <summary>
    ///     Get issue query handler class which implements IRequestHandler which gets the get issue query and object result as response 
    /// </summary>
    public class GetIssueByIdQueryHandler : IRequestHandler<GetIssueByIdQuery, ObjectResult>
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
        public GetIssueByIdQueryHandler
        (
            ICrudService<IssueViewModel, CreateUpdateIssueViewModel> issueService,
            IControllerStatusCodeResponse<IssueViewModel, List<IssueViewModel>> statusCodeResponse
        )
        {
            _statusCodeResponse = statusCodeResponse;
            _issueService = issueService;
        }

        /// <summary>
        ///     Handle the get issue by id query
        /// </summary>
        /// <param name="request"> Request parameters </param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> A Object result response </returns>
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