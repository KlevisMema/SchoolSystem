#region Usings

using MediatR;
using Microsoft.AspNetCore.Mvc;


#endregion

namespace SchoolSystem.BLL.MediatrService.Actions.Student.Queries
{
    /// <summary>
    ///      Get student query class which inherit from IRequest that holds an object result as a response.
    /// </summary>
    public class GetStudentByIdQuery : IRequest<ObjectResult>
    {
        /// <summary>
        ///     Id of the student 
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        ///     Instansiate GetStudentByIdQuery passing the student id as parameter
        /// </summary>
        /// <param name="id"> Id of the student passed to the constructor </param>
        public GetStudentByIdQuery
        (
            Guid id
        )
        {
            Id = id;
        }
    }
}