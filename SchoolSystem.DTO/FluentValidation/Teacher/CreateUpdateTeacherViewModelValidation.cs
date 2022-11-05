using FluentValidation;
using SchoolSystem.DTO.ViewModels.Teacher;

namespace SchoolSystem.DTO.FluentValidation.Teacher
{
    public class CreateUpdateTeacherViewModelValidation : AbstractValidator<CreateUpdateTeacherViewModel>
    {
        public CreateUpdateTeacherViewModelValidation()
        {
            RuleFor(x => x.Email).NotNull().EmailAddress();
            RuleFor(x=>x.Adress).NotNull().Length(4,10);
            RuleFor(x=>x.Phone).NotNull();
            RuleFor(x=>x.FullName).NotNull().Length(4,30);
            RuleFor(x=>x.Sex).NotNull();
            RuleFor(x=>x.Password).NotNull().MinimumLength(6);
        }
    }
}