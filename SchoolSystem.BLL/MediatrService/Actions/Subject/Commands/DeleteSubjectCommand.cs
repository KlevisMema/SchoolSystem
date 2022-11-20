using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SchoolSystem.BLL.MediatrService.Queries.Subject.Commands
{
    public class DeleteSubjectCommand : IRequest<ObjectResult>
    {
        public Guid Id { get; set; }

        public DeleteSubjectCommand
        (
            Guid id
        )
        {
            Id = id;
        }
    }
}