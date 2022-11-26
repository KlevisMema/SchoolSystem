using MediatR;
using SchoolSystem.BLL.ResponseService;

namespace SchoolSystem.BLL.MediatrService.Actions.TimeTable.Queries
{
    public class DoestTimeTableExistsQuery : IRequest<CustomMesageResponse>
    {
        public Guid TimeTableId { get; set; }

        public DoestTimeTableExistsQuery
        (
            Guid timeTableId
        )
        {
            TimeTableId = timeTableId;
        }
    }
}