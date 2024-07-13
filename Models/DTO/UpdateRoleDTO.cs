using System.ComponentModel.DataAnnotations;

namespace CinemaApp.Models.DTO
{
    public class UpdateRoleDTO
    {
        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Role is required.")]
        [RegularExpression(@"^(User|Admin)$", ErrorMessage = "Role must be either 'User' or 'Admin'.")]
        public string Role { get; set; }
    }
}
