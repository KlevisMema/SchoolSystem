using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.DTO.ViewModels.Result;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.MediatrService.Actions.Result.Commands;

namespace SchoolSystem.BLL.MediatrService.Handlers.Result.CommandsHandler
{
    internal class CreateResultCommandHandler : IRequestHandler<CreateResultCommand, ObjectResult>
    {
        private readonly ICrudService<ResultViewModel, CreateUpdateResultViewModel> _resultService;
        private readonly IControllerStatusCodeResponse<ResultViewModel, List<ResultViewModel>> _statusCodeResponse;

        public CreateResultCommandHandler
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
            CreateResultCommand request,
            CancellationToken cancellationToken
        )
        {
            var createResult = await _resultService.PostRecord(request._createResult, cancellationToken);
            return _statusCodeResponse.ControllerResponse(createResult);
        }
    }
}