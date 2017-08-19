using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ecommerce.Models 
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime CreatedAt { get; set; }

        public List<Order> CustomerOrders { get; set; }

        public Customer()
        {
            CustomerOrders = new List<Order>();
        }
    }
}