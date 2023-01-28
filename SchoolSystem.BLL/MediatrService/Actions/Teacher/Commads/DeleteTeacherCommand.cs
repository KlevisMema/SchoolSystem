#region Usings

using MediatR;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace SchoolSystem.BLL.MediatrService.Actions.Teacher.Commads
{
    /// <summary>
    ///     Delete teacher commad class which inherit from IRequest that holds an object result as a response.
    /// </summary>
    public class DeleteTeacherCommand : IRequest<ObjectResult>
    {
        /// <summary>
        ///     Id of the teacher 
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        ///    Instansiate DeleteTeacherCommand passing the teacher Id as parameter 
        /// </summary>
        /// <param name="id"> Id of the teacher passed to the constructor </param>
        public DeleteTeacherCommand
        (
            Guid id
        )
        {
            Id = id;
        }
    }
}