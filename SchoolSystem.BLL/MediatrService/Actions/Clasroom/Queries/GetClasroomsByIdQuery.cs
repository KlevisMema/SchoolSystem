using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SchoolSystem.BLL.MediatrService.Actions.Clasroom.Queries
{
    public class GetClasroomsByIdQuery : IRequest<ObjectResult>
    {
        public Guid Id { get; set; }

        public GetClasroomsByIdQuery
        (
            Guid id
        )
        {
            Id = id;
        }
    }
}