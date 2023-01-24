#region Usings

using MediatR;
using SchoolSystem.BLL.ResponseService;

#endregion

namespace SchoolSystem.BLL.MediatrService.Actions.TimeTable.Queries
{
    /// <summary>
    ///     Get time table query class which inherit from IRequest that holds an CustomMesageResponse as a response.
    /// </summary>
    public class DoestTimeTableExistsQuery : IRequest<CustomMesageResponse>
    {
        /// <summary>
        ///     Id of the time table 
        /// </summary>
        public Guid TimeTableId { get; set; }

        /// <summary>
        ///     Instansiate DoestTimeTableExistsQuery passing the time table id as parameter
        /// </summary>
        /// <param name="timeTableId"> Id of the time table passed to the constructor </param>
        public DoestTimeTableExistsQuery
        (
            Guid timeTableId
        )
        {
            TimeTableId = timeTableId;
        }
    }
}