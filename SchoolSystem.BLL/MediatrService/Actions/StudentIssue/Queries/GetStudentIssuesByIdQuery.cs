using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SchoolSystem.BLL.MediatrService.Actions.StudentIssue.Queries
{
    public class GetStudentIssuesByIdQuery : IRequest<ObjectResult>
    {
        public Guid StudentId { get; set; }
        public Guid IssueId { get; set; }

        public GetStudentIssuesByIdQuery
        (
            Guid StudentId,
            Guid IssueId
        )
        {
            this.StudentId = StudentId;
            this.IssueId = IssueId;
        }
    }
}