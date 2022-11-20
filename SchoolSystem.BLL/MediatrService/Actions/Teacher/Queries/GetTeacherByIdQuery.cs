using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SchoolSystem.BLL.MediatrService.Actions.Teacher.Queries
{
    public class GetTeacherByIdQuery : IRequest<ObjectResult>
    {
        public Guid Id { get; set; }

        public GetTeacherByIdQuery
        (
            Guid id
        )
        {
            Id = id;
        }
    }
}