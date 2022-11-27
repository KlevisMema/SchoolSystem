using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SchoolSystem.BLL.MediatrService.Actions.Exam.Querys
{
    public class GetExamByIdQuery : IRequest<ObjectResult>
    {
        public Guid Id { get; set; }

        public GetExamByIdQuery
        (
            Guid id
        )
        {
            Id = id;
        }
    }
}