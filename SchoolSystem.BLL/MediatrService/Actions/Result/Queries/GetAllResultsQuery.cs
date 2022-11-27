using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SchoolSystem.BLL.MediatrService.Actions.Result.Queries
{
    public class GetAllResultsQuery : IRequest<ObjectResult>
    {
    }
}