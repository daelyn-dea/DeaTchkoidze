namespace PizzaProject.Application.Orders
{
    public class OrderRequestModel
    {
        public int UserId { get; set; }
        public int AddressId { get; set; }
        public List<int> PizzasIds { get; set; }
    }
}
