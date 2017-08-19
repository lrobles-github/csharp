using System;
using System.ComponentModel.DataAnnotations;

namespace ecommerce.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public int Quantity { get; set; }

        public DateTime CreatedAt { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}