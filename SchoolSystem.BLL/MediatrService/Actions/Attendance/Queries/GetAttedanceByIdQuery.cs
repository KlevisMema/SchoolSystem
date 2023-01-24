#region Usings

using MediatR;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace SchoolSystem.BLL.MediatrService.Actions.Attendance.Queries
{
    /// <summary>
    ///      Get attendance query class which inherit from IRequest that holds an object result as a response.
    /// </summary>
    public class GetAttedanceByIdQuery : IRequest<ObjectResult>
    {
        /// <summary>
        ///     Id of the attendance 
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        ///     Instansiate GetAttedanceByIdQuery passing the attendance id as parameter
        /// </summary>
        /// <param name="id"> Id of the attendance passed to the constructor </param>
        public GetAttedanceByIdQuery
        (
            Guid id
        )
        {
            Id = id;
        }
    }
}