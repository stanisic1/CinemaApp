using System.ComponentModel.DataAnnotations;

namespace CinemaApp.Models.DTO
{
    public class RegistrationDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Username can only contain alphanumeric characters without spaces.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        public string Role { get; set; }
    }
}
