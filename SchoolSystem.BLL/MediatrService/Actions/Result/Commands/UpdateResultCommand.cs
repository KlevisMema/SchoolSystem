#region Usings

using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.DTO.ViewModels.Result;

#endregion

namespace SchoolSystem.BLL.MediatrService.Actions.Result.Commands
{
    /// <summary>
    ///     Update result commad class which inherit from IRequest that holds an object result as a response.
    /// </summary>
    public class UpdateResultCommand : IRequest<ObjectResult>
    {
        /// <summary>
        ///     Id of the result 
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        ///     Create or update result view model object 
        /// </summary>
        public CreateUpdateResultViewModel _updateResult { get; set; }

        /// <summary>
        ///     Instansiate CreateUpdateResultViewModel passing the CreateUpdateResultViewModel object and result id as parameters
        /// </summary>
        /// <param name="createUpdateAttendanceViewModel"> Create or update result view model object passed to the constructor </param>
        /// <param name="id"> Id of the result passed to the constructor </param>
        public UpdateResultCommand
        (
            Guid id,
            CreateUpdateResultViewModel updateResult
        )
        {
            Id = id;
            _updateResult = updateResult;
        }
    }
}