using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SchoolSystem.BLL.MediatrService.Actions.Teacher.Queries
{
    public class GetAllTeachersQuery : IRequest<ObjectResult>
    {
    }
}