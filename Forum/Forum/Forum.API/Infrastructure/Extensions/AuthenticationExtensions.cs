using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Forum.API.Infrastructure.Extensions
{
    /// <summary>
    /// Extension methods for configuring token-based authentication.
    /// </summary>
    public static class AuthenticationExtensions
    {
        /// <summary>
        /// Configures token-based authentication using JWT tokens.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the authentication services to.</param>
        /// <param name="config">The <see cref="IConfiguration"/> containing authentication configuration settings.</param>
        public static void AddTokenAuthentication(this IServiceCollection services, IConfiguration config)
        {
            var keyBytes = Encoding.ASCII.GetBytes(config.GetValue<string>("AuthenticationConfiguration:JwtSecretKey"));

            services.AddAuthentication(x =>
            {
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = config.GetValue<string>("AuthenticationConfiguration:JwtIssuer"),
                    ValidAudience = config.GetValue<string>("AuthenticationConfiguration:JwtAudience"),
                    IssuerSigningKey = new SymmetricSecurityKey(keyBytes),

                };
            });
        }
    }
}
