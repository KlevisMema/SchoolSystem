#region Usings

using MediatR;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace SchoolSystem.BLL.MediatrService.Actions.Exam.Querys
{
    /// <summary>
    ///      Get all attendances query class which inherit from IRequest that holds an object result as a response.
    /// </summary>
    public class GetAllExamsQuery : IRequest<ObjectResult>
    {
        /// <summary>
        ///     Instansiate GetAllExamsQuery with no parameters
        /// </summary>
        public GetAllExamsQuery() { }
    }
}