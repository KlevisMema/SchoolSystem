using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SchoolSystem.BLL.MediatrService.Actions.StudentClasroom.Queries
{
    public class GetStudentClasroomByIdQuery : IRequest<ObjectResult>
    {
        public Guid Id { get; set; }

        public GetStudentClasroomByIdQuery
        (
            Guid id
        )
        {
            Id = id;
        }
    }
}