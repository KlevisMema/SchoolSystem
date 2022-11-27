using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SchoolSystem.BLL.MediatrService.Actions.Issues.Queries
{
    public class GetIssueByIdQuery : IRequest<ObjectResult>
    {
        public Guid Id { get; set; }

        public GetIssueByIdQuery
        (
            Guid id
        )
        {
            Id = id;
        }
    }
}