namespace PizzaProject.Application.Exceptions
{
    public class UserDoesnotHaveOrderOfThisPizza : Exception
    {
        public string Code = "UserDoesnotHaveOrderOfThisPizza";

        public UserDoesnotHaveOrderOfThisPizza(string message) : base(message) { }

    }
}
