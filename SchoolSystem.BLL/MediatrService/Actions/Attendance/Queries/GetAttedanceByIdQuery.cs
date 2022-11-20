using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SchoolSystem.BLL.MediatrService.Actions.Attendance.Queries
{
    public class GetAttedanceByIdQuery : IRequest<ObjectResult>
    {
        public Guid Id { get; set; }

        public GetAttedanceByIdQuery
        (
            Guid id
        )
        {
            Id = id;
        }
    }
}