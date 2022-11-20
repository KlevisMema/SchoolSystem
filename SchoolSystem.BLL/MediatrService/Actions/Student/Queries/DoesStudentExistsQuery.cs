using MediatR;
using SchoolSystem.BLL.ResponseService;

namespace SchoolSystem.BLL.MediatrService.Actions.Student.Queries
{
    public class DoesStudentExistsQuery : IRequest<CustomMesageResponse>
    {
        public Guid StudentId { get; set; }

        public DoesStudentExistsQuery
        (
            Guid studentId
        )
        {
            StudentId = studentId;
        }
    }
}