using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SchoolSystem.BLL.MediatrService.Actions.Authentication.Commands
{
    public class AssignRoleToUserCommand : IRequest<ObjectResult>
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }

        public AssignRoleToUserCommand
        (
            string userId,
            string roleId
        )
        {
            UserId = userId;
            RoleId = roleId;
        }
    }
}
