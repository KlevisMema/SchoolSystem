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
    ///     Create clasroom command handler class which implements IRequestHandler which gets the get create clasroom command and object result as response 
    /// </summary>
    public class CreateClasroomCommandHandler : IRequestHandler<CreateClasroomCommand, ObjectResult>
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
        public CreateClasroomCommandHandler
        (
            ICrudService<ClasroomViewModel, CreateUpdateClasroomViewModel> clasroomService,
            IControllerStatusCodeResponse<ClasroomViewModel, List<ClasroomViewModel>> statusCodeResponse
        )
        {
            _clasroomService = clasroomService;
            _statusCodeResponse = statusCodeResponse;
        }

        /// <summary>
        ///     Handle the create clasroom command
        /// </summary>
        /// <param name="request"> Request parameters </param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> A Object result response </returns>
        public async Task<ObjectResult> Handle
        (
            CreateClasroomCommand request,
            CancellationToken cancellationToken
        )
        {
            var createClasroom = await _clasroomService.PostRecord(request._createClasroom, cancellationToken);
            return _statusCodeResponse.ControllerResponse(createClasroom);
        }
    }
}