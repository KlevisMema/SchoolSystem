using FluentValidation;
using SchoolSystem.DTO.ViewModels.StudentClasroom;

namespace SchoolSystem.DTO.FluentValidation.StudentClasroom
{
    public class CreateUpdateStudentClasroomViewModelValidation : AbstractValidator<CreateUpdateStudentClasroomViewModel>
    {
        public CreateUpdateStudentClasroomViewModelValidation()
        {
            RuleFor(x => x.StudentId).NotNull();
            RuleFor(x => x.ClasroomId).NotNull();
        }
    }
}