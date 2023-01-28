#region Usings

using MediatR;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace SchoolSystem.BLL.MediatrService.Actions.Clasroom.Commands
{
    /// <summary>
    ///     Delete clasroom commad class which inherit from IRequest that holds an object result as a response.
    /// </summary>
    public class DeleteClasroomCommand : IRequest<ObjectResult>
    {
        /// <summary>
        ///     Id of the clasroom 
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        ///    Instansiate DeleteClasroomCommand passing the clasroom Id as parameter 
        /// </summary>
        /// <param name="id"> Id of the clasroom passed to the constructor </param>
        public DeleteClasroomCommand
        (
            Guid id
        )
        {
            Id = id;
        }
    }
}