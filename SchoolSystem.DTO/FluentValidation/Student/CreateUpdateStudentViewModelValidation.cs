using FluentValidation;
using SchoolSystem.DTO.ViewModels.Student;

namespace SchoolSystem.DTO.FluentValidation.Student
{
    public class CreateUpdateStudentViewModelValidation : AbstractValidator<CreateUpdateStudentViewModel>
    {
        public CreateUpdateStudentViewModelValidation()
        {
            RuleFor(x => x.Email).NotNull().EmailAddress();
            RuleFor(x => x.Adress).NotNull().Length(4, 10);
            RuleFor(x => x.Phone).NotNull();
            RuleFor(x => x.FullName).NotNull().Length(4, 30);
            RuleFor(x => x.Sex).NotNull();
            RuleFor(x => x.Password).NotNull().MinimumLength(6);
            RuleFor(x => x.ParentName).NotNull().MinimumLength(3);
        }
    }
}