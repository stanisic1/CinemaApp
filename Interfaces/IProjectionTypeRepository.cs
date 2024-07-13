using CinemaApp.Models;

namespace CinemaApp.Interfaces
{
    public interface IProjectionTypeRepository
    {
        IEnumerable<ProjectionType> GetAll();
        ProjectionType GetById(int id);
    }
}
