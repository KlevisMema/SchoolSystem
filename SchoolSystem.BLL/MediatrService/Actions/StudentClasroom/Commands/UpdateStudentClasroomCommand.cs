#region Usings

using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.DTO.ViewModels.StudentClasroom;

#endregion

namespace SchoolSystem.BLL.MediatrService.Actions.StudentClasroom.Commands
{
    /// <summary>
    ///     Update student clasroom commad class which inherit from IRequest that holds an object result as a response.
    /// </summary>
    public class UpdateStudentClasroomCommand : IRequest<ObjectResult>
    {
        /// <summary>
        ///     Id of the student clasroom 
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        ///     Create or update student clasroom view model object 
        /// </summary>
        public CreateUpdateStudentClasroomViewModel _updateStudentClasroom { get; set; }

        /// <summary>
        ///     Instansiate UpdateStudentClasroomCommand passing the CreateUpdateStudentClasroomViewModel object and student clasroom id as parameters
        /// </summary>
        /// <param name="updateStudentClasroom"> Create or update student clasroom view model object passed to the constructor </param>
        /// <param name="id"> Id of the student clasroom passed to the constructor </param>
        public UpdateStudentClasroomCommand
        (
            Guid id,
            CreateUpdateStudentClasroomViewModel updateStudentClasroom
        )
        {
            Id = id;
            _updateStudentClasroom = updateStudentClasroom;
        }
    }
}