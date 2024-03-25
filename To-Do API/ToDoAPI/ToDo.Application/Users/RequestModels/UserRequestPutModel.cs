namespace ToDo.Application.Users.RequestModels
{
    public class UserRequestPutModel
    {
        public string? Username { get; set; }
        public string? PasswordHash { get; set; }
    }
}