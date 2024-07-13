using CinemaApp.Models;

namespace CinemaApp.Interfaces
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> GetAll(string? titleFilter,
            string? genreFilter,
            string? distributorFilter,
            string? countryFilter,
            int? durationFrom,
            int? durationTo,
            int? yearFromFilter,
            int? yearToFilter,
            string? sortOrder);
        Movie GetById (int id);
        void Add(Movie movie);
        void Update(Movie movie);
        void Delete(Movie movie);
        bool HasProjections(int movieId);
        void LogicalDelete(Movie movie);
    }
    
}
