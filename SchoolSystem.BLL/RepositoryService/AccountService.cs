#region

using AutoMapper;
using SchoolSystem.DAL.Models;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using SchoolSystem.BLL.ResponseService;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.DTO.ViewModels.Account;
using SchoolSystem.BLL.RepositoryService.CrudService;
using SchoolSystem.DAL.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.DAL.Enums;

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
        ///     A readonly field for role manager
        /// </summary>
        private readonly RoleManager<IdentityRole> _roleManager;
        /// <summary>
        ///     Database context
        /// </summary>
        private readonly DatabaseActionsService<RolesViewModel, IdentityRole, IdentityRole> _db;

        /// <summary>
        ///     Inject all services in constructor
        /// </summary>
        /// <param name="mapper"> Mapper service </param>
        /// <param name="oAuthService"> OAuth service </param>
        /// <param name="userManager"> User Manager service </param>
        /// <param name="logger"> Logger service </param>
        /// <param name="signInManager"> Sign In service </param>
        /// <param name="db"> Database context </param>
        /// <param name="roleManager"> Role manager </param>
        public AccountService
        (
            IMapper mapper,
            IOAuthService oAuthService,
            UserManager<User> userManager,
            ILogger<AccountService> logger,
            SignInManager<User> signInManager,
            RoleManager<IdentityRole> roleManager,
            DatabaseActionsService<RolesViewModel, IdentityRole, IdentityRole> db
        )
        {
            _db = db;
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
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

        public async Task<Response<LoginViewModel>> Login
        (
            LoginViewModel logIn
        )
        {
            try
            {
                var result = await _signInManager.PasswordSignInAsync(logIn.Email, logIn.Password, false, false);

                if (result.Succeeded)
                {
                    var user = await _userManager.FindByEmailAsync(logIn.Email);

                    if (user == null)
                        Response<LoginViewModel>.NotFound("User doesn't exists !!");

                    var roles = await _userManager.GetRolesAsync(_mapper.Map<User>(logIn));

                    if (roles.Count == 0)
                        Response<LoginViewModel>.NotFound("User doesn't have any role !!");

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

        #region Get all roles 

        /// <summary>
        ///     Get all roles from the database 
        /// </summary>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> A list of roles with role id and role name </returns>
        public async Task<Response<List<RolesViewModel>>> GetAllRoles
        (
            CancellationToken cancellationToken
        )
        {
            var getAllRoles = await _db.GetAll(cancellationToken);

            return getAllRoles;
        }

        #endregion

        #region Assing a role to a user 

        /// <summary>
        ///     Add a user to a role
        /// </summary>
        /// <param name="UserId"> User id </param>
        /// <param name="RoleId"> Role id </param>
        /// <returns> A message telling if the operation went ok or not </returns>

        public async Task<Response<string>> AssignRoleToUser
        (
            string UserId,
            string RoleId
        )
        {
            try
            {
                var user = await _userManager.FindByIdAsync(UserId);

                if (user == null)
                    return Response<string>.NotFound($"User doesn't exists");

                var role = await _roleManager.FindByIdAsync(RoleId);

                var UserIsInRole = await _userManager.IsInRoleAsync(user, role.Name);

                if (UserIsInRole)
                    return Response<string>.UnSuccessMessage($"User is already in {role.Name} role");

                if (role == null)
                    return Response<string>.NotFound($"Role doesn't exists");

                var addUserToRole = await _userManager.AddToRoleAsync(user, role.Name);

                if (addUserToRole.Succeeded)
                    return Response<string>.SuccessMessage($"User added to role {role.Name}");

            }
            catch (Exception ex)
            {
                _logger.LogError
                (
                   ex,
                   $"Error, something went wrong !! => \n " +
                   $" Method : {ex.TargetSite} \n" +
                   $" Source : {ex.Source} \n" +
                   $"InnerEx : {ex.InnerException} \n"
                );
            }

            return Response<string>.ErrorMsg("Something went wrong !!");
        }

        #endregion

    }
}