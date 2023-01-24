#region Usings

using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.DTO.ViewModels.Clasroom;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.MediatrService.Actions.Clasroom.Commands; 

#endregion

namespace SchoolSystem.BLL.MediatrService.Handlers.Clasroom.CommandsHandler
{
    /// <summary>
    ///     Update clasroom command handler class which implements IRequestHandler which gets the get update clasroom command and object result as response 
    /// </summary>
    public class UpdateClasroomCommandHandler : IRequestHandler<UpdateClasroomCommand, ObjectResult>
    {
        /// <summary>
        ///     ICrudService interface 
        /// </summary>
        private readonly ICrudService<ClasroomViewModel, CreateUpdateClasroomViewModel> _clasroomService;
        /// <summary>
        ///     IControllerStatusCodeResponse interface
        /// </summary>
        private readonly IControllerStatusCodeResponse<ClasroomViewModel, List<ClasroomViewModel>> _statusCodeResponse;

        /// <summary>
        ///     Services injection
        /// </summary>
        /// <param name="clasroomService"> Clasroom service  </param>
        /// <param name="statusCodeResponse"> Status code service </param>
        public UpdateClasroomCommandHandler
        (
           ICrudService<ClasroomViewModel, CreateUpdateClasroomViewModel> clasroomService,
           IControllerStatusCodeResponse<ClasroomViewModel, List<ClasroomViewModel>> statusCodeResponse
        )
        {
            _clasroomService = clasroomService;
            _statusCodeResponse = statusCodeResponse;
        }

        /// <summary>
        ///     Handle the update clasroom command
        /// </summary>
        /// <param name="request"> Request parameters </param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> A Object result response </returns>
        public async Task<ObjectResult> Handle
        (
            UpdateClasroomCommand request,
            CancellationToken cancellationToken
        )
        {
            var updatedClasroom = await _clasroomService.PutRecord(request.Id, request._updateClasroom, cancellationToken);
            return _statusCodeResponse.ControllerResponse(updatedClasroom);
        }
    }
}