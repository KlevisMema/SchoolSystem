#region Usings

using MediatR;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace SchoolSystem.BLL.MediatrService.Actions.Result.Queries
{
    /// <summary>
    ///      Get result query class which inherit from IRequest that holds an object result as a response.
    /// </summary>
    public class GetResultByIdQuery : IRequest<ObjectResult>
    {
        /// <summary>
        ///     Id of the result 
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        ///     Instansiate GetResultByIdQuery passing the result id as parameter
        /// </summary>
        /// <param name="id"> Id of the result passed to the constructor </param>
        public GetResultByIdQuery
        (
            Guid id
        )
        {
            Id = id;
        }
    }
}