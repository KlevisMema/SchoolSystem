#region Usings

using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.DTO.ViewModels.Account;
using SchoolSystem.BLL.MediatrService.Actions.Authentication.Commands;

#endregion

namespace SchoolSystem.BLL.MediatrService.Handlers.Authentication.CommandsHandler
{
    /// <summary>
    ///     Register user command handler class which implements IRequestHandler which gets the register user command and object result as response 
    /// </summary>
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, ObjectResult>
    {
        /// <summary>
        ///     IAccountService interface 
        /// </summary>
        private readonly IAccountService _accountService;
        /// <summary>
        ///     IControllerStatusCodeResponse interface
        /// </summary>
        private readonly IControllerStatusCodeResponse<RegisterViewModel, List<RegisterViewModel>> _statusCodeResponse;

        /// <summary>
        ///     Services injection
        /// </summary>
        /// <param name="accountService"> Account service  </param>
        /// <param name="statusCodeResponse"> Status code service </param>
        public RegisterUserCommandHandler
        (
            IAccountService accountService,
            IControllerStatusCodeResponse<RegisterViewModel, List<RegisterViewModel>> statusCodeResponse
        )
        {
            _accountService = accountService;
            _statusCodeResponse = statusCodeResponse;
        }

        /// <summary>
        ///     Handle the register user command
        /// </summary>
        /// <param name="request"> Request parameters </param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> A Object result response </returns>
        public async Task<ObjectResult> Handle
        (
            RegisterUserCommand request,
            CancellationToken cancellationToken
        )
        {
            var registerResult = await _accountService.Register(request.RegisterViewModel);

            return _statusCodeResponse.ControllerResponse(registerResult);
        }
    }
}
