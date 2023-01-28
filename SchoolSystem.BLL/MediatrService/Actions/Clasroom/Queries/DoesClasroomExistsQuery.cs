using MediatR;
using SchoolSystem.BLL.ResponseService;

namespace SchoolSystem.BLL.MediatrService.Actions.Clasroom.Queries
{
    public class DoesClasroomExistsQuery : IRequest<CustomMesageResponse>
    {
        public Guid Id { get; set; }

        public DoesClasroomExistsQuery
        (
            Guid id
        )
        {
            Id = id;
        }
    }
}