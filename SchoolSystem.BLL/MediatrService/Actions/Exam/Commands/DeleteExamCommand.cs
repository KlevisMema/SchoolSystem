using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SchoolSystem.BLL.MediatrService.Actions.Exam.Commands
{
    public class DeleteExamCommand : IRequest<ObjectResult>
    {
        public Guid Id { get; set; }

        public DeleteExamCommand
        (
            Guid id
        )
        {
            Id = id;
        }
    }
}