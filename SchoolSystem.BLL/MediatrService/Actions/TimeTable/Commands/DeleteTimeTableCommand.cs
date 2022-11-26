using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SchoolSystem.BLL.MediatrService.Actions.TimeTable.Commands
{
    public class DeleteTimeTableCommand : IRequest<ObjectResult>
    {
        public Guid Id { get; set; }

        public DeleteTimeTableCommand
        (
            Guid id
        )
        {
            Id = id;
        }
    }
}