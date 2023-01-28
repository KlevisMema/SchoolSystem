#region Usings

using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.DTO.ViewModels.Account;

#endregion

namespace SchoolSystem.BLL.MediatrService.Actions.Authentication.Commands
{
    /// <summary>
    ///     Log in user command class which inehrits from IRequest with response ObjectResult
    /// </summary>
    public class LoginUserCommand : IRequest<ObjectResult>
    {
        /// <summary>
        ///     Login view model object
        /// </summary>
        public LoginViewModel LoginViewModel { get; set; }

        /// <summary>
        ///     Instansiate LoginUserCommand with LoginViewModel object as parameter
        /// </summary>
        /// <param name="loginViewModel"> Login view model passed to the constructor </param>
        public LoginUserCommand
        (
            LoginViewModel loginViewModel
        )
        {
            LoginViewModel = loginViewModel;
        }
    }
}