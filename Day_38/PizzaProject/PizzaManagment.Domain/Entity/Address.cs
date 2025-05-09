﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaProject.Domain.Entity
{
    public class Address
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string? Region { get; set; }
        public string? Description { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
