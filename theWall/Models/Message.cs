using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;


namespace theWall.Models
{
    public class Message
    {
        [Key]
        public int id { get; set; }
        
        [Key]
        public int user_id { get; set; }

        [Required]
        public string message { get; set; }

        public DateTime created_at { get; set; }
    }
}