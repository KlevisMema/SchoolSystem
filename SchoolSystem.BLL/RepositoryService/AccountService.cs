#region

using AutoMapper;
using SchoolSystem.DAL.Models;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using SchoolSystem.BLL.ResponseService;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.DTO.ViewModels.Account;

#endregion

namespace SchoolSystem.BLL.RepositoryService
{
    /// <summary>
    ///     Account service that implements IAccountService interface, and has all buisness logic related to account 
    /// </summary>
    public class AccountService : IAccountService
    {
        #region services 

        /// <summary>
        ///    A readonly field for Mapper service
        /// </summary>
        private readonly IMapper _mapper;
        /// <summary>
        ///   A readonly field for  Auth interface 
        /// </summary>
        private readonly IOAuthService _oAuthService;
        /// <summary>
        ///   A readonly field for  User Manager
        /// </summary>
        private readonly UserManager<User> _userManager;
        /// <summary>
        ///    A readonly field for Logger
        /// </summary>
        private readonly ILogger<AccountService> _logger;
        /// <summary>
        ///    A readonly field for Sign in manager
        /// </summary>
        private readonly SignInManager<User> _signInManager;

        /// <summary>
        ///     Inject all services in constructor
        /// </summary>
        /// <param name="mapper"> Mapper service </param>
        /// <param name="oAuthService"> OAuth service </param>
        /// <param name="userManager"> User Manager service </param>
        /// <param name="logger"> Logger service </param>
        /// <param name="signInManager"> Sign In service </param>
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

        #endregion

        #region Register a user in AspNetUsers table

        /// <summary>
        ///     Register User
        /// </summary>
        /// <param name="register"> Register object </param>

        public async Task<Response<RegisterViewModel>> Register
        (
            RegisterViewModel register
        )
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

        #endregion

        #region Login a user 

        /// <summary>
        ///     Log in a user and genereate a token
        /// </summary>
        /// <param name="logIn"> Login object </param>

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

        #endregion
    }
}