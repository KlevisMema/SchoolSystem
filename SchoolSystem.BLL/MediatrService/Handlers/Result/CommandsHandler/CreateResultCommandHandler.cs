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
    ///     Create result command handler class which implements IRequestHandler which gets the get create result command and object result as response 
    /// </summary>
    public class CreateResultCommandHandler : IRequestHandler<CreateResultCommand, ObjectResult>
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
        public CreateResultCommandHandler
        (
           ICrudService<ResultViewModel, CreateUpdateResultViewModel> resultService,
           IControllerStatusCodeResponse<ResultViewModel, List<ResultViewModel>> statusCodeResponse
        )
        {
            _resultService = resultService;
            _statusCodeResponse = statusCodeResponse;
        }

        /// <summary>
        ///     Handle the create result command
        /// </summary>
        /// <param name="request"> Request parameters </param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> A Object result response </returns>
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