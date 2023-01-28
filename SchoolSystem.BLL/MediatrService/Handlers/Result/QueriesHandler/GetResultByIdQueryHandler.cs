#region Usings

using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.DTO.ViewModels.Result;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.MediatrService.Actions.Result.Queries; 

#endregion

namespace SchoolSystem.BLL.MediatrService.Handlers.Result.QueriesHandler
{
    /// <summary>
    ///     Get result query handler class which implements IRequestHandler which gets the get result query and object result as response 
    /// </summary>
    public class GetResultByIdQueryHandler : IRequestHandler<GetResultByIdQuery, ObjectResult>
    {
        /// <summary>
        ///     ICrudService interface 
        /// </summary>
        private readonly ICrudService<ResultViewModel, CreateUpdateResultViewModel> _resultService;
        /// <summary>
        ///     IControllerStatusCodeResponse interface
        /// </summary>
        private readonly IControllerStatusCodeResponse<ResultViewModel, List<ResultViewModel>> _statusCodeResponse;

        /// <summary>
        ///     Services injection
        /// </summary>
        /// <param name="resultService"> Result service  </param>
        /// <param name="statusCodeResponse"> Status code service </param>
        public GetResultByIdQueryHandler
        (
           ICrudService<ResultViewModel, CreateUpdateResultViewModel> resultService,
           IControllerStatusCodeResponse<ResultViewModel, List<ResultViewModel>> statusCodeResponse
        )
        {
            _resultService = resultService;
            _statusCodeResponse = statusCodeResponse;
        }

        /// <summary>
        ///     Handle the get result by id query
        /// </summary>
        /// <param name="request"> Request parameters </param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> A Object result response </returns>
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