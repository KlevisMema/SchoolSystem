#region Usings

using MediatR;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace SchoolSystem.BLL.MediatrService.Actions.TimeTable.Commands
{
    /// <summary>
    ///     Delete time table commad class which inherit from IRequest that holds an object result as a response.
    /// </summary>
    public class DeleteTimeTableCommand : IRequest<ObjectResult>
    {
        /// <summary>
        ///     Id of the time table 
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        ///    Instansiate DeleteTimeTableCommand passing the time table Id as parameter 
        /// </summary>
        /// <param name="id"> Id of the time table passed to the constructor </param>
        public DeleteTimeTableCommand
        (
            Guid id
        )
        {
            Id = id;
        }
    }
}