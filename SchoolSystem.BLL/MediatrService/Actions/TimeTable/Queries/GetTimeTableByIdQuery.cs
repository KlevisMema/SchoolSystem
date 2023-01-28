#region Usings

using MediatR;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace SchoolSystem.BLL.MediatrService.Actions.TimeTable.Queries
{
    /// <summary>
    ///      Get time table query class which inherit from IRequest that holds an object result as a response.
    /// </summary>
    public class GetTimeTableByIdQuery : IRequest<ObjectResult>
    {
        /// <summary>
        ///     Id of the time table 
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        ///     Instansiate GetTimeTableByIdQuery passing the time table id as parameter
        /// </summary>
        /// <param name="id"> Id of the time table passed to the constructor </param>
        public GetTimeTableByIdQuery
        (
            Guid id
        )
        {
            Id = id;
        }
    }
}