namespace Forum.Application.Authentications.RequestModels
{
    public class RequestLoginModel
    {
        public string Username { get; set; } = default!;
        public string Password { get; set; } = default!;
        public bool RememberLogin { get; set; }
    }
}
