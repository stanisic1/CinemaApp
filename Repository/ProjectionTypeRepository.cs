using CinemaApp.Interfaces;
using CinemaApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaApp.Repository
{
    public class ProjectionTypeRepository: IProjectionTypeRepository
    {
        private readonly AppDbContext _context;

        public ProjectionTypeRepository(AppDbContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<ProjectionType>> GetAllAsync()
        {
            return await _context.ProjectionTypes.ToListAsync();
        }

        public async Task<ProjectionType?> GetByIdAsync(int id)
        {
            return await _context.ProjectionTypes.FindAsync(id);
        }

    }
}
