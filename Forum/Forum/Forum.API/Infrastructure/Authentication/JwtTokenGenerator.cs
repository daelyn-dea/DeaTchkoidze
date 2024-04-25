using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Forum.API.Infrastructure.Authentication
{
    /// <summary>
    /// TokenGenerator
    /// </summary>
    public class JwtTokenGenerator
    {
        /// <summary>
        /// Method For Generate Jwt Token
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="id"></param>
        /// <param name="roles"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static string GenerateToken(string userName, string id, IList<string> roles, IOptions<AuthenticationConfiguration> options)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(options.Value.JwtSecretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                new Claim(ClaimTypes.Name, userName),
                new Claim(ClaimTypes.NameIdentifier, id),
                new Claim(ClaimTypes.Role, string.Join(",", roles))
            }),
                Issuer = options.Value.JwtIssuer,
                Audience = options.Value.JwtAudience,
                Expires = DateTime.UtcNow.AddMinutes(options.Value.JwtExpirationInMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);

        }
    }
}
