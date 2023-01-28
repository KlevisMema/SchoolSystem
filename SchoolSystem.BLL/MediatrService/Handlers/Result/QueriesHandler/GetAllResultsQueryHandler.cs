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
    ///     Get results query handler class which implements IRequestHandler which gets the get results query and object result as response 
    /// </summary>
    public class GetAllResultsQueryHandler : IRequestHandler<GetAllResultsQuery, ObjectResult>
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
        public GetAllResultsQueryHandler
        (
           ICrudService<ResultViewModel, CreateUpdateResultViewModel> resultService,
           IControllerStatusCodeResponse<ResultViewModel, List<ResultViewModel>> statusCodeResponse
        )
        {
            _resultService = resultService;
            _statusCodeResponse = statusCodeResponse;
        }

        /// <summary>
        ///     Handle the get results query
        /// </summary>
        /// <param name="request"> Request parameters </param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> A Object result response </returns>
        public async Task<ObjectResult> Handle
        (
            GetAllResultsQuery request,
            CancellationToken cancellationToken
        )
        {
            var results = await _resultService.GetRecords(cancellationToken);
            return _statusCodeResponse.ControllerResponse(results);
        }
    }
}