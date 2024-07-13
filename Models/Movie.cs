using System.ComponentModel.DataAnnotations;

namespace CinemaApp.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string? Director { get; set; }
        public string? Actors { get; set; }
        public string? Genre { get; set; }
        [Required]
        public int Duration { get; set; }
        [Required]
        public string Distributor { get; set; }
        [Required]
        public string CountryOrigin { get; set; }
        [Required]
        public int ReleaseYear { get; set; }
        public string? Description { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
