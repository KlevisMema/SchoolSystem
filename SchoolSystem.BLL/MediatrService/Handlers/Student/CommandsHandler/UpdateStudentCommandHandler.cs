#region Usings

using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.DTO.ViewModels.Student;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.MediatrService.Actions.Student.Commands;

#endregion

namespace SchoolSystem.BLL.MediatrService.Handlers.Student.CommandsHandler
{
    /// <summary>
    ///     Update student command handler class which implements IRequestHandler which gets the get update student command and object result as response 
    /// </summary>
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, ObjectResult>
    {
        /// <summary>
        ///     ICrudService interface 
        /// </summary>
        private readonly ICrudService<StudentViewModel, CreateUpdateStudentViewModel> _studentService;
        /// <summary>
        ///     IControllerStatusCodeResponse interface
        /// </summary>
        private readonly IControllerStatusCodeResponse<StudentViewModel, List<StudentViewModel>> _statusCodeResponse;

        /// <summary>
        ///     Services injection
        /// </summary>
        /// <param name="studentService"> Student service  </param>
        /// <param name="statusCodeResponse"> Status code service </param>
        public UpdateStudentCommandHandler
        (
            ICrudService<StudentViewModel, CreateUpdateStudentViewModel> studentService,
            IControllerStatusCodeResponse<StudentViewModel, List<StudentViewModel>> statusCodeResponse
        )
        {
            _studentService = studentService;
            _statusCodeResponse = statusCodeResponse;
        }

        /// <summary>
        ///     Handle the update student command
        /// </summary>
        /// <param name="request"> Request parameters </param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> A Object result response </returns>
        public async Task<ObjectResult> Handle
        (
            UpdateStudentCommand request, CancellationToken cancellationToken
        )
        {
            var updatedStudent = await _studentService.PutRecord(request.Id, request._CreateUpdateStudentViewModel, cancellationToken);
            return _statusCodeResponse.ControllerResponse(updatedStudent);
        }
    }
}