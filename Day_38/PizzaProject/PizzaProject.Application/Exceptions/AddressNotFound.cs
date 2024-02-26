namespace PizzaProject.Application.Exceptions
{
    public class AddressNotFoundException : Exception
    {
        public string Code = "AddressNotFound";

        public AddressNotFoundException(string message) : base(message) { }
    }
}
