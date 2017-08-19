using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecommerce.Models 
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }

        public DateTime CreatedAt { get; set; }

        public List<Order> ProductOrders { get; set; }

        public Product()
        {
            ProductOrders = new List<Order>();
        }

    }
}