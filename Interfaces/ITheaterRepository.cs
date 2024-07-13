using CinemaApp.Models;

namespace CinemaApp.Interfaces
{
    public interface ITheaterRepository
    {
        IEnumerable<Theater> GetAll();
        Theater GetById(int id);
    }
}
