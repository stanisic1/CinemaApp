using CinemaApp.Models;

namespace CinemaApp.Interfaces
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetAllAsync(string? titleFilter,
            string? genreFilter,
            string? distributorFilter,
            string? countryFilter,
            int? durationFrom,
            int? durationTo,
            int? yearFromFilter,
            int? yearToFilter,
            string? sortOrder);
        Movie GetById (int id);
        Task<Movie?> GetByIdAsync(int id);
        Task AddAsync(Movie movie);
        Task UpdateAsync(Movie movie);
        Task DeleteAsync(Movie movie);
        Task<bool> HasProjectionsAsync(int movieId);
        Task LogicalDeleteAsync(Movie movie);
    }
    
}
