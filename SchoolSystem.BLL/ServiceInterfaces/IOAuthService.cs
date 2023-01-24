using SchoolSystem.DTO.ViewModels.Account;

namespace SchoolSystem.BLL.ServiceInterfaces
{
    /// <summary>
    ///     A Auth interface that has a method "CreateToken" to genreate a token used to authenticate the API
    /// </summary>
    public interface IOAuthService
    {
        /// <summary>
        ///     Generate a token
        /// </summary>
        /// <param name="user"> User view model object data input </param>
        /// <returns> The generated token </returns>
        string CreateToken(UserViewModel user);
    }
}