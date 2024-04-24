namespace PizzaProject.API.Models.Responses.PizzaResponses
{
    public class PizzaDtoModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        // public int ImageId { get; set; }
        public string? Description { get; set; }
        public int CaloryCount { get; set; }
    }
}