using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SchoolSystem.BLL.MediatrService.Actions.StudentClasroom.Queries
{
    public class GetAllStudentClasroomsQuery : IRequest<ObjectResult>
    {
    }
}