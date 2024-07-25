using System.ComponentModel.DataAnnotations;

namespace CinemaApp.Models
{
   
    public class Projection
    {
        public int Id { get; set; }

        public int MovieId { get; set; }
        [Required]
        public Movie Movie { get; set; }
        public int ProjectionTypeId { get; set; }
        [Required]
        public ProjectionType ProjectionType { get; set; }
        public int TheaterId { get; set; }
        [Required]
        public Theater Theater { get; set; }

        [Required]
        [FutureDate(ErrorMessage = "Date and time must be in the future.")]
        public DateTime DateTime { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
        public decimal Price { get; set; }
        public bool IsDeleted { get; set; } = false;

        public string? AdministratorId { get; set; }
        
        public ApplicationUser? Administrator { get; set; }
        public ICollection<Seat> Seats { get; set; }
        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }

    public class FutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime dateTime)
            {
                if (dateTime > DateTime.Now)
                {
                    return ValidationResult.Success;
                }
                return new ValidationResult(ErrorMessage ?? "The date must be in the future.");
            }
            return new ValidationResult("Invalid date format.");
        }
    }
}
