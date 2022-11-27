using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.DTO.ViewModels.Result;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.MediatrService.Actions.Result.Queries;

namespace SchoolSystem.BLL.MediatrService.Handlers.Result.QueriesHandler
{
    public class GetResultByIdQueryHandler : IRequestHandler<GetResultByIdQuery, ObjectResult>
    {
        private readonly ICrudService<ResultViewModel, CreateUpdateResultViewModel> _resultService;
        private readonly IControllerStatusCodeResponse<ResultViewModel, List<ResultViewModel>> _statusCodeResponse;

        public GetResultByIdQueryHandler
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
            GetResultByIdQuery request,
            CancellationToken cancellationToken
        )
        {
            var result = await _resultService.GetRecord(request.Id, cancellationToken);
            return _statusCodeResponse.ControllerResponse(result);
        }
    }
}