using CinemaApp.Models;

namespace CinemaApp.Interfaces
{
    public interface IProjectionTypeRepository
    {
        Task<IEnumerable<ProjectionType>> GetAllAsync();
        Task<ProjectionType?> GetByIdAsync(int id);
    }
}
