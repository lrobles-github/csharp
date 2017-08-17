using System.ComponentModel.DataAnnotations;

namespace theWall.Models
{
    public class User : BaseEntity
    {

        [Key]
        public int id { get; set; }
        
        [Required]
        [MinLength(3)]
        public string firstname { get; set; }

        [Required]
        [MinLength(3)]
        public string lastname { get; set; }

        [Required]
        [EmailAddress]
        public string email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(8)]
        public string password { get; set; }

        [DataType(DataType.Password)]
        [Compare("password")]
        public string passwordconfirm { get; set; }

    }

}
