using MediatR;
using SchoolSystem.BLL.ResponseService;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.BLL.MediatrService.Actions.TimeTable.Queries;

namespace SchoolSystem.BLL.MediatrService.Handlers.TimeTable.QueriesHandler
{
    public class DoesTimeTableExistsQueryHandler : IRequestHandler<DoestTimeTableExistsQuery, CustomMesageResponse>
    {

        private readonly I_Valid_Id<SchoolSystem.DAL.Models.TimeTable> _TimeTable_Valid_Id;

        public DoesTimeTableExistsQueryHandler
        (
            I_Valid_Id<SchoolSystem.DAL.Models.TimeTable> TimeTable_Valid_Id
        )
        {
            _TimeTable_Valid_Id = TimeTable_Valid_Id;
        }

        public async Task<CustomMesageResponse> Handle
        (
            DoestTimeTableExistsQuery request, 
            CancellationToken cancellationToken
        )
        {
            var timeTable = await _TimeTable_Valid_Id.Bool(request.TimeTableId, cancellationToken);

            if (timeTable)
                return CustomMesageResponse.Succsess();

            return CustomMesageResponse.NotFound(timeTable, "Invalid time table id");
        }
    }
}