#region Usings

using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.DTO.ViewModels.Exam;

#endregion

namespace SchoolSystem.BLL.MediatrService.Actions.Exam.Commands
{
    /// <summary>
    ///     Create exam commad class which inherit from IRequest that holds an object result as a response.
    /// </summary>
    public class CreateExamCommand : IRequest<ObjectResult>
    {
        /// <summary>
        ///     Create or update exam view model object 
        /// </summary>
        public CreateUpdateExamViewModel _createExam { get; set; }

        /// <summary>
        ///     Instansiate CreateExamCommand passing the CreateUpdateExamViewModel object
        /// </summary>
        /// <param name="createExam"> Create or update exam view model object passed to the constructor </param>
        public CreateExamCommand
        (
            CreateUpdateExamViewModel createExam
        )
        {
            _createExam = createExam;
        }
    }
}