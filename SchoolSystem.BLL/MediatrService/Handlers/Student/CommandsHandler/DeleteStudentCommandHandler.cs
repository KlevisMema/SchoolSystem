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
    ///     Delete student command handler class which implements IRequestHandler which gets the get delete student command and object result as response 
    /// </summary>
    public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand, ObjectResult>
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
        public DeleteStudentCommandHandler
        (
            ICrudService<StudentViewModel, CreateUpdateStudentViewModel> studentService,
            IControllerStatusCodeResponse<StudentViewModel, List<StudentViewModel>> statusCodeResponse
        )
        {
            _statusCodeResponse = statusCodeResponse;
            _studentService = studentService;
        }

        /// <summary>
        ///     Handle the delete student command
        /// </summary>
        /// <param name="request"> Request parameters </param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> A Object result response </returns>
        public async Task<ObjectResult> Handle
        (
            DeleteStudentCommand request, CancellationToken cancellationToken
        )
        {
            var deleteStudent = await _studentService.DeleteRecord(request.Id, cancellationToken);
            return _statusCodeResponse.ControllerResponse(deleteStudent);
        }
    }
}