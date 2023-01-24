#region Usings

using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.DTO.ViewModels.Account;
using SchoolSystem.BLL.MediatrService.Actions.Authentication.Queries;

#endregion

namespace SchoolSystem.BLL.MediatrService.Handlers.Authentication.QueriesHandler
{
    /// <summary>
    ///     Get roles query handler class which implements IRequestHandler which gets the get roles query and object result as response 
    /// </summary>
    public class GetAllRolesQueryHandler : IRequestHandler<GetAllRolesQuery, ObjectResult>
    {
        /// <summary>
        ///     IAccountService interface 
        /// </summary>
        private readonly IAccountService _accountService;
        /// <summary>
        ///     IControllerStatusCodeResponse interface
        /// </summary>
        private readonly IControllerStatusCodeResponse<RolesViewModel, List<RolesViewModel>> _statusCodeResponse;

        /// <summary>
        ///     Services injection
        /// </summary>
        /// <param name="accountService"> Account service  </param>
        /// <param name="statusCodeResponse"> Status code service </param>
        public GetAllRolesQueryHandler
        (
            IAccountService accountService,
            IControllerStatusCodeResponse<RolesViewModel, List<RolesViewModel>> statusCodeResponse
        )
        {
            _accountService = accountService;
            _statusCodeResponse = statusCodeResponse;
        }

        /// <summary>
        ///     Handle the get roles query
        /// </summary>
        /// <param name="request"> Request parameters </param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> A Object result response </returns>
        public async Task<ObjectResult> Handle
        (
            GetAllRolesQuery request,
            CancellationToken cancellationToken
        )
        {
            var getAllRoles = await _accountService.GetAllRoles(cancellationToken);

            return _statusCodeResponse.ControllerResponse(getAllRoles);

        }
    }
}