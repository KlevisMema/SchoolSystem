#region Usings

using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.DTO.ViewModels.Result;

#endregion

namespace SchoolSystem.BLL.MediatrService.Actions.Result.Commands
{
    /// <summary>
    ///     Create result commad class which inherit from IRequest that holds an object result as a response.
    /// </summary>
    public class CreateResultCommand : IRequest<ObjectResult>
    {
        /// <summary>
        ///     Create or update result view model object 
        /// </summary>
        public CreateUpdateResultViewModel _createResult { get; set; }

        /// <summary>
        ///     Instansiate CreateResultCommand passing the CreateUpdateResultViewModel object
        /// </summary>
        /// <param name="createUpdateAttendanceViewModel"> Create or update result view model object passed to the constructor </param>
        public CreateResultCommand
        (
            CreateUpdateResultViewModel createResult
        )
        {
            _createResult = createResult;
        }
    }
}