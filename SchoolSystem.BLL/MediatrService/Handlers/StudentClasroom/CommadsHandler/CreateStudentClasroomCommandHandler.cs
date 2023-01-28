#region Usings

using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.DTO.ViewModels.StudentClasroom;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.MediatrService.Actions.StudentClasroom.Commands;

#endregion

namespace SchoolSystem.BLL.MediatrService.Handlers.StudentClasroom.CommadsHandler
{
    /// <summary>
    ///     Create student clasroom command handler class which implements IRequestHandler which gets the get create student clasroom command and object result as response 
    /// </summary>
    public class CreateStudentClasroomCommandHandler : IRequestHandler<CreateStudentClasroomCommand, ObjectResult>
    {
        /// <summary>
        ///     ICrudService interface 
        /// </summary>
        private readonly ICrudService<StudentClasroomViewModel, CreateUpdateStudentClasroomViewModel> _studentClasroomService;
        /// <summary>
        ///     IControllerStatusCodeResponse interface
        /// </summary>
        private readonly IControllerStatusCodeResponse<StudentClasroomViewModel, List<StudentClasroomViewModel>> _statusCodeResponse;

        /// <summary>
        ///     Services injection
        /// </summary>
        /// <param name="studentClasroomService"> Student Clasroom service  </param>
        /// <param name="statusCodeResponse"> Status code service </param>
        public CreateStudentClasroomCommandHandler
        (
            ICrudService<StudentClasroomViewModel, CreateUpdateStudentClasroomViewModel> studentClasroomService,
            IControllerStatusCodeResponse<StudentClasroomViewModel, List<StudentClasroomViewModel>> statusCodeResponse
        )
        {
            _statusCodeResponse = statusCodeResponse;
            _studentClasroomService = studentClasroomService;
        }

        /// <summary>
        ///     Handle the create student clasroom command
        /// </summary>
        /// <param name="request"> Request parameters </param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> A Object result response </returns>
        public async Task<ObjectResult> Handle
        (
            CreateStudentClasroomCommand request,
            CancellationToken cancellationToken
        )
        {
            var createStudentClasroom = await _studentClasroomService.PostRecord(request._createStudentClasroom, cancellationToken);
            return _statusCodeResponse.ControllerResponse(createStudentClasroom);
        }
    }
}