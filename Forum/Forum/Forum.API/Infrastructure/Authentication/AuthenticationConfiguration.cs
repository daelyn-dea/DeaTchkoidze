namespace Forum.API.Infrastructure.Authentication
{
    public class AuthenticationConfiguration
    {
        public string JwtSecretKey { get; set; } = default!;
		public string JwtIssuer { get; set; } = default!;
		public string JwtAudience { get; set; } = default!;
		public int JwtExpirationInMinutes { get; set; }
    }
}
