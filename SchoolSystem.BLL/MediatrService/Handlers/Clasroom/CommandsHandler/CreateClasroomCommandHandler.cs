using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.DTO.ViewModels.Clasroom;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.MediatrService.Actions.Clasroom.Commands;

namespace SchoolSystem.BLL.MediatrService.Handlers.Clasroom.CommandsHandler
{
    public class CreateClasroomCommandHandler : IRequestHandler<CreateClasroomCommand, ObjectResult>
    {
        private readonly ICrudService<ClasroomViewModel, CreateUpdateClasroomViewModel> _clasroomService;
        private readonly IControllerStatusCodeResponse<ClasroomViewModel, List<ClasroomViewModel>> _statusCodeResponse;

        public CreateClasroomCommandHandler
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
            CreateClasroomCommand request,
            CancellationToken cancellationToken
        )
        {
            var createClasroom = await _clasroomService.PostRecord(request._createClasroom, cancellationToken);
            return _statusCodeResponse.ControllerResponse(createClasroom);
        }
    }
}