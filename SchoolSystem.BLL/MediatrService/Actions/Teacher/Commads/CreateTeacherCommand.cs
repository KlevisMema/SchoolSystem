#region Usings

using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.DTO.ViewModels.Teacher;

#endregion

namespace SchoolSystem.BLL.MediatrService.Actions.Teacher.Commads
{
    /// <summary>
    ///     Create teacher commad class which inherit from IRequest that holds an object result as a response.
    /// </summary>
    public class CreateTeacherCommand : IRequest<ObjectResult>
    {
        /// <summary>
        ///     Create or update teacher view model object 
        /// </summary>
        public CreateUpdateTeacherViewModel _createUpdateTeacherViewModel;

        /// <summary>
        ///     Instansiate CreateTeacherCommand passing the CreateUpdateTeacherViewModel object
        /// </summary>
        /// <param name="createUpdateTeacherViewModel"> Create or update teacher view model object passed to the constructor </param>
        public CreateTeacherCommand
        (
            CreateUpdateTeacherViewModel createUpdateTeacherViewModel
        )
        {
            _createUpdateTeacherViewModel = createUpdateTeacherViewModel;
        }
    }
}