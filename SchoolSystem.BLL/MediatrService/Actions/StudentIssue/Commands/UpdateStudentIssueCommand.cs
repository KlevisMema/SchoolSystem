using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.DTO.ViewModels.StudentIssues;

namespace SchoolSystem.BLL.MediatrService.Actions.StudentIssue.Commands
{
    public class UpdateStudentIssueCommand : IRequest<ObjectResult>
    {
        public Guid Id { get; set; }
        public CreateUpdateStudentIssueViewModel _updateStudentIssue { get; set; }

        public UpdateStudentIssueCommand
        (
            Guid id,
            CreateUpdateStudentIssueViewModel updateStudentIssue
        )
        {
            Id = id;
            _updateStudentIssue = updateStudentIssue;
        }
    }
}