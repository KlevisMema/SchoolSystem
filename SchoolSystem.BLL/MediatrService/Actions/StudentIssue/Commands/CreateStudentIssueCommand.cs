#region Usings

using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.DTO.ViewModels.StudentIssues;

#endregion

namespace SchoolSystem.BLL.MediatrService.Actions.StudentIssue.Commands
{
    /// <summary>
    ///     Create student issue commad class which inherit from IRequest that holds an object result as a response.
    /// </summary>
    public class CreateStudentIssueCommand : IRequest<ObjectResult>
    {
        /// <summary>
        ///     Create or update student issue view model object 
        /// </summary>
        public CreateUpdateStudentIssueViewModel _createStudentIssue { get; set; }

        /// <summary>
        ///     Instansiate CreateUpdateStudentIssueViewModel passing the CreateUpdateStudentIssueViewModel object
        /// </summary>
        /// <param name="createStudentIssue"> Create or update student issue view model object passed to the constructor </param>
        public CreateStudentIssueCommand
        (
            CreateUpdateStudentIssueViewModel createStudentIssue
        )
        {
            _createStudentIssue = createStudentIssue;
        }
    }
}