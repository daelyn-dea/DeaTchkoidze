namespace ToDo.API.Infrastructure.Authentication
{
    public class AuthenticationConfiguration
    {
        public string JwtSecretKey { get; set; }
        public string JwtIssuer { get; set; }
        public string JwtAudience { get; set; }
        public int JwtExpirationInMinutes { get; set; }
    }
}
