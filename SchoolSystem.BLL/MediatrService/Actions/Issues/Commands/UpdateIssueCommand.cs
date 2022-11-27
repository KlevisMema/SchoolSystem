using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.DTO.ViewModels.Issue;

namespace SchoolSystem.BLL.MediatrService.Actions.Issues.Commands
{
    public class UpdateIssueCommand : IRequest<ObjectResult>
    {
        public Guid Id { get; set; }
        public CreateUpdateIssueViewModel _updateIssue { get; set; }

        public UpdateIssueCommand
        (
            Guid id,
            CreateUpdateIssueViewModel updateIssue
        )
        {
            Id = id;
            _updateIssue = updateIssue;
        }
    }
}