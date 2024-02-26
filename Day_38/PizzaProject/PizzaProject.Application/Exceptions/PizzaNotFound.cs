namespace PizzaProject.Application.Exceptions
{
    public class PizzaNotFoundException : Exception
    {
        public string Code = "PizzaNotFound";

        public PizzaNotFoundException(string message) : base(message) { }

    }
}
