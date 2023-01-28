#region usings

using MediatR;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace SchoolSystem.BLL.MediatrService.Queries.Subject.Queries
{
    /// <summary>
    ///      Get subject query class which inherit from IRequest that holds an object result as a response.
    /// </summary>
    public class GetSubjectByIdQuery : IRequest<ObjectResult>
    {
        /// <summary>
        ///     Id of the subject 
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        ///     Instansiate GetSubjectByIdQuery passing the subject id as parameter
        /// </summary>
        /// <param name="id"> Id of the subject passed to the constructor </param>
        public GetSubjectByIdQuery
        (
            Guid id
        )
        {
            Id = id;
        }
    }
}