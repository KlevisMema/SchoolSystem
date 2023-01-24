#region Usings

using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.DTO.ViewModels.Subject;

#endregion

namespace SchoolSystem.BLL.MediatrService.Queries.Subject.Commands
{
    /// <summary>
    ///     Update subject commad class which inherit from IRequest that holds an object result as a response.
    /// </summary>
    public class UpdateSubjectCommand : IRequest<ObjectResult>
    {
        /// <summary>
        ///     Id of the subject 
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        ///     Create or update subject view model object 
        /// </summary>
        public CreateUpdateSubjectViewModel CreateUpdateSubjectViewModel;

        /// <summary>
        ///     Instansiate UpdateSubjectCommand passing the CreateUpdateSubjectViewModel object and subject id as parameters
        /// </summary>
        /// <param name="createUpdateSubjectViewModel"> Create or update subject view model object passed to the constructor </param>
        /// <param name="id"> Id of the subject passed to the constructor </param>
        public UpdateSubjectCommand
        (
            CreateUpdateSubjectViewModel createUpdateSubjectViewModel,
            Guid id
        )
        {
            CreateUpdateSubjectViewModel = createUpdateSubjectViewModel;
            Id = id;
        }
    }
}