using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.DTO.ViewModels.Result;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.MediatrService.Actions.Result.Commands;

namespace SchoolSystem.BLL.MediatrService.Handlers.Result.CommandsHandler
{
    internal class UpdateResultCommandHandler : IRequestHandler<UpdateResultCommand, ObjectResult>
    {
        private readonly ICrudService<ResultViewModel, CreateUpdateResultViewModel> _resultService;
        private readonly IControllerStatusCodeResponse<ResultViewModel, List<ResultViewModel>> _statusCodeResponse;

        public UpdateResultCommandHandler
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
            UpdateResultCommand request,
            CancellationToken cancellationToken
        )
        {
            var updatedResult = await _resultService.PutRecord(request.Id, request._updateResult, cancellationToken);
            return _statusCodeResponse.ControllerResponse(updatedResult);
        }
    }
}