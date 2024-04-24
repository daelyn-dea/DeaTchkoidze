using Microsoft.AspNetCore.Http;

namespace PizzaProject.Application.Pizzas
{
    public class PizzaRequestModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
      //  public IFormFile Image { get; set; } //TODO: ფოტოების ატვირთვა
        public string? Description { get; set; }
        public int CaloryCount { get; set; }
    }
}
