using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SchoolSystem.BLL.MediatrService.Actions.Result.Queries
{
    public class GetResultByIdQuery : IRequest<ObjectResult>
    {
        public Guid Id { get; set; }

        public GetResultByIdQuery
        (
            Guid id
        )
        {
            Id = id;
        }
    }
}