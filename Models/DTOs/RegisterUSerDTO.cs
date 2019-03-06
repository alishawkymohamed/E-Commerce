using System.ComponentModel.DataAnnotations;

namespace Models.DTOs
{
    public class RegisterUserDTO
    {
        public string FullName { get; set; }
        public string Username { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}