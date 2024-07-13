using CinemaApp.Interfaces;
using CinemaApp.Models;

namespace CinemaApp.Repository
{
    public class ProjectionTypeRepository: IProjectionTypeRepository
    {
        private readonly AppDbContext _context;

        public ProjectionTypeRepository(AppDbContext context)
        {
            this._context = context;
        }
        public IEnumerable<ProjectionType> GetAll()
        {
            return _context.ProjectionTypes;
        }
        public ProjectionType GetById(int id)
        {
            return _context.ProjectionTypes.FirstOrDefault(p => p.Id == id);
        }

    }
}
