using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.DTO.ViewModels.StudentClasroom;

namespace SchoolSystem.BLL.MediatrService.Actions.StudentClasroom.Commands
{
    public class CreateStudentClasroomCommand : IRequest<ObjectResult>
    {
        public CreateUpdateStudentClasroomViewModel _createStudentClasroom { get; set; }

        public CreateStudentClasroomCommand
        (
            CreateUpdateStudentClasroomViewModel createStudentClasroom
        )
        {
            _createStudentClasroom = createStudentClasroom;
        }
    }
}