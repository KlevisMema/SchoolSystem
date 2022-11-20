using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SchoolSystem.BLL.MediatrService.Actions.Student.Commands
{
    public class DeleteStudentCommand : IRequest<ObjectResult>
    {
        public Guid Id { get; set; }

        public DeleteStudentCommand
        (
            Guid id
        )
        {
            Id = id;
        }
    }
}