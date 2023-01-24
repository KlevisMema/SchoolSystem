#region Usings

using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SchoolSystem.DTO.ViewModels.Account;
using SchoolSystem.BLL.MediatrService.Actions.Authentication.Commands;
using SchoolSystem.BLL.MediatrService.Actions.Authentication.Queries;

#endregion

namespace SchoolSystem.API.Controllers
{
    /// <summary>
    ///     Account API Controller
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {



        #region Services 

        /// <summary>
        ///     Mediator
        /// </summary>
        private readonly IMediator mediator;

        /// <summary>
        ///     Service Injection
        /// </summary>
        /// <param name="mediator"> Mediator service </param>
        public AccountController
        (
            IMediator mediator
        )
        {
            this.mediator = mediator;
        }

        #endregion

        #region Register 

        /// <summary>
        ///     Register a user 
        /// </summary>
        /// <param name="register">Register data object</param>
        /// <param name="cancellationToken"> Cancellation token </param>

        [AllowAnonymous]
        [HttpPost("Register")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<IActionResult> Register
        (
            [FromForm] RegisterViewModel register,
            CancellationToken cancellationToken
        )
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var registerCommand = new RegisterUserCommand(register);
            var result = await mediator.Send(registerCommand, cancellationToken);

            return result;

        }

        #endregion

        #region Login

        /// <summary>
        ///     Login a user
        /// </summary>
        /// <param name="logIn"> Login data object </param>
        /// <param name="cancellationToken"> Cancellation token </param>

        [AllowAnonymous]
        [HttpPost("Login")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<IActionResult> LogIn
        (
            [FromForm] LoginViewModel logIn,
            CancellationToken cancellationToken
        )
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var loginCommand = new LoginUserCommand(logIn);
            var result = await mediator.Send(loginCommand, cancellationToken);

            return result;
        }

        #endregion

        #region Get all roles endpoint

        /// <summary>
        ///     Get all roles 
        /// </summary>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> A list of roles with role id and role name </returns>

        [HttpGet("GetAllRoles")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<IActionResult> GetAllRoles(CancellationToken cancellationToken = default)
        {
            var getAllQuery = new GetAllRolesQuery();
            var result = await mediator.Send(getAllQuery, cancellationToken);

            return result;
        }

        #endregion

        [HttpPost("AssignRoleToNewUser")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<IActionResult> TeacherOrStudent
        (
            Guid Id
        )
        {
            return NoContent();
        }

    }
}