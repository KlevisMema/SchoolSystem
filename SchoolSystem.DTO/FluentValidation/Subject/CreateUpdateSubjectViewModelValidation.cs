using FluentValidation;
using SchoolSystem.DTO.ViewModels.Subject;

namespace SchoolSystem.DTO.FluentValidation.Subject
{
    public class CreateUpdateSubjectViewModelValidation : AbstractValidator<CreateUpdateSubjectViewModel>
    {
        public CreateUpdateSubjectViewModelValidation()
        {
            RuleFor(x => x.Name).NotNull().Length(4, 30);
            RuleFor(x => x.Description).NotNull();
        }
    }
}
