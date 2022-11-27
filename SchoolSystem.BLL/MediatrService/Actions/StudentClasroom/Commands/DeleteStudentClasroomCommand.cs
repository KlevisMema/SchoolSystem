using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SchoolSystem.BLL.MediatrService.Actions.StudentClasroom.Commands
{
    public class DeleteStudentClasroomCommand : IRequest<ObjectResult>
    {
        public Guid Id { get; set; }

        public DeleteStudentClasroomCommand
        (
            Guid id
        )
        {
            Id = id;
        }
    }
}