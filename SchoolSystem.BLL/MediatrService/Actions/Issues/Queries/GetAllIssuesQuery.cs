using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SchoolSystem.BLL.MediatrService.Actions.Issues.Queries
{
    public class GetAllIssuesQuery : IRequest<ObjectResult>
    {
    }
}