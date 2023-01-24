#region Usings

using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.DTO.ViewModels.Account;

#endregion

namespace SchoolSystem.BLL.MediatrService.Actions.Authentication.Commands
{
    /// <summary>
    ///     Register user command class which inehrits from IRequest with response ObjectResult
    /// </summary>
    public class RegisterUserCommand : IRequest<ObjectResult>
    {
        /// <summary>
        ///    Register View Model object
        /// </summary>
        public RegisterViewModel RegisterViewModel { get; set; }

        /// <summary>
        ///     Instansiate RegisterUserCommand with RegisterViewModel object as parameter
        /// </summary>
        /// <param name="registerViewModel"> Register View Model passed to the constructor </param>
        public RegisterUserCommand
        (
            RegisterViewModel registerViewModel
        )
        {
            RegisterViewModel = registerViewModel;
        }
    }
}