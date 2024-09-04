using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Models
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string EmailId { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

}
