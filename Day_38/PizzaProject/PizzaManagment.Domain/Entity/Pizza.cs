namespace PizzaProject.Domain.Entity
{
    public class Pizza
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        // public int ImageId { get; set; }
        public string? Description { get; set; }
        public int CaloryCount { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
