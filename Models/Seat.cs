using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaApp.Models
{
    public class Seat
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int TheaterId { get; set; }
        public Theater Theater { get; set; }
        public bool IsAvailable { get; set; } = true;


    }
}
