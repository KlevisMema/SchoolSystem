using MediatR;
using SchoolSystem.BLL.ResponseService;

namespace SchoolSystem.BLL.MediatrService.Actions.Teacher.Queries
{
    public class DoesTeacherExistsQuery : IRequest<CustomMesageResponse>
    {
        public Guid TeacherId { get; set; }

        public DoesTeacherExistsQuery
        (
            Guid teacherId
        )
        {
            TeacherId = teacherId;
        }
    }
}