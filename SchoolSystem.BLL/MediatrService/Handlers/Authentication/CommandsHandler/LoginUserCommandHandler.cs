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
    ///     Login user command handler class which implements IRequestHandler which gets the login user command and object result as response 
    /// </summary>
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, ObjectResult>
    {
        /// <summary>
        ///     IAccountService interface 
        /// </summary>
        private readonly IAccountService _accountService;
        /// <summary>
        ///     IControllerStatusCodeResponse interface
        /// </summary>
        private readonly IControllerStatusCodeResponse<LoginViewModel, List<LoginViewModel>> _statusCodeResponse;

        /// <summary>
        ///     Services injection
        /// </summary>
        /// <param name="accountService"> Account service  </param>
        /// <param name="statusCodeResponse"> Status code service </param>
        public LoginUserCommandHandler
        (
            IAccountService accountService,
            IControllerStatusCodeResponse<LoginViewModel, List<LoginViewModel>> statusCodeResponse
        )
        {
            _statusCodeResponse = statusCodeResponse;
            _accountService = accountService;
        }

        /// <summary>
        ///     Handle the login user command
        /// </summary>
        /// <param name="request"> Request parameters </param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> A Object result response </returns>
        public async Task<ObjectResult> Handle
        (
            LoginUserCommand request,
            CancellationToken cancellationToken
        )
        {
            var loginResult = await _accountService.Login(request.LoginViewModel);

            return _statusCodeResponse.ControllerResponse(loginResult);
        }
    }
}