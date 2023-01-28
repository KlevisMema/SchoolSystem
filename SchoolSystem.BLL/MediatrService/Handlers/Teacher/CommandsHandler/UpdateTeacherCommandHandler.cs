#region Usings

using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.DTO.ViewModels.Teacher;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.MediatrService.Actions.Teacher.Commads;

#endregion

namespace SchoolSystem.BLL.MediatrService.Handlers.Teacher.CommandsHandler
{
    /// <summary>
    ///     Update teacher command handler class which implements IRequestHandler which gets the get update teacher command and object result as response 
    /// </summary>
    public class UpdateTeacherCommandHandler : IRequestHandler<UpdateTeacherCommand, ObjectResult>
    {
        /// <summary>
        ///     ICrudService interface 
        /// </summary>
        private readonly ICrudService<TeacherViewModel, CreateUpdateTeacherViewModel> _teacherService;
        /// <summary>
        ///     IControllerStatusCodeResponse interface
        /// </summary>
        private readonly IControllerStatusCodeResponse<TeacherViewModel, List<TeacherViewModel>> _statusCodeResponse;

        /// <summary>
        ///     Services injection
        /// </summary>
        /// <param name="teacherService"> Teacher service  </param>
        /// <param name="statusCodeResponse"> Status code service </param>
        public UpdateTeacherCommandHandler
        (
            ICrudService<TeacherViewModel, CreateUpdateTeacherViewModel> teacherService,
            IControllerStatusCodeResponse<TeacherViewModel, List<TeacherViewModel>> statusCodeResponse
        )
        {
            _teacherService = teacherService;
            _statusCodeResponse = statusCodeResponse;
        }

        /// <summary>
        ///     Handle the update teacher command
        /// </summary>
        /// <param name="request"> Request parameters </param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> A Object result response </returns>
        public async Task<ObjectResult> Handle
        (
            UpdateTeacherCommand request,
            CancellationToken cancellationToken
        )
        {
            var updatedTeacher = await _teacherService.PutRecord(request.Id, request._createUpdateTeacherViewModel, cancellationToken);
            return _statusCodeResponse.ControllerResponse(updatedTeacher);
        }
    }
}