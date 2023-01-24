#region Usings

using MediatR;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace SchoolSystem.BLL.MediatrService.Actions.Exam.Commands
{
    /// <summary>
    ///     Delete exam commad class which inherit from IRequest that holds an object result as a response.
    /// </summary>
    public class DeleteExamCommand : IRequest<ObjectResult>
    {
        /// <summary>
        ///     Id of the exam 
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        ///    Instansiate DeleteExamCommand passing the exam Id as parameter 
        /// </summary>
        /// <param name="id"> Id of the exam passed to the constructor </param>
        public DeleteExamCommand
        (
            Guid id
        )
        {
            Id = id;
        }
    }
}