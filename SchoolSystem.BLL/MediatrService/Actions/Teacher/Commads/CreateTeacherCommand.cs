using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.DTO.ViewModels.Teacher;

namespace SchoolSystem.BLL.MediatrService.Actions.Teacher.Commads
{
    public class CreateTeacherCommand : IRequest<ObjectResult>
    {
        public CreateUpdateTeacherViewModel _createUpdateTeacherViewModel;

        public CreateTeacherCommand
        (
            CreateUpdateTeacherViewModel createUpdateTeacherViewModel
        )
        {
            _createUpdateTeacherViewModel = createUpdateTeacherViewModel;
        }
    }
}