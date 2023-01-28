#region Usings

using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.DTO.ViewModels.StudentIssues;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.MediatrService.Actions.StudentIssue.Queries;

#endregion

namespace SchoolSystem.BLL.MediatrService.Handlers.StudentIssue.QueriesHandler
{
    /// <summary>
    ///     Get student issues query handler class which implements IRequestHandler which gets the get student issues query and object result as response 
    /// </summary>
    public class GetAllStudentIssuesQueryHandler : IRequestHandler<GetAllStudentIssuesByIdQuery, ObjectResult>
    {
        /// <summary>
        ///     ICrudService interface 
        /// </summary>
        private readonly ICrudService<StudentIssueViewModel, CreateUpdateStudentIssueViewModel> _studentIssueService;
        /// <summary>
        ///     IControllerStatusCodeResponse interface
        /// </summary>
        private readonly IControllerStatusCodeResponse<StudentIssueViewModel, List<StudentIssueViewModel>> _statusCodeResponse;

        /// <summary>
        ///     Services injection
        /// </summary>
        /// <param name="studentIssueService"> Student Issue service  </param>
        /// <param name="statusCodeResponse"> Status code service </param>
        public GetAllStudentIssuesQueryHandler
        (
            ICrudService<StudentIssueViewModel, CreateUpdateStudentIssueViewModel> studentIssueService,
            IControllerStatusCodeResponse<StudentIssueViewModel, List<StudentIssueViewModel>> statusCodeResponse
        )
        {
            _statusCodeResponse = statusCodeResponse;
            _studentIssueService = studentIssueService;
        }

        /// <summary>
        ///     Handle the get student issues query
        /// </summary>
        /// <param name="request"> Request parameters </param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> A Object result response </returns>
        public async Task<ObjectResult> Handle
        (
            GetAllStudentIssuesByIdQuery request,
            CancellationToken cancellationToken
        )
        {
            var studentIssues = await _studentIssueService.GetRecords(cancellationToken);
            return _statusCodeResponse.ControllerResponse(studentIssues);
        }
    }
}