#region Usings

using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.DTO.ViewModels.StudentIssues;

#endregion

namespace SchoolSystem.BLL.MediatrService.Actions.StudentIssue.Commands
{
    /// <summary>
    ///     Update student issue commad class which inherit from IRequest that holds an object result as a response.
    /// </summary>
    public class UpdateStudentIssueCommand : IRequest<ObjectResult>
    {
        /// <summary>
        ///     Id of the student issue 
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        ///     Create or update student issue view model object 
        /// </summary>
        public CreateUpdateStudentIssueViewModel _updateStudentIssue { get; set; }

        /// <summary>
        ///     Instansiate UpdateStudentIssueCommand passing the CreateUpdateStudentIssueViewModel object and student issue id as parameters
        /// </summary>
        /// <param name="updateStudentIssue"> Create or update student issue view model object passed to the constructor </param>
        /// <param name="id"> Id of the student issue passed to the constructor </param>
        public UpdateStudentIssueCommand
        (
            Guid id,
            CreateUpdateStudentIssueViewModel updateStudentIssue
        )
        {
            Id = id;
            _updateStudentIssue = updateStudentIssue;
        }
    }
}