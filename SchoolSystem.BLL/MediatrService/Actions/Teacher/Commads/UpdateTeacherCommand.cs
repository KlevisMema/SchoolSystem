#region Usings

using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.DTO.ViewModels.Teacher;

#endregion

namespace SchoolSystem.BLL.MediatrService.Actions.Teacher.Commads
{
    /// <summary>
    ///     Update teacher commad class which inherit from IRequest that holds an object result as a response.
    /// </summary>
    public class UpdateTeacherCommand : IRequest<ObjectResult>
    {
        /// <summary>
        ///     Id of the teacher 
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        ///     Create or update teacher view model object 
        /// </summary>
        public CreateUpdateTeacherViewModel _createUpdateTeacherViewModel;

        /// <summary>
        ///     Instansiate UpdateTeacherCommand passing the CreateUpdateTeacherViewModel object and teacher id as parameters
        /// </summary>
        /// <param name="createUpdateTeacherViewModel"> Create or update teacher view model object passed to the constructor </param>
        /// <param name="id"> Id of the teacher passed to the constructor </param>
        public UpdateTeacherCommand
        (
            Guid id,
            CreateUpdateTeacherViewModel createUpdateTeacherViewModel
        )
        {
            Id = id;
            _createUpdateTeacherViewModel = createUpdateTeacherViewModel;
        }
    }
}