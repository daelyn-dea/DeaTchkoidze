namespace PizzaProject.API.Models.Requests.OrderRequest
{
    public class OrderCreateModel
    {
        public int UserId { get; set; }
        public int AddressId { get; set; }
        public List<int> PizzasIds { get; set; }
    }
}
