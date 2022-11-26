using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.DTO.ViewModels.Clasroom;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.MediatrService.Actions.Clasroom.Commands;

namespace SchoolSystem.BLL.MediatrService.Handlers.Clasroom.CommandsHandler
{
    public class UpdateClasroomCommandHandler : IRequestHandler<UpdateClasroomCommand, ObjectResult>
    {
        private readonly ICrudService<ClasroomViewModel, CreateUpdateClasroomViewModel> _clasroomService;
        private readonly IControllerStatusCodeResponse<ClasroomViewModel, List<ClasroomViewModel>> _statusCodeResponse;

        public UpdateClasroomCommandHandler
        (
           ICrudService<ClasroomViewModel, CreateUpdateClasroomViewModel> clasroomService,
           IControllerStatusCodeResponse<ClasroomViewModel, List<ClasroomViewModel>> statusCodeResponse
        )
        {
            _clasroomService = clasroomService;
            _statusCodeResponse = statusCodeResponse;
        }

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