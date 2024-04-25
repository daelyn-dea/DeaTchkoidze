namespace Forum.API.Infrastructure.Authentication
{
    /// <summary>
    /// Configuration settings related to authentication.
    /// </summary>
    public class AuthenticationConfiguration
    {
        /// <summary>
        /// Gets or sets the secret key used for generating and validating JWT tokens.
        /// </summary>
        public string JwtSecretKey { get; set; } = default!;

        /// <summary>
        /// Gets or sets the issuer of the JWT token.
        /// </summary>
        public string JwtIssuer { get; set; } = default!;

        /// <summary>
        /// Gets or sets the audience of the JWT token.
        /// </summary>
        public string JwtAudience { get; set; } = default!;

        /// <summary>
        /// Gets or sets the expiration time (in minutes) for JWT tokens.
        /// </summary>
        public int JwtExpirationInMinutes { get; set; }
    }

}
