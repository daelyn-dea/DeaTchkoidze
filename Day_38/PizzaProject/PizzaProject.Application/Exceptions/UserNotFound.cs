namespace PizzaProject.Application.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public string Code = "UserNotFound";

        public UserNotFoundException(string message) : base(message) { }
    }
}
