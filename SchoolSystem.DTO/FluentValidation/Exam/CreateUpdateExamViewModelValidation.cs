using FluentValidation;
using SchoolSystem.DTO.ViewModels.Exam;

namespace SchoolSystem.DTO.FluentValidation.Exam
{
    public class CreateUpdateExamViewModelValidation : AbstractValidator<CreateUpdateExamViewModel>
    {
        public CreateUpdateExamViewModelValidation()
        {
            RuleFor(x => x.Name).NotNull().Length(4, 30);
            RuleFor(x => x.Type).NotNull();
        }
    }
}