#region Usings

using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.DTO.ViewModels.Issue;

#endregion

namespace SchoolSystem.BLL.MediatrService.Actions.Issues.Commands
{
    /// <summary>
    ///     Update issue commad class which inherit from IRequest that holds an object result as a response.
    /// </summary>
    public class UpdateIssueCommand : IRequest<ObjectResult>
    {
        /// <summary>
        ///     Id of the issue 
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        ///     Create or update issue view model object 
        /// </summary>
        public CreateUpdateIssueViewModel _updateIssue { get; set; }

        /// <summary>
        ///     Instansiate UpdateIssueCommand passing the CreateUpdateIssueViewModel object and issue id as parameters
        /// </summary>
        /// <param name="createUpdateAttendanceViewModel"> Create or update issue view model object passed to the constructor </param>
        /// <param name="id"> Id of the issue passed to the constructor </param>
        public UpdateIssueCommand
        (
            Guid id,
            CreateUpdateIssueViewModel updateIssue
        )
        {
            Id = id;
            _updateIssue = updateIssue;
        }
    }
}