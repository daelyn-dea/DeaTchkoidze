using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaProject.Domain.Entity
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int? AddressId { get; set; }
        public List<Pizza> Pizzas { get; set; } = new List<Pizza>();
        public Address? Address { get; set; }
        public List<int> PizzasIds { get; set; }
    }
}
