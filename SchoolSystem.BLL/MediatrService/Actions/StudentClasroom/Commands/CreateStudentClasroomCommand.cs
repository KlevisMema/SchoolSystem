#region Usings

using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.DTO.ViewModels.StudentClasroom;

#endregion

namespace SchoolSystem.BLL.MediatrService.Actions.StudentClasroom.Commands
{
    /// <summary>
    ///     Create student clasroom commad class which inherit from IRequest that holds an object result as a response.
    /// </summary>
    public class CreateStudentClasroomCommand : IRequest<ObjectResult>
    {
        /// <summary>
        ///     Create or update student clasroom view model object 
        /// </summary>
        public CreateUpdateStudentClasroomViewModel _createStudentClasroom { get; set; }

        /// <summary>
        ///     Instansiate CreateStudentClasroomCommand passing the CreateUpdateStudentClasroomViewModel object
        /// </summary>
        /// <param name="createStudentClasroom"> Create or update student clasroom view model object passed to the constructor </param>
        public CreateStudentClasroomCommand
        (
            CreateUpdateStudentClasroomViewModel createStudentClasroom
        )
        {
            _createStudentClasroom = createStudentClasroom;
        }
    }
}