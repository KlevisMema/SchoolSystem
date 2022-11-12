using System.Text;
using System.Security.Claims;
using SchoolSystem.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.DTO.ViewModels.Account;

namespace SchoolSystem.BLL.AuthTokenService
{
    public class OAuthService : IOAuthService
    {
        private User _user;
        private readonly IConfiguration configuration;
        private readonly UserManager<User> userManager;

        public OAuthService
        (
            IConfiguration configuration,
            UserManager<User> userManager
        )
        {
            this.userManager = userManager;
            this.configuration = configuration;
        }

        public async Task<string> CreateToken(LoginViewModel logIn)
        {
            await ValidateUser(logIn);
            var singinCredentials = GetSinginCredentials();
            var claims = await GetClaims();
            var token = GenerateToken(singinCredentials, claims);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private async Task<bool> ValidateUser(LoginViewModel login)
        {
            _user = await userManager.FindByEmailAsync(login.Email);
            return _user != null && await userManager.CheckPasswordAsync(_user, login.Password);
        }

        private SigningCredentials GetSinginCredentials()
        {
            var jwtSetting = configuration.GetSection("Jwt");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSetting.GetSection("Key").Value));

            return new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        }

        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, _user.UserName),
                new Claim(JwtRegisteredClaimNames.NameId, _user.Id),
                new Claim(JwtRegisteredClaimNames.Email, _user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iss, configuration["Jwt:Issuer"])
            };

            var roles = await userManager.GetRolesAsync(_user);

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return claims;
        }

        private JwtSecurityToken GenerateToken(SigningCredentials singinCredentials, List<Claim> claims)
        {
            var jwtSetting = configuration.GetSection("Jwt");

            var token = new JwtSecurityToken
            (
                issuer: jwtSetting.GetSection("Issuer").Value,
                claims: claims,
                expires: DateTime.Now.AddHours(Convert.ToDouble(jwtSetting.GetSection("LifeTime").Value)),
                signingCredentials: singinCredentials
            );

            return token;
        }
    }
}