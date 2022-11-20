using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SchoolSystem.BLL.MediatrService.Actions.Teacher.Commads
{
    public class DeleteTeacherCommand : IRequest<ObjectResult>
    {
        public Guid Id { get; set; }

        public DeleteTeacherCommand
        (
            Guid id
        )
        {
            Id = id;
        }
    }
}