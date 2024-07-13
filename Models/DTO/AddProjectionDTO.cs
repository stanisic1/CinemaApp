namespace CinemaApp.Models.DTO
{
    public class AddProjectionDTO
    {
        public int MovieId { get; set; }
        public int ProjectionTypeId { get; set; }
        public int TheaterId { get; set; }
        public DateTime DateTime { get; set; }
        public decimal Price { get; set; }
    }
}
