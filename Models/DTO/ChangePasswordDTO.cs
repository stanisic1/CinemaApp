namespace CinemaApp.Models.DTO
{
    public class ChangePasswordDTO
    {
        public string Username { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
