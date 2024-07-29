using CinemaApp.Interfaces;
using CinemaApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaApp.Repository
{
    public class TheaterRepository: ITheaterRepository
    {
        private readonly AppDbContext _context;

        public TheaterRepository(AppDbContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<Theater>> GetAllAsync()
        {
            return await _context.Theaters.ToListAsync();
        }

        public async Task<Theater?> GetByIdAsync(int id)
        {
            return await _context.Theaters.FindAsync(id);
        }

    }
}
