using System.ComponentModel.DataAnnotations;

namespace CinemaApp.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public int ProjectionId { get; set; }
        [Required(ErrorMessage = "Projection is required.")]
        public Projection Projection { get; set; }
        public int SeatId { get; set; }
        [Required(ErrorMessage = "Seat is required.")]
        public Seat Seat { get; set; }
        [Required]
        public DateTime SaleDateTime { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
