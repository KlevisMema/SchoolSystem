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
    ///     Create student issue command handler class which implements IRequestHandler which gets the get create student issue command and object result as response 
    /// </summary>
    public class CreateStudentIssueCommandHandler : IRequestHandler<CreateStudentIssueCommand, ObjectResult>
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
        public CreateStudentIssueCommandHandler
        (
            ICrudService<StudentIssueViewModel, CreateUpdateStudentIssueViewModel> studentIssueService,
            IControllerStatusCodeResponse<StudentIssueViewModel, List<StudentIssueViewModel>> statusCodeResponse
        )
        {
            _statusCodeResponse = statusCodeResponse;
            _studentIssueService = studentIssueService;
        }

        /// <summary>
        ///     Handle the create student issue command
        /// </summary>
        /// <param name="request"> Request parameters </param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> A Object result response </returns>
        public async Task<ObjectResult> Handle
        (
            CreateStudentIssueCommand request,
            CancellationToken cancellationToken
        )
        {
            var createStudentIssue = await _studentIssueService.PostRecord(request._createStudentIssue, cancellationToken);
            return _statusCodeResponse.ControllerResponse(createStudentIssue);
        }
    }
}