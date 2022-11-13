using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SchoolSystem.API.ControllerRespose;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.DTO.ViewModels.Account;

namespace SchoolSystem.API.Controllers
{
    /// <summary>
    /// Account API Controller
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly StatusCodeResponse<LoginViewModel, List<LoginViewModel>> _loginStatusCodeResponse;
        private readonly StatusCodeResponse<RegisterViewModel, List<RegisterViewModel>> _registerStatusCodeResponse;

        /// <summary>
        /// Service Injection
        /// </summary>
        /// <param name="accountService">Account service</param>
        /// <param name="registerStatusCodeResponse">Register StatusCode response</param>
        /// <param name="loginStatusCodeResponse">Login StatusCode response</param>
        public AccountController
        (
            IAccountService accountService,
            StatusCodeResponse<LoginViewModel, List<LoginViewModel>> loginStatusCodeResponse,
            StatusCodeResponse<RegisterViewModel, List<RegisterViewModel>> registerStatusCodeResponse
        )
        {
            _accountService = accountService;
            _loginStatusCodeResponse = loginStatusCodeResponse;
            _registerStatusCodeResponse = registerStatusCodeResponse;
        }

        /// <summary>
        /// Register a user 
        /// </summary>
        /// <param name="register">Register data object</param>
        [AllowAnonymous]
        [HttpPost("Register")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<IActionResult> Register
        (
            [FromForm] RegisterViewModel register
        )
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var registerResult = await _accountService.Register(register);

            return _registerStatusCodeResponse.ControllerResponse(registerResult);
        }

        /// <summary>
        /// Login a user
        /// </summary>
        /// <param name="logIn">Login data object</param>
        [AllowAnonymous]
        [HttpPost("Login")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<IActionResult> LogIn
        (
            [FromForm] LoginViewModel logIn
        )
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var loginResult = await _accountService.Login(logIn);

            return _loginStatusCodeResponse.ControllerResponse(loginResult);
        }
    }
}