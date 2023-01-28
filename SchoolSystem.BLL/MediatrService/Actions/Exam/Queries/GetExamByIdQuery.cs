#region Usings

using MediatR;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace SchoolSystem.BLL.MediatrService.Actions.Exam.Querys
{
    /// <summary>
    ///      Get exam query class which inherit from IRequest that holds an object result as a response.
    /// </summary>
    public class GetExamByIdQuery : IRequest<ObjectResult>
    {
        /// <summary>
        ///     Id of the exam 
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        ///     Instansiate GetExamByIdQuery passing the exam id as parameter
        /// </summary>
        /// <param name="id"> Id of the exam passed to the constructor </param>
        public GetExamByIdQuery
        (
            Guid id
        )
        {
            Id = id;
        }
    }
}