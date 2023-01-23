using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.DTO.ViewModels.StudentIssues;

namespace SchoolSystem.BLL.MediatrService.Actions.StudentIssue.Commands
{
    public class CreateStudentIssueCommand : IRequest<ObjectResult>
    {
        public CreateUpdateStudentIssueViewModel _createStudentIssue { get; set; }

        public CreateStudentIssueCommand
        (
            CreateUpdateStudentIssueViewModel createStudentIssue
        )
        {
            _createStudentIssue = createStudentIssue;
        }
    }
}