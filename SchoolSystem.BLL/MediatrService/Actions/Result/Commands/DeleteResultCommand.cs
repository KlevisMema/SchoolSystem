using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SchoolSystem.BLL.MediatrService.Actions.Result.Commands
{
    public class DeleteResultCommand : IRequest<ObjectResult>
    {
        public Guid Id { get; set; }
        public DeleteResultCommand
        (
            Guid id
        )
        {
            Id = id;
        }
    }
}