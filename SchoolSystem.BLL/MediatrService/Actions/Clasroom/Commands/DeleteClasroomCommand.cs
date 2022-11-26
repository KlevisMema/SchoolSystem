using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SchoolSystem.BLL.MediatrService.Actions.Clasroom.Commands
{
    public class DeleteClasroomCommand : IRequest<ObjectResult>
    {
        public Guid Id { get; set; }

        public DeleteClasroomCommand
        (
            Guid id
        )
        {
            Id = id;
        }
    }
}