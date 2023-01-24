#region Usings

using MediatR;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace SchoolSystem.BLL.MediatrService.Actions.StudentClasroom.Queries
{
    /// <summary>
    ///      Get student clasroom query class which inherit from IRequest that holds an object result as a response.
    /// </summary>
    public class GetStudentClasroomByIdQuery : IRequest<ObjectResult>
    {
        /// <summary>
        ///     Id of the student clasroom 
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        ///     Instansiate GetStudentClasroomByIdQuery passing the student clasroom id as parameter
        /// </summary>
        /// <param name="id"> Id of the student clasroom passed to the constructor </param>
        public GetStudentClasroomByIdQuery
        (
            Guid id
        )
        {
            Id = id;
        }
    }
}