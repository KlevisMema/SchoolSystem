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
    ///     Create teacher command handler class which implements IRequestHandler which gets the get create teacher command and object result as response 
    /// </summary
    public class CreateTeacherCommandHandler : IRequestHandler<CreateTeacherCommand, ObjectResult>
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
        public CreateTeacherCommandHandler
        (
            ICrudService<TeacherViewModel, CreateUpdateTeacherViewModel> teacherService,
            IControllerStatusCodeResponse<TeacherViewModel, List<TeacherViewModel>> statusCodeResponse
        )
        {
            _teacherService = teacherService;
            _statusCodeResponse = statusCodeResponse;
        }

        /// <summary>
        ///     Handle the create teacher command
        /// </summary>
        /// <param name="request"> Request parameters </param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> A Object result response </returns>
        public async Task<ObjectResult> Handle
        (
            CreateTeacherCommand request,
            CancellationToken cancellationToken
        )
        {
            var createTeacher = await _teacherService.PostRecord(request._createUpdateTeacherViewModel, cancellationToken);
            return _statusCodeResponse.ControllerResponse(createTeacher);
        }
    }
}