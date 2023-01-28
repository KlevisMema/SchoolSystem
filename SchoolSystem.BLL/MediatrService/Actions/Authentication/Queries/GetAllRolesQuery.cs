#region Usings

using MediatR;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace SchoolSystem.BLL.MediatrService.Actions.Authentication.Queries
{
    /// <summary>
    ///     Get all roles query class  which inehrits from IRequest with response ObjectResult
    /// </summary>
    public class GetAllRolesQuery : IRequest<ObjectResult>
    {
        /// <summary>
        ///     Instansiate GetAllRolesQuery with no parameters needed 
        /// </summary>
        public GetAllRolesQuery() { }
    }
}
