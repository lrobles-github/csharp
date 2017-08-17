using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner.Models
{
    public class Guest : BaseEntity
    {
        public int Id { get; set; }

        public int WeddingId { get; set; }

        public int UserId { get; set; } // guest

        public User User { get; set; }

    }

}