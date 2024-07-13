using System.ComponentModel.DataAnnotations;

namespace CinemaApp.Models
{

    public enum TheaterEnum
    {
        [Display(Name = "Movie House")]
        MovieHouse = 1,

        [Display(Name = "Theater Hall")]
        TheaterHall = 2,

        [Display(Name = "Picture Dream")]
        PictureDream = 3
    }

    public class Theater
    {
        public int Id { get; set; }
        public int Capacity { get; set; }
        public TheaterEnum Type { get; set; }
        public ICollection<Seat> Seats { get; set; }
        public ICollection<ProjectionType> ProjectionTypes { get; set; }
    }
}
