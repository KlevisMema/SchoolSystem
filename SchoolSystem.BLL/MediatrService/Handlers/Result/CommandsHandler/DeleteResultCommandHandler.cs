using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.DTO.ViewModels.Result;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.MediatrService.Actions.Result.Commands;

namespace SchoolSystem.BLL.MediatrService.Handlers.Result.CommandsHandler
{
    public class DeleteResultCommandHandler : IRequestHandler<DeleteResultCommand, ObjectResult>
    {
        private readonly ICrudService<ResultViewModel, CreateUpdateResultViewModel> _resultService;
        private readonly IControllerStatusCodeResponse<ResultViewModel, List<ResultViewModel>> _statusCodeResponse;

        public DeleteResultCommandHandler
        (
           ICrudService<ResultViewModel, CreateUpdateResultViewModel> resultService,
           IControllerStatusCodeResponse<ResultViewModel, List<ResultViewModel>> statusCodeResponse
        )
        {
            _resultService = resultService;
            _statusCodeResponse = statusCodeResponse;
        }

        public async Task<ObjectResult> Handle
        (
            DeleteResultCommand request,
            CancellationToken cancellationToken
        )
        {
            var deleteResult = await _resultService.DeleteRecord(request.Id, cancellationToken);
            return _statusCodeResponse.ControllerResponse(deleteResult);
        }
    }
}