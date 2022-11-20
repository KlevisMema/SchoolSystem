using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SchoolSystem.BLL.MediatrService.Actions.Student.Queries
{
    public class GetAllStudentsQuery : IRequest<ObjectResult>
    {
    }
}