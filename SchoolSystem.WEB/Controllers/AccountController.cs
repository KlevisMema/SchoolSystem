using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        private readonly IOAuthService _oAuthService;
        private readonly IAccountService _accountService;
        private readonly StatusCodeResponse<RegisterViewModel, List<RegisterViewModel>> _registerStatusCodeResponse;

        /// <summary>
        /// Service Injection
        /// </summary>
        /// <param name="accountService">Account service</param>
        /// <param name="registerStatusCodeResponse">Register StatusCode response</param>
        /// <param name="oAuthService"></param>
        public AccountController
        (
            IOAuthService oAuthService,
            IAccountService accountService,
            StatusCodeResponse<RegisterViewModel, List<RegisterViewModel>> registerStatusCodeResponse
        )
        {
            _accountService = accountService;
            _registerStatusCodeResponse = registerStatusCodeResponse;
            _oAuthService = oAuthService;
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

            var result = await _accountService.Register(register);

            return _registerStatusCodeResponse.ControllerResponse(result);
        }

        /// <summary>
        /// Login a user
        /// </summary>
        /// <param name="logIn">Login data object</param>
        [AllowAnonymous]
        [HttpPost("Login")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<IActionResult> LogIn
        (
            [FromForm] LoginViewModel logIn
        )
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var loginResult = await _accountService.Login(logIn);

            if (loginResult.Success)
                return Ok(await _oAuthService.CreateToken(logIn));

            return BadRequest(loginResult.Message);
        }
    }
}