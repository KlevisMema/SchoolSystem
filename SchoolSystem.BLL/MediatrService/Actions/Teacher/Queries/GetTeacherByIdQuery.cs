#region Usings

using MediatR;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace SchoolSystem.BLL.MediatrService.Actions.Teacher.Queries
{
    /// <summary>
    ///      Get teacher query class which inherit from IRequest that holds an object result as a response.
    /// </summary>
    public class GetTeacherByIdQuery : IRequest<ObjectResult>
    {
        /// <summary>
        ///     Id of the teacher 
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        ///     Instansiate GetTeacherByIdQuery passing the teacher id as parameter
        /// </summary>
        /// <param name="id"> Id of the teacher passed to the constructor </param>
        public GetTeacherByIdQuery
        (
            Guid id
        )
        {
            Id = id;
        }
    }
}