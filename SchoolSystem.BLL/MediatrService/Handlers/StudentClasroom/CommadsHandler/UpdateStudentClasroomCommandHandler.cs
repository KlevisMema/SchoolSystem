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
    ///     Update student clasroom command handler class which implements IRequestHandler which gets the get update student clasroom command and object result as response 
    /// </summary>
    public class UpdateStudentClasroomCommandHandler : IRequestHandler<UpdateStudentClasroomCommand, ObjectResult>
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
        public UpdateStudentClasroomCommandHandler
        (
            ICrudService<StudentClasroomViewModel, CreateUpdateStudentClasroomViewModel> studentClasroomService,
            IControllerStatusCodeResponse<StudentClasroomViewModel, List<StudentClasroomViewModel>> statusCodeResponse
        )
        {
            _statusCodeResponse = statusCodeResponse;
            _studentClasroomService = studentClasroomService;
        }

        /// <summary>
        ///     Handle the update student clasroom command
        /// </summary>
        /// <param name="request"> Request parameters </param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> A Object result response </returns>
        public async Task<ObjectResult> Handle
        (
            UpdateStudentClasroomCommand request,
            CancellationToken cancellationToken
        )
        {
            var updatedStudentClasroom = await _studentClasroomService.PutRecord(request.Id, request._updateStudentClasroom, cancellationToken);
            return _statusCodeResponse.ControllerResponse(updatedStudentClasroom);
        }
    }
}