using AutoMapper;
using SchoolSystem.DAL.Models;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using SchoolSystem.BLL.ResponseService;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.DTO.ViewModels.Account;

namespace SchoolSystem.BLL.RepositoryService
{
    public class AccountService : IAccountService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly ILogger<AccountService> _logger;
        private readonly SignInManager<User> _signInManager;
        public AccountService
        (
            IMapper mapper,
            UserManager<User> userManager,
            ILogger<AccountService> logger,
            SignInManager<User> signInManager
        )
        {
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<Response<RegisterViewModel>> Register(RegisterViewModel register)
        {
            try
            {
                var user = _mapper.Map<User>(register);

                var result = await _userManager.CreateAsync(user, register.Password);

                if (result.Succeeded)
                    return Response<RegisterViewModel>.SuccessMessage("Register succsessful!");

                return Response<RegisterViewModel>.ErrorMsg("User registration attempt failed");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $" Something went wrong in {nameof(AccountService)}");
                return Response<RegisterViewModel>.ErrorMsg("Iternal server error, please try again later!");
            }
        }

        public async Task<Response<LoginViewModel>> Login(LoginViewModel logIn)
        {
            try
            {
                var result = await _signInManager.PasswordSignInAsync(logIn.Email, logIn.Password, false, false);

                if (result.Succeeded)
                    return Response<LoginViewModel>.SuccessMessage("Login succsessful!");

                return Response<LoginViewModel>.NotFound("User login attempt failed");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $" Something went wrong in {nameof(AccountService)}");
                return Response<LoginViewModel>.ErrorMsg("Iternal server error, please try again later!");
            }
        }
    }
}