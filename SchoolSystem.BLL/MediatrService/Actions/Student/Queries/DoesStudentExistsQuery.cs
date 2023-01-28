#region Usings

using MediatR;
using SchoolSystem.BLL.ResponseService;

#endregion

namespace SchoolSystem.BLL.MediatrService.Actions.Student.Queries
{
    /// <summary>
    ///     Get student query class which inherit from IRequest that holds an CustomMesageResponse as a response.
    /// </summary>
    public class DoesStudentExistsQuery : IRequest<CustomMesageResponse>
    {
        /// <summary>
        ///     Id of the student 
        /// </summary>
        public Guid StudentId { get; set; }

        /// <summary>
        ///     Instansiate DoesStudentExistsQuery passing the student id as parameter
        /// </summary>
        /// <param name="studentId"> Id of the student passed to the constructor </param>
        public DoesStudentExistsQuery
        (
            Guid studentId
        )
        {
            StudentId = studentId;
        }
    }
}