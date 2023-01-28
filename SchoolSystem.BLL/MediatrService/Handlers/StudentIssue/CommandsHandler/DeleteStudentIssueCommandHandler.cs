#region Usings

using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.DTO.ViewModels.StudentIssues;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.MediatrService.Actions.StudentIssue.Commands;

#endregion

namespace SchoolSystem.BLL.MediatrService.Handlers.StudentIssue.CommandsHandler
{
    /// <summary>
    ///     Delete student issues command handler class which implements IRequestHandler which gets the get delete student issues command and object result as response 
    /// </summary>
    public class DeleteStudentIssueCommandHandler : IRequestHandler<DeleteStudentIssueCommand, ObjectResult>
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
        public DeleteStudentIssueCommandHandler
        (
            ICrudService<StudentIssueViewModel, CreateUpdateStudentIssueViewModel> studentIssueService,
            IControllerStatusCodeResponse<StudentIssueViewModel, List<StudentIssueViewModel>> statusCodeResponse
        )
        {
            _statusCodeResponse = statusCodeResponse;
            _studentIssueService = studentIssueService;
        }

        /// <summary>
        ///     Handle the delete student issues command
        /// </summary>
        /// <param name="request"> Request parameters </param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> A Object result response </returns>
        public async Task<ObjectResult> Handle
        (
            DeleteStudentIssueCommand request,
            CancellationToken cancellationToken
        )
        {
            var deleteStudentIssue = await _studentIssueService.DeleteRecord(request.Id, cancellationToken);
            return _statusCodeResponse.ControllerResponse(deleteStudentIssue);
        }
    }
}