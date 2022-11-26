using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SchoolSystem.BLL.MediatrService.Actions.TimeTable.Queries
{
    public class GetTimeTableByIdQuery : IRequest<ObjectResult>
    {
        public Guid Id { get; set; }

        public GetTimeTableByIdQuery
        (
            Guid id
        )
        {
            Id = id;
        }
    }
}