namespace PizzaProject.Application.Orders
{
    public class OrderResponseModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public List<int> PizzasIds { get; set; }
    }
}
