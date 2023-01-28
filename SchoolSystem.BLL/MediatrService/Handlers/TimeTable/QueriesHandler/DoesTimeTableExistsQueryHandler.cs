#region Usings

using MediatR;
using SchoolSystem.BLL.ResponseService;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.BLL.MediatrService.Actions.TimeTable.Queries;

#endregion

namespace SchoolSystem.BLL.MediatrService.Handlers.TimeTable.QueriesHandler
{
    /// <summary>
    ///     Does time table exists query handler class which implements IRequestHandler which gets the Does Clasroom Exists Query and CustomMesageResponse as response.
    /// </summary>
    public class DoesTimeTableExistsQueryHandler : IRequestHandler<DoestTimeTableExistsQuery, CustomMesageResponse>
    {
        /// <summary>
        ///     I_Valid_Id interface 
        /// </summary>
        private readonly I_Valid_Id<SchoolSystem.DAL.Models.TimeTable> _TimeTable_Valid_Id;

        /// <summary>
        ///     Services injection
        /// </summary>
        /// <param name="TimeTable_Valid_Id"> Valid id service  </param>
        public DoesTimeTableExistsQueryHandler
        (
            I_Valid_Id<SchoolSystem.DAL.Models.TimeTable> TimeTable_Valid_Id
        )
        {
            _TimeTable_Valid_Id = TimeTable_Valid_Id;
        }

        /// <summary>
        ///     Handle the does time table exists command
        /// </summary>
        /// <param name="request"> Request parameters </param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> A Object result response </returns>
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