#region Usings

using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.DTO.ViewModels.Exam;

#endregion

namespace SchoolSystem.BLL.MediatrService.Actions.Exam.Commands
{
    /// <summary>
    ///     Update exam commad class which inherit from IRequest that holds an object result as a response.
    /// </summary>
    public class UpdateExamCommand : IRequest<ObjectResult>
    {
        /// <summary>
        ///     Id of the exam 
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        ///     Create or update exam view model object 
        /// </summary>
        public CreateUpdateExamViewModel _updateExam { get; set; }

        /// <summary>
        ///     Instansiate UpdateExamCommand passing the CreateUpdateExamViewModel object and exam id as parameters
        /// </summary>
        /// <param name="updateExam"> Create or update exam view model object passed to the constructor </param>
        /// <param name="id"> Id of the exam passed to the constructor </param>
        public UpdateExamCommand
        (
            Guid id,
            CreateUpdateExamViewModel updateExam
        )
        {
            Id = id;
            _updateExam = updateExam;
        }
    }
}