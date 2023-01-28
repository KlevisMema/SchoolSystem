#region Usings

using MediatR;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace SchoolSystem.BLL.MediatrService.Queries.Subject.Commands
{
    /// <summary>
    ///     Delete subject commad class which inherit from IRequest that holds an object result as a response.
    /// </summary>
    public class DeleteSubjectCommand : IRequest<ObjectResult>
    {
        /// <summary>
        ///     Id of the subject 
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        ///    Instansiate DeleteSubjectCommand passing the subject Id as parameter 
        /// </summary>
        /// <param name="id"> Id of the subject passed to the constructor </param>
        public DeleteSubjectCommand
        (
            Guid id
        )
        {
            Id = id;
        }
    }
}