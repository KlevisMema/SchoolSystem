#region Uisngs

using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.DTO.ViewModels.TimeTable;

#endregion

namespace SchoolSystem.BLL.MediatrService.Actions.TimeTable.Commands
{
    /// <summary>
    ///     Create time table commad class which inherit from IRequest that holds an object result as a response.
    /// </summary>
    public class CreateTimeTableCommand : IRequest<ObjectResult>
    {
        /// <summary>
        ///     Create or update time table view model object 
        /// </summary>
        public CreateUpdateTimeTableViewModel _createTimeTable { get; set; }

        /// <summary>
        ///     Instansiate CreateTimeTableCommand passing the CreateUpdateTimeTableViewModel object
        /// </summary>
        /// <param name="createTimeTable"> Create or update time table view model object passed to the constructor </param>
        public CreateTimeTableCommand
        (
            CreateUpdateTimeTableViewModel createTimeTable
        )
        {
            _createTimeTable = createTimeTable;
        }
    }
}