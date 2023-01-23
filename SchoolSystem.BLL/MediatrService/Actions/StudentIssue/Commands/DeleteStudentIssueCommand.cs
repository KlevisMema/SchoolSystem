using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SchoolSystem.BLL.MediatrService.Actions.StudentIssue.Commands
{
    public class DeleteStudentIssueCommand : IRequest<ObjectResult>
    {
        public Guid Id { get; set; }

        public DeleteStudentIssueCommand
        (
            Guid id
        )
        {
            Id = id;
        }
    }
}