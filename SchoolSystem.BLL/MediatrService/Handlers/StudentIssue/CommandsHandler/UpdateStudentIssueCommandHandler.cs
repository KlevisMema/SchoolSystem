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
    ///     Update student issue command handler class which implements IRequestHandler which gets the get update student issue command and object result as response 
    /// </summary>
    public class UpdateStudentIssueCommandHandler : IRequestHandler<UpdateStudentIssueCommand, ObjectResult>
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
        public UpdateStudentIssueCommandHandler
        (
            ICrudService<StudentIssueViewModel, CreateUpdateStudentIssueViewModel> studentIssueService,
            IControllerStatusCodeResponse<StudentIssueViewModel, List<StudentIssueViewModel>> statusCodeResponse
        )
        {
            _statusCodeResponse = statusCodeResponse;
            _studentIssueService = studentIssueService;
        }

        /// <summary>
        ///     Handle the update student issue command
        /// </summary>
        /// <param name="request"> Request parameters </param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> A Object result response </returns>
        public async Task<ObjectResult> Handle
        (
            UpdateStudentIssueCommand request,
            CancellationToken cancellationToken
        )
        {
            var updatedStudentIssue = await _studentIssueService.PutRecord(request.Id, request._updateStudentIssue, cancellationToken);
            return _statusCodeResponse.ControllerResponse(updatedStudentIssue);
        }
    }
}