using CinemaApp.Interfaces;
using CinemaApp.Models;

namespace CinemaApp.Repository
{
    public class TheaterRepository: ITheaterRepository
    {
        private readonly AppDbContext _context;

        public TheaterRepository(AppDbContext context)
        {
            this._context = context;
        }
        public IEnumerable<Theater> GetAll()
        {
            return _context.Theaters;
        }
        public Theater GetById(int id)
        {
            return _context.Theaters.FirstOrDefault(p => p.Id == id);
        }

    }
}
