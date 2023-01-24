#region Usings

using MediatR;
using SchoolSystem.BLL.ResponseService;

#endregion

namespace SchoolSystem.BLL.MediatrService.Actions.Exam.Queries
{
    /// <summary>
    ///     Get exam query class which inherit from IRequest that holds an CustomMesageResponse as a response.
    /// </summary>
    public class DoesExamExistsQuery : IRequest<CustomMesageResponse>
    {
        /// <summary>
        ///     Id of the exam 
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        ///     Instansiate DoesExamExistsQuery passing the exam id as parameter
        /// </summary>
        /// <param name="id"> Id of the exam passed to the constructor </param>
        public DoesExamExistsQuery
        (
            Guid id
        )
        {
            Id = id;
        }
    }
}