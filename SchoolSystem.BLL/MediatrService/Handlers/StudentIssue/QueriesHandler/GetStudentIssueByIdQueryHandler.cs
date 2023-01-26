#region Usings

using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.DTO.ViewModels.StudentIssues;
using SchoolSystem.BLL.MediatrService.Actions.StudentIssue.Queries;

#endregion

namespace SchoolSystem.BLL.MediatrService.Handlers.StudentIssue.QueriesHandler
{
    /// <summary>
    ///     Get student issue query handler class which implements IRequestHandler which gets the get student issue query and object result as response 
    /// </summary>
    public class GetStudentIssueByIdQueryHandler : IRequestHandler<GetStudentIssuesByIdQuery, ObjectResult>
    {
        /// <summary>
        ///     ICrudService interface 
        /// </summary>
        private readonly GetRecordFromCompositeKeysTable<StudentIssueViewModel> _studentIssueService;
        /// <summary>
        ///     IControllerStatusCodeResponse interface
        /// </summary>
        private readonly IControllerStatusCodeResponse<StudentIssueViewModel, List<StudentIssueViewModel>> _statusCodeResponse;

        /// <summary>
        ///     Services injection
        /// </summary>
        /// <param name="studentIssueService"> Student Issue service  </param>
        /// <param name="statusCodeResponse"> Status code service </param>
        public GetStudentIssueByIdQueryHandler
        (
            GetRecordFromCompositeKeysTable<StudentIssueViewModel> studentIssueService,
            IControllerStatusCodeResponse<StudentIssueViewModel, List<StudentIssueViewModel>> statusCodeResponse
        )
        {
            _statusCodeResponse = statusCodeResponse;
            _studentIssueService = studentIssueService;
        }

        /// <summary>
        ///     Handle the get student issue by id query
        /// </summary>
        /// <param name="request"> Request parameters </param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> A Object result response </returns>
        public async Task<ObjectResult> Handle
        (
            GetStudentIssuesByIdQuery request,
            CancellationToken cancellationToken
        )
        {
            var studentIssue = await _studentIssueService.GetRecordCompositeKeysTable(request.IssueId, request.StudentId, cancellationToken);
            return _statusCodeResponse.ControllerResponse(studentIssue);
        }
    }
}