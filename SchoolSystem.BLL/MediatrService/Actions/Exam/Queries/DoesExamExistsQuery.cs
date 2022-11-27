using MediatR;
using SchoolSystem.BLL.ResponseService;

namespace SchoolSystem.BLL.MediatrService.Actions.Exam.Queries
{
    public class DoesExamExistsQuery : IRequest<CustomMesageResponse>
    {
        public Guid Id { get; set; }

        public DoesExamExistsQuery
        (
            Guid id
        )
        {
            Id = id;
        }
    }
}