using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SchoolSystem.BLL.MediatrService.Actions.Exam.Querys
{
    public class GetAllExamsQuery : IRequest<ObjectResult>
    {
    }
}