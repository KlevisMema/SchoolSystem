using SchoolSystem.DTO.ViewModels.Account;

namespace SchoolSystem.BLL.ServiceInterfaces
{
    public interface IOAuthService
    {
        string CreateToken(UserViewModel user);
    }
}