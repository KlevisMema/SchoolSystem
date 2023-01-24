#region Usings

using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.DTO.ViewModels.Issue;

#endregion

namespace SchoolSystem.BLL.MediatrService.Actions.Issues.Commands
{
    /// <summary>
    ///     Create issue commad class which inherit from IRequest that holds an object result as a response.
    /// </summary>
    public class CreateIssueCommand : IRequest<ObjectResult>
    {
        /// <summary>
        ///     Create or update issue view model object 
        /// </summary>
        public CreateUpdateIssueViewModel _createIssue { get; set; }

        /// <summary>
        ///     Instansiate CreateIssueCommand passing the CreateUpdateIssueViewModel object
        /// </summary>
        /// <param name="createUpdateAttendanceViewModel"> Create or update issue view model object passed to the constructor </param>
        public CreateIssueCommand
        (
            CreateUpdateIssueViewModel createIssue
        )
        {
            _createIssue = createIssue;
        }
    }
}