using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.DTO.ViewModels.StudentClasroom;

namespace SchoolSystem.BLL.MediatrService.Actions.StudentClasroom.Commands
{
    public class UpdateStudentClasroomCommand : IRequest<ObjectResult>
    {
        public Guid Id { get; set; }
        public CreateUpdateStudentClasroomViewModel _updateStudentClasroom { get; set; }

        public UpdateStudentClasroomCommand
        (
            Guid id,
            CreateUpdateStudentClasroomViewModel updateStudentClasroom
        )
        {
            Id = id;
            _updateStudentClasroom = updateStudentClasroom;
        }
    }
}