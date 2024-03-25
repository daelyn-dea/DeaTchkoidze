using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ToDo.Domain.Users;

namespace ToDo.API.Infrastructure.Authentication
{
    public class JwtTokenGenerator
    {
        public static string GenerateToken(string userName, string id, IOptions<AuthenticationConfiguration> options)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(options.Value.JwtSecretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                new Claim(ClaimTypes.Name, userName),
                new Claim(ClaimTypes.NameIdentifier, id)
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
