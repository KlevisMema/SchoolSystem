#region Usings

using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.DTO.ViewModels.Clasroom;

#endregion

namespace SchoolSystem.BLL.MediatrService.Actions.Clasroom.Commands
{
    /// <summary>
    ///     Create clasroom commad class which inherit from IRequest that holds an object result as a response.
    /// </summary>
    public class CreateClasroomCommand : IRequest<ObjectResult>
    {
        /// <summary>
        ///     Create or update clasroom view model object 
        /// </summary>
        public CreateUpdateClasroomViewModel _createClasroom { get; set; }

        /// <summary>
        ///     Instansiate CreateClasroomCommand passing the CreateUpdateClasroomViewModel object
        /// </summary>
        /// <param name="createClasroom"> Create or update clasroom view model object passed to the constructor </param>
        public CreateClasroomCommand
        (
            CreateUpdateClasroomViewModel createClasroom
        )
        {
            _createClasroom = createClasroom;
        }
    }
}