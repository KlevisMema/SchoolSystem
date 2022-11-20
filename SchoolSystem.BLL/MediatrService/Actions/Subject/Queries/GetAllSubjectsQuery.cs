using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SchoolSystem.BLL.MediatrService.Queries.Subject.Queries
{
    public class GetAllSubjectsQuery : IRequest<ObjectResult>
    {
    }
}