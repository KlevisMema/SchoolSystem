#region Usings

using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.DTO.ViewModels.Student;

#endregion

namespace SchoolSystem.BLL.MediatrService.Actions.Student.Commands
{
    /// <summary>
    ///     Create student commad class which inherit from IRequest that holds an object result as a response.
    /// </summary>
    public class CreateStudentCommad : IRequest<ObjectResult>
    {
        /// <summary>
        ///     Create or update student view model object 
        /// </summary>
        public CreateUpdateStudentViewModel _CreateUpdateStudentViewModel { get; set; }

        /// <summary>
        ///     Instansiate CreateStudentCommad passing the CreateUpdateStudentViewModel object
        /// </summary>
        /// <param name="createUpdateAttendanceViewModel"> Create or update student view model object passed to the constructor </param>
        public CreateStudentCommad
        (
            CreateUpdateStudentViewModel createUpdateStudentViewModel
        )
        {
            _CreateUpdateStudentViewModel = createUpdateStudentViewModel;
        }
    }
}