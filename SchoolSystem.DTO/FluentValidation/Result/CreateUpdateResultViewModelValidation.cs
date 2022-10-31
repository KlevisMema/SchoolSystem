using FluentValidation;
using SchoolSystem.DTO.ViewModels.Result;

namespace SchoolSystem.DTO.FluentValidation.Result
{
    public class CreateUpdateResultViewModelValidation : AbstractValidator<CreateUpdateResultViewModel>
    {
        public CreateUpdateResultViewModelValidation()
        {
            RuleFor(x => x.Mark).NotNull();
            RuleFor(x => x.SubjectId).NotNull();
            RuleFor(x => x.StudentId).NotNull();
            RuleFor(x => x.ExamId).NotNull();
        }
    }
}