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
        private readonly IOAuthService _oAuthService;
        private readonly UserManager<User> _userManager;
        private readonly ILogger<AccountService> _logger;
        private readonly SignInManager<User> _signInManager;
        public AccountService
        (
            IMapper mapper,
            IOAuthService oAuthService,
            UserManager<User> userManager,
            ILogger<AccountService> logger,
            SignInManager<User> signInManager
        )
        {
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
            _oAuthService = oAuthService;
            _signInManager = signInManager;
        }

        /// <summary>
        /// Register User
        /// </summary>
        /// <param name="register">Register object </param>
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
                _logger.LogError
                (
                    ex, 
                    $" Something went wrong in {nameof(AccountService)} \n" +
                    $"Error, something went wrong !! => \n " +
                    $" Method : {ex.TargetSite} \n" +
                    $" Source : {ex.Source} \n" +
                    $"InnerEx : {ex.InnerException} \n"
                );
                return Response<RegisterViewModel>.ErrorMsg("Iternal server error, please try again later!");
            }
        }

        /// <summary>
        /// Log in a user
        /// </summary>
        /// <param name="logIn">Login object</param>
        public async Task<Response<LoginViewModel>> Login(LoginViewModel logIn)
        {
            try
            {
                var result = await _signInManager.PasswordSignInAsync(logIn.Email, logIn.Password, false, false);
                
                if (result.Succeeded)
                {
                    var user = await _userManager.FindByEmailAsync(logIn.Email);

                    var roles = await _userManager.GetRolesAsync(_mapper.Map<User>(logIn));

                    var userTransformedObj = new UserViewModel()
                    {
                        Id = user.Id,
                        Email = logIn.Email,
                        Roles = roles.ToList(),
                    };

                    return Response<LoginViewModel>.SuccessMessage(_oAuthService.CreateToken(userTransformedObj));
                }
                   
                return Response<LoginViewModel>.NotFound("User login attempt failed");
            }
            catch (Exception ex)
            {
                _logger.LogError
                (
                    ex,
                    $" Something went wrong in {nameof(AccountService)} \n" +
                    $"Error, something went wrong !! => \n " +
                    $" Method : {ex.TargetSite} \n" +
                    $" Source : {ex.Source} \n" +
                    $"InnerEx : {ex.InnerException} \n"
                );
                return Response<LoginViewModel>.ErrorMsg("Iternal server error, please try again later!");
            }
        }
    }
}