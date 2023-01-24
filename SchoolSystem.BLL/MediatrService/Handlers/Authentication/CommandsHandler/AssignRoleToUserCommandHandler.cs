#region Usings

using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.BLL.MediatrService.Actions.Authentication.Commands;

#endregion

namespace SchoolSystem.BLL.MediatrService.Handlers.Authentication.CommandsHandler
{
    /// <summary>
    ///    Assign role to user command handler class which implements IRequestHandler which gets the assign role to user command and object result as response 
    /// </summary>
    public class AssignRoleToUserCommandHandler : IRequestHandler<AssignRoleToUserCommand, ObjectResult>
    {
        /// <summary>
        ///     IAccountService interface 
        /// </summary>
        private readonly IAccountService _accountService;
        /// <summary>
        ///     IControllerStatusCodeResponse interface
        /// </summary>
        private readonly IControllerStatusCodeResponse<string, List<string>> _statusCodeResponse;

        /// <summary>
        ///     Inject services in the controller
        /// </summary>
        /// <param name="accountService"> Account service </param>
        /// <param name="statusCodeResponse"> Status code response </param>
        public AssignRoleToUserCommandHandler
        (
            IAccountService accountService,
            IControllerStatusCodeResponse<string, List<string>> statusCodeResponse
        )
        {
            _accountService = accountService;
            _statusCodeResponse = statusCodeResponse;
        }

        /// <summary>
        ///     Handle the assign role to user command
        /// </summary>
        /// <param name="request"> Request parameters </param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns></returns>
        public async Task<ObjectResult> Handle
        (
            AssignRoleToUserCommand request,
            CancellationToken cancellationToken
        )
        {
            var assignRoleToUser = await _accountService.AssignRoleToUser(request.UserId, request.RoleId);

            return _statusCodeResponse.ControllerResponse(assignRoleToUser);
        }
    }
}
