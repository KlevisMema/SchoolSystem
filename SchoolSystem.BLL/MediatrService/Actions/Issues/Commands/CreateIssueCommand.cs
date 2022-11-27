using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.DTO.ViewModels.Issue;

namespace SchoolSystem.BLL.MediatrService.Actions.Issues.Commands
{
    public class CreateIssueCommand : IRequest<ObjectResult>
    {
        public CreateUpdateIssueViewModel _createIssue { get; set; }

        public CreateIssueCommand
        (
            CreateUpdateIssueViewModel createIssue
        )
        {
            _createIssue = createIssue;
        }
    }
}