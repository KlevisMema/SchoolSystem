using FluentValidation;
using SchoolSystem.DTO.ViewModels.StudentIssues;

namespace SchoolSystem.DTO.FluentValidation.StudentIssue
{
    public class CreateUpdateStudentIssueViewModelValidation : AbstractValidator<CreateUpdateStudentIssueViewModel>
    {
        public CreateUpdateStudentIssueViewModelValidation()
        {
            RuleFor(x=> x.StudentId).NotEmpty().NotNull();
            RuleFor(x => x.IssueId).NotEmpty().NotNull();
        }
    }
}