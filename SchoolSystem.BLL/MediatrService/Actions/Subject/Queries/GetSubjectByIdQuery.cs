using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SchoolSystem.BLL.MediatrService.Queries.Subject.Queries
{
    public class GetSubjectByIdQuery : IRequest<ObjectResult>
    {
        public Guid Id { get; set; }
        public GetSubjectByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}