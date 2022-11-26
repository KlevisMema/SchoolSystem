using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SchoolSystem.BLL.MediatrService.Actions.TimeTable.Queries
{
    public class GetAllTimeTablesQuery : IRequest<ObjectResult>
    {
    }
}