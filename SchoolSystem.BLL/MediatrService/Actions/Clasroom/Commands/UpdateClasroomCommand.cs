#region Usings

using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.DTO.ViewModels.Clasroom;

#endregion

namespace SchoolSystem.BLL.MediatrService.Actions.Clasroom.Commands
{
    /// <summary>
    ///     Update clasroom commad class which inherit from IRequest that holds an object result as a response.
    /// </summary>
    public class UpdateClasroomCommand : IRequest<ObjectResult>
    {
        /// <summary>
        ///     Id of the clasroom 
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        ///     Create or update clasroom view model object 
        /// </summary>
        public CreateUpdateClasroomViewModel _updateClasroom { get; set; }


        /// <summary>
        ///     Instansiate UpdateClasroomCommand passing the CreateUpdateClasroomViewModel object and clasroom id as parameters
        /// </summary>
        /// <param name="updateClasroom"> Create or update clasroom view model object passed to the constructor </param>
        /// <param name="id"> Id of the clasroom passed to the constructor </param>
        public UpdateClasroomCommand
        (
            Guid id,
            CreateUpdateClasroomViewModel updateClasroom
        )
        {
            Id = id;
            _updateClasroom = updateClasroom;
        }
    }
}