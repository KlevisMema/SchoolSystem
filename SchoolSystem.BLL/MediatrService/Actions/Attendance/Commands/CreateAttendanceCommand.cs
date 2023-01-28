#region Usings

using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.DTO.ViewModels.Attendance;

#endregion

namespace SchoolSystem.BLL.MediatrService.Actions.Attendance.Commands
{
    /// <summary>
    ///     Create attendance commad class which inherit from IRequest that holds an object result as a response.
    /// </summary>
    public class CreateAttendanceCommand : IRequest<ObjectResult>
    {
        /// <summary>
        ///     Create or update attendance view model object 
        /// </summary>
        public CreateUpdateAttendanceViewModel CreateUpdateAttendanceViewModel { get; set; }

        /// <summary>
        ///     Instansiate CreateAttendanceCommand passing the CreateUpdateAttendanceViewModel object
        /// </summary>
        /// <param name="createUpdateAttendanceViewModel"> Create or update attendance view model object passed to the constructor </param>
        public CreateAttendanceCommand
        (
            CreateUpdateAttendanceViewModel createUpdateAttendanceViewModel
        )
        {
            CreateUpdateAttendanceViewModel = createUpdateAttendanceViewModel;
        }
    }
}