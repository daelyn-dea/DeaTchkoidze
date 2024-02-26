namespace PizzaProject.Application.Exceptions
{
    public class OrderNotFoundException : Exception
    {
        public string Code = "OrderNotFound";

        public OrderNotFoundException(string message) : base(message) { }
    }
}