using System.ComponentModel.DataAnnotations;

namespace login_reg.Models
{
    public class User : BaseEntity
    {

        [Required]
        [MinLength(3)]
        public string first_name { get; set; }

        [Required]
        [MinLength(3)]
        public string last_name { get; set; }

        [Required]
        [EmailAddress]
        public string email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(9)]
        public string password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("password")]
        public string password_confirm { get; set; }

    }

}
