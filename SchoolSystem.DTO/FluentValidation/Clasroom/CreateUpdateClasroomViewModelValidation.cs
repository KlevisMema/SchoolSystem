using FluentValidation;
using SchoolSystem.DTO.ViewModels.Clasroom;

namespace SchoolSystem.DTO.FluentValidation.Clasroom
{
    public class CreateUpdateClasroomViewModelValidation : AbstractValidator<CreateUpdateClasroomViewModel>
    {
        public CreateUpdateClasroomViewModelValidation()
        {
            RuleFor(x => x.TeacherId).NotNull();
            RuleFor(x => x.TimeTableId).NotNull();
            RuleFor(x => x.Grade).NotNull();
        }
    }
}