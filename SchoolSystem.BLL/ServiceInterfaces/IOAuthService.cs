using SchoolSystem.DTO.ViewModels.Account;

namespace SchoolSystem.BLL.ServiceInterfaces
{
    public interface IOAuthService
    {
        Task<string> CreateToken(LoginViewModel logIn);
    }
}