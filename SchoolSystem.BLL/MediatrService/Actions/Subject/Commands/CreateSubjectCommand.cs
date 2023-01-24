#region Usings

using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.DTO.ViewModels.Subject;

#endregion

namespace SchoolSystem.BLL.MediatrService.Queries.Subject.Commands
{
    /// <summary>
    ///     Create subject commad class which inherit from IRequest that holds an object result as a response.
    /// </summary>
    public class CreateSubjectCommand : IRequest<ObjectResult>
    {
        /// <summary>
        ///     Create or update subject view model object 
        /// </summary>
        public CreateUpdateSubjectViewModel _createUpdateSubjectViewModel;

        /// <summary>
        ///     Instansiate CreateSubjectCommand passing the CreateUpdateSubjectViewModel object
        /// </summary>
        /// <param name="createUpdateSubjectViewModel"> Create or update subject view model object passed to the constructor </param>
        public CreateSubjectCommand
        (
            CreateUpdateSubjectViewModel createUpdateSubjectViewModel
        )
        {
            _createUpdateSubjectViewModel = createUpdateSubjectViewModel;
        }
    }
}