using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SchoolSystem.BLL.MediatrService.Actions.Student.Queries
{
    public class GetStudentByIdQuery : IRequest<ObjectResult>
    {
        public Guid Id { get; set; }

        public GetStudentByIdQuery
        (
            Guid id
        )
        {
            Id = id;
        }
    }
}