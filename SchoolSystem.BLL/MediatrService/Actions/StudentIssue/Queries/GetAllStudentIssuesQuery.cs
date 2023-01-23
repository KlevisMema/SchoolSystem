using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SchoolSystem.BLL.MediatrService.Actions.StudentIssue.Queries
{
    public class GetAllStudentIssuesByIdQuery : IRequest<ObjectResult>
    {
    }
}