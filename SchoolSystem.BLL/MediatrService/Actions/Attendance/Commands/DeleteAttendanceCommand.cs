#region Usings

using MediatR;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace SchoolSystem.BLL.MediatrService.Actions.Attendance.Commands
{
    /// <summary>
    ///     Delete attendance commad class which inherit from IRequest that holds an object result as a response.
    /// </summary>
    public class DeleteAttendanceCommand : IRequest<ObjectResult>
    {
        /// <summary>
        ///     Id of the attendance 
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        ///    Instansiate DeleteAttendanceCommand passing the attendance Id as parameter 
        /// </summary>
        /// <param name="id"> Id of the attendance passed to the constructor </param>
        public DeleteAttendanceCommand
        (
            Guid id
        )
        {
            Id = id;
        }
    }
}