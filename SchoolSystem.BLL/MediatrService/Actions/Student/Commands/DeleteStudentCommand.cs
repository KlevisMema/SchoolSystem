#region Usings

using MediatR;
using Microsoft.AspNetCore.Mvc; 

#endregion

namespace SchoolSystem.BLL.MediatrService.Actions.Student.Commands
{
    /// <summary>
    ///     Delete student commad class which inherit from IRequest that holds an object result as a response.
    /// </summary>
    public class DeleteStudentCommand : IRequest<ObjectResult>
    {
        /// <summary>
        ///     Id of the student 
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        ///    Instansiate DeleteStudentCommand passing the student Id as parameter 
        /// </summary>
        /// <param name="id"> Id of the student passed to the constructor </param>
        public DeleteStudentCommand
        (
            Guid id
        )
        {
            Id = id;
        }
    }
}