#region Usings

using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.DTO.ViewModels.Student;

#endregion

namespace SchoolSystem.BLL.MediatrService.Actions.Student.Commands
{
    /// <summary>
    ///     Update student commad class which inherit from IRequest that holds an object result as a response.
    /// </summary>
    public class UpdateStudentCommand : IRequest<ObjectResult>
    {
        /// <summary>
        ///     Id of the student 
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        ///     Create or update student view model object 
        /// </summary>
        public CreateUpdateStudentViewModel _CreateUpdateStudentViewModel { get; set; }

        /// <summary>
        ///     Instansiate UpdateStudentCommand passing the CreateUpdateStudentViewModel object and student id as parameters
        /// </summary>
        /// <param name="createUpdateStudentViewModel"> Create or update student view model object passed to the constructor </param>
        /// <param name="id"> Id of the student passed to the constructor </param>
        public UpdateStudentCommand
        (
            Guid id,
            CreateUpdateStudentViewModel createUpdateStudentViewModel
        )
        {
            Id = id;
            _CreateUpdateStudentViewModel = createUpdateStudentViewModel;
        }
    }
}