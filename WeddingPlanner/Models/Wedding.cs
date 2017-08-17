using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner.Models
{
    public class Wedding : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public DateTime Date { get; set; }

        public DateTime CreatedAt { get; set; }
        
        public string Address { get; set; }

        public int UserId { get; set; } // creator
        
        public List<Guest> Guests { get; set; }

        public Wedding()
        {
            Guests = new List<Guest>(); // guests
        }
    }
}