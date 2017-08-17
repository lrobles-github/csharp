using System;
using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner.Models
{
    public class WeddingViewModel : BaseEntity
    {

        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string SecondName { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        public string Address { get; set; }

    }
}