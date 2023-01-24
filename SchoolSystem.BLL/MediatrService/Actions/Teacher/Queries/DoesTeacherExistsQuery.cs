#region Usings

using MediatR;
using SchoolSystem.BLL.ResponseService;

#endregion

namespace SchoolSystem.BLL.MediatrService.Actions.Teacher.Queries
{
    /// <summary>
    ///     Get teacher query class which inherit from IRequest that holds an CustomMesageResponse as a response.
    /// </summary>
    public class DoesTeacherExistsQuery : IRequest<CustomMesageResponse>
    {
        /// <summary>
        ///     Id of the teacher 
        /// </summary>
        public Guid TeacherId { get; set; }

        /// <summary>
        ///     Instansiate DoesTeacherExistsQuery passing the teacher id as parameter
        /// </summary>
        /// <param name="teacherId"> Id of the teacher passed to the constructor </param>
        public DoesTeacherExistsQuery
        (
            Guid teacherId
        )
        {
            TeacherId = teacherId;
        }
    }
}