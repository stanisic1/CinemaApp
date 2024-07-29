using CinemaApp.Models;

namespace CinemaApp.Interfaces
{
    public interface ITheaterRepository
    {
        Task<IEnumerable<Theater>> GetAllAsync();
        Task<Theater?> GetByIdAsync(int id);
    }
}
