using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.DTO.ViewModels.Student;

namespace SchoolSystem.BLL.MediatrService.Actions.Student.Commands
{
    public class UpdateStudentCommand : IRequest<ObjectResult>
    {
        public Guid Id { get; set; }
        public CreateUpdateStudentViewModel _CreateUpdateStudentViewModel { get; set; }

        public UpdateStudentCommand
        (
            Guid id,
            CreateUpdateStudentViewModel createUpdateStudentViewModel
        )
        {
            Id = id;
            _CreateUpdateStudentViewModel = createUpdateStudentViewModel;
        }
    }
}