#region Uisngs

using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.DTO.ViewModels.TimeTable;

#endregion

namespace SchoolSystem.BLL.MediatrService.Actions.TimeTable.Commands
{
    /// <summary>
    ///     Update time table commad class which inherit from IRequest that holds an object result as a response.
    /// </summary>
    public class UpdateTimeTableCommand : IRequest<ObjectResult>
    {
        /// <summary>
        ///     Id of the time table 
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        ///     Create or update time table view model object 
        /// </summary>
        public CreateUpdateTimeTableViewModel _updateTimeTable { get; set; }

        /// <summary>
        ///     Instansiate UpdateTimeTableCommand passing the CreateUpdateTimeTableViewModel object and time table id as parameters
        /// </summary>
        /// <param name="updateTimeTable"> Create or update time table view model object passed to the constructor </param>
        /// <param name="id"> Id of the time table passed to the constructor </param>
        public UpdateTimeTableCommand
        (
            Guid id,
            CreateUpdateTimeTableViewModel updateTimeTable
        )
        {
            Id = id;
            _updateTimeTable = updateTimeTable;
        }
    }
}