using SchoolSystem.BLL.ResponseService;
using SchoolSystem.DTO.ViewModels.Account;

namespace SchoolSystem.BLL.ServiceInterfaces
{
    /// <summary>
    ///     Account service interface that has Login,Register and Get all roles functions.
    /// </summary>
    public interface IAccountService
    {
        /// <summary>
        ///     Log in a user and genereate a token
        /// </summary>
        /// <param name="logIn"> Login object </param>
        Task<Response<LoginViewModel>> Login(LoginViewModel logIn);
        /// <summary>
        ///     Register User
        /// </summary>
        /// <param name="register"> Register object </param>
        Task<Response<RegisterViewModel>> Register(RegisterViewModel register);
        /// <summary>
        ///     Get all roles from the database 
        /// </summary>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> A list of roles with role id and role name </returns>
        Task<Response<List<RolesViewModel>>> GetAllRoles(CancellationToken cancellationToken);
        /// <summary>
        ///     Add a user to a role
        /// </summary>
        /// <param name="UserId"> User id </param>
        /// <param name="RoleId"> Role id </param>
        /// <returns> A message telling if the operation went ok or not </returns>
        Task<Response<string>> AssignRoleToUser(string UserId, string RoleId);
    }
}