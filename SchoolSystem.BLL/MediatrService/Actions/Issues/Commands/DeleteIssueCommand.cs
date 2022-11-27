using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SchoolSystem.BLL.MediatrService.Actions.Issues.Commands
{
    public class DeleteIssueCommand : IRequest<ObjectResult>
    {
        public Guid Id { get; set; }

        public DeleteIssueCommand
        (
            Guid id
        )
        {
            Id = id;
        }
    }
}