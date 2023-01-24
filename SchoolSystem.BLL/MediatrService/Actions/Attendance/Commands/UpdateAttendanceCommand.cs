#region Usings

using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.DTO.ViewModels.Attendance;

#endregion

namespace SchoolSystem.BLL.MediatrService.Actions.Attendance.Commands
{
    /// <summary>
    ///     Update attendance commad class which inherit from IRequest that holds an object result as a response.
    /// </summary>
    public class UpdateAttendanceCommand : IRequest<ObjectResult>
    {
        /// <summary>
        ///     Id of the attendance 
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        ///     Create or update attendance view model object 
        /// </summary>
        public CreateUpdateAttendanceViewModel CreateUpdateAttendanceViewModel { get; set; }

        /// <summary>
        ///     Instansiate UpdateAttendanceCommand passing the CreateUpdateAttendanceViewModel object and attendance id as parameters
        /// </summary>
        /// <param name="createUpdateAttendanceViewModel"> Create or update attendance view model object passed to the constructor </param>
        /// <param name="id"> Id of the attendance passed to the constructor </param>
        public UpdateAttendanceCommand
        (
            Guid id,
            CreateUpdateAttendanceViewModel createUpdateAttendanceViewModel
        )
        {
            Id = id;
            CreateUpdateAttendanceViewModel = createUpdateAttendanceViewModel;
        }
    }
}