namespace PizzaProject.API.Models.Requests.PizzaRequests
{
    public class PizzaUpdateModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        // public int ImageId { get; set; }
        public string? Description { get; set; }
        public int CaloryCount { get; set; }
    }
}
