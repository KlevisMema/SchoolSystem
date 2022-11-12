using SchoolSystem.BLL.ResponseService;
using SchoolSystem.DTO.ViewModels.Account;

namespace SchoolSystem.BLL.ServiceInterfaces
{
    public interface IAccountService
    {
        Task<Response<RegisterViewModel>> Register(RegisterViewModel register);
        Task<Response<LoginViewModel>> Login(LoginViewModel logIn);
    }
}