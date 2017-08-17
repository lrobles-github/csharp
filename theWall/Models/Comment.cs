using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;


namespace theWall.Models
{
    public class Comment
    {
        [Key]
        public int id { get; set; }
        
        [Key]
        public int message_id { get; set; }

        [Key]
        public int user_id { get; set; }
        
        [Required]
        public string comment { get; set; }

        public DateTime created_at { get; set; }
    }

}