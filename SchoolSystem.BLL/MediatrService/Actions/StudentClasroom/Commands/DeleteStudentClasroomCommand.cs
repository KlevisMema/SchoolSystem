#region Usings

using MediatR;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace SchoolSystem.BLL.MediatrService.Actions.StudentClasroom.Commands
{
    /// <summary>
    ///     Delete student clasroom commad class which inherit from IRequest that holds an object result as a response.
    /// </summary>
    public class DeleteStudentClasroomCommand : IRequest<ObjectResult>
    {
        /// <summary>
        ///     Id of the student clasroom 
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        ///    Instansiate DeleteStudentClasroomCommand passing the student clasroom Id as parameter 
        /// </summary>
        /// <param name="id"> Id of the student clasroom passed to the constructor </param>
        public DeleteStudentClasroomCommand
        (
            Guid id
        )
        {
            Id = id;
        }
    }
}