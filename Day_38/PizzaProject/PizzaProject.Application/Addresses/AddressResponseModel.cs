using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaProject.Application.Addresses
{
    public class AddressResponseModel
    {
        public int UserId { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string? Region { get; set; }
        public string? Description { get; set; }
    }
}
