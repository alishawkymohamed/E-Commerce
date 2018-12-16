using System.ComponentModel.DataAnnotations;

namespace WebApi.Filters.Models
{
    public class UserLoginDTO
    {
        [Required]
        [MaxLength(450)]
        public string Username { get; set; }
        [Required]
        [MaxLength(450)]
        public string Password { get; set; }
    }
}
