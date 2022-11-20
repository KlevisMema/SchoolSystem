using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.DTO.ViewModels.Student;

namespace SchoolSystem.BLL.MediatrService.Actions.Student.Commands
{
    public class CreateStudentCommad : IRequest<ObjectResult>
    {
        public CreateUpdateStudentViewModel _CreateUpdateStudentViewModel { get; set; }

        public CreateStudentCommad
        (
            CreateUpdateStudentViewModel createUpdateStudentViewModel
        )
        {
            _CreateUpdateStudentViewModel = createUpdateStudentViewModel;
        }
    }
}