using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.DTO.ViewModels.Teacher;

namespace SchoolSystem.BLL.MediatrService.Actions.Teacher.Commads
{
    public class UpdateTeacherCommand : IRequest<ObjectResult>
    {
        public Guid Id { get; set; }
        public CreateUpdateTeacherViewModel _createUpdateTeacherViewModel;

        public UpdateTeacherCommand
        (
            Guid id,
            CreateUpdateTeacherViewModel createUpdateTeacherViewModel
        )
        {
            Id = id;
            _createUpdateTeacherViewModel = createUpdateTeacherViewModel;
        }
    }
}