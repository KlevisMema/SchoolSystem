#region Usings

using MediatR;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace SchoolSystem.BLL.MediatrService.Actions.Result.Commands
{
    /// <summary>
    ///     Delete result commad class which inherit from IRequest that holds an object result as a response.
    /// </summary>
    public class DeleteResultCommand : IRequest<ObjectResult>
    {
        /// <summary>
        ///     Id of the result 
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        ///    Instansiate DeleteResultCommand passing the result Id as parameter 
        /// </summary>
        /// <param name="id"> Id of the result passed to the constructor </param>
        public DeleteResultCommand
        (
            Guid id
        )
        {
            Id = id;
        }
    }
}