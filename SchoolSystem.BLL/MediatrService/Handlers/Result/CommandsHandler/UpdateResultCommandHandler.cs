#region Usings

using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.DTO.ViewModels.Result;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.MediatrService.Actions.Result.Commands;

#endregion

namespace SchoolSystem.BLL.MediatrService.Handlers.Result.CommandsHandler
{
    /// <summary>
    ///     Update result command handler class which implements IRequestHandler which gets the get update result command and object result as response 
    /// </summary>
    public class UpdateResultCommandHandler : IRequestHandler<UpdateResultCommand, ObjectResult>
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
        public UpdateResultCommandHandler
        (
           ICrudService<ResultViewModel, CreateUpdateResultViewModel> resultService,
           IControllerStatusCodeResponse<ResultViewModel, List<ResultViewModel>> statusCodeResponse
        )
        {
            _resultService = resultService;
            _statusCodeResponse = statusCodeResponse;
        }

        /// <summary>
        ///     Handle the get result query
        /// </summary>
        /// <param name="request"> Request parameters </param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> A Object result response </returns>
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