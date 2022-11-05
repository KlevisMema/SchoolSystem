using FluentValidation;
using SchoolSystem.DTO.ViewModels.TimeTable;

namespace SchoolSystem.DTO.FluentValidation.TimeTable
{
    public class CreateUpdateTimeTableViewModelValidation : AbstractValidator<CreateUpdateTimeTableViewModel>
    {
        public CreateUpdateTimeTableViewModelValidation()
        {
            RuleFor(x => x.Subject).NotNull();
        }
    }
}