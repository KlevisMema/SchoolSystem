#region Usings

using MediatR;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace SchoolSystem.BLL.MediatrService.Actions.Clasroom.Queries
{
    /// <summary>
    ///      Get clasroom query class which inherit from IRequest that holds an object result as a response.
    /// </summary>
    public class GetClasroomsByIdQuery : IRequest<ObjectResult>
    {
        /// <summary>
        ///     Id of the clasroom 
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        ///     Instansiate GetClasroomsByIdQuery passing the clasroom id as parameter
        /// </summary>
        /// <param name="id"> Id of the clasroom passed to the constructor </param>
        public GetClasroomsByIdQuery
        (
            Guid id
        )
        {
            Id = id;
        }
    }
}