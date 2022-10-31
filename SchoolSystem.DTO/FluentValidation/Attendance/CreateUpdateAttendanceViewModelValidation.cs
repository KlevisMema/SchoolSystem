using FluentValidation;
using SchoolSystem.DTO.ViewModels.Attendance;

namespace SchoolSystem.DTO.FluentValidation.Attendance
{
    public class CreateUpdateAttendanceViewModelValidation : AbstractValidator<CreateUpdateAttendanceViewModel>
    {
        public CreateUpdateAttendanceViewModelValidation()
        {
            RuleFor(x => x.StudentId).NotNull();
            RuleFor(x => x.Status).NotNull();
            RuleFor(x => x.TeacherId).NotNull();
        }
    }
}