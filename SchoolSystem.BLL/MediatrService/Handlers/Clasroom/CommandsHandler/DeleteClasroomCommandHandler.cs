using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.DTO.ViewModels.Clasroom;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.MediatrService.Actions.Clasroom.Commands;

namespace SchoolSystem.BLL.MediatrService.Handlers.Clasroom.CommandsHandler
{
    public class DeleteClasroomCommandHandler : IRequestHandler<DeleteClasroomCommand, ObjectResult>
    {
        private readonly ICrudService<ClasroomViewModel, CreateUpdateClasroomViewModel> _clasroomService;
        private readonly IControllerStatusCodeResponse<ClasroomViewModel, List<ClasroomViewModel>> _statusCodeResponse;

        public DeleteClasroomCommandHandler
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
            DeleteClasroomCommand request,
            CancellationToken cancellationToken
        )
        {
            var deleteClasroom = await _clasroomService.DeleteRecord(request.Id, cancellationToken);
            return _statusCodeResponse.ControllerResponse(deleteClasroom);
        }
    }
}