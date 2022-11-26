using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SchoolSystem.BLL.MediatrService.Actions.Clasroom.Queries
{
    public class GetAllClasroomsQuery : IRequest<ObjectResult>
    {
    }
}