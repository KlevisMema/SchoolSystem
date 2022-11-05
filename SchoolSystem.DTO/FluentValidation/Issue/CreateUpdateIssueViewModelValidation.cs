using FluentValidation;
using SchoolSystem.DTO.ViewModels.Issue;

namespace SchoolSystem.DTO.FluentValidation.Issue
{
    public class CreateUpdateIssueViewModelValidation : AbstractValidator<CreateUpdateIssueViewModel>
    {
        public CreateUpdateIssueViewModelValidation()
        {
            RuleFor(x=>x.Details).NotEmpty().NotNull();
            RuleFor(x => x.IsResolved).NotEmpty().NotNull();
        }
    }
}