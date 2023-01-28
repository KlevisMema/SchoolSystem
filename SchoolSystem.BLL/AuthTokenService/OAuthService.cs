#region Usings

using System.Text;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.DTO.ViewModels.Account;

#endregion

namespace SchoolSystem.BLL.AuthTokenService
{
    /// <summary>
    ///     A class which it's purpose is to generate a token and return it, it implements the IOAuthService interface
    /// </summary>
    public class OAuthService : IOAuthService
    {
        private readonly IOptions<JwtConfig> _jwtOptions;

        public OAuthService
        (
            IOptions<JwtConfig> jwtOptions
        )
        {
            _jwtOptions = jwtOptions;
        }

        /// <summary>
        /// Serialize a token in a string fromat (Jwt format)
        /// </summary>
        /// <param name="user"> User View Model object</param>
        /// <returns>Token</returns>
        public string CreateToken(UserViewModel user)
        {
            var singinCredentials = GetSinginCredentials();
            var claims = GetClaims(user);
            var token = GenerateToken(singinCredentials, claims);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        /// <summary>
        /// Get jwt config key and hash it 
        /// </summary>
        /// <returns>SigningCredentials hashed key</returns>
        private SigningCredentials GetSinginCredentials()
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Value.Key));

            return new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        }

        /// <summary>
        /// Creates a list of claims
        /// </summary>
        /// <returns>List of claims</returns>
        private List<Claim> GetClaims(UserViewModel user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(JwtRegisteredClaimNames.NameId, user.Id),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iss, _jwtOptions.Value.Issuer)
            };

            claims.AddRange(user.Roles.Select(role=> new Claim(ClaimTypes.Role, role)));

            return claims;
        }

        /// <summary>
        /// Create a token with hashed credentials and a list of claims
        /// </summary>
        /// <param name="singinCredentials">Hashed credentials</param>
        /// <param name="claims">List of claims</param>
        /// <returns>JwtSecurityToken</returns>
        private JwtSecurityToken GenerateToken(SigningCredentials singinCredentials, List<Claim> claims)
        {
            var token = new JwtSecurityToken
            (
                issuer: _jwtOptions.Value.Issuer,
                claims: claims,
                expires: DateTime.Now.AddHours(Convert.ToDouble(_jwtOptions.Value.LifeTime)),
                signingCredentials: singinCredentials
            );

            return token;
        }
    }
}