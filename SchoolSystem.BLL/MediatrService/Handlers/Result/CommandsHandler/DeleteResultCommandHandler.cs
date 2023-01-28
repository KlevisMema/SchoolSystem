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
    ///     Delete result command handler class which implements IRequestHandler which gets the get delete result command and object result as response 
    /// </summary>
    public class DeleteResultCommandHandler : IRequestHandler<DeleteResultCommand, ObjectResult>
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
        public DeleteResultCommandHandler
        (
           ICrudService<ResultViewModel, CreateUpdateResultViewModel> resultService,
           IControllerStatusCodeResponse<ResultViewModel, List<ResultViewModel>> statusCodeResponse
        )
        {
            _resultService = resultService;
            _statusCodeResponse = statusCodeResponse;
        }

        /// <summary>
        ///     Handle the delete result command
        /// </summary>
        /// <param name="request"> Request parameters </param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> A Object result response </returns>
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