using CinemaApp.Interfaces;
using CinemaApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CinemaApp.Repository
{
    public class MovieRepository: IMovieRepository
    {
        private readonly AppDbContext _context;

        public MovieRepository(AppDbContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<Movie>> GetAllAsync(string? titleFilter,
            string? genreFilter,
            string? distributorFilter,
            string? countryFilter,
            int? durationFrom,
            int? durationTo,
            int? yearFromFilter,
            int? yearToFilter,
            string? sortOrder)
        {

            var movies = from m in _context.Movies select m;

            if (!string.IsNullOrEmpty(titleFilter))
            {
                movies = movies.Where(m => m.Title.Contains(titleFilter));
            }

            if (!string.IsNullOrEmpty(genreFilter))
            {
                movies = movies.Where(m => m.Genre.Contains(genreFilter));
            }

            if (!string.IsNullOrEmpty(distributorFilter))
            {
                movies = movies.Where(m => m.Distributor.Contains(distributorFilter));
            }

            if (!string.IsNullOrEmpty(countryFilter))
            {
                movies = movies.Where(m => m.CountryOrigin.Contains(countryFilter));
            }

            if (yearFromFilter.HasValue)
            {
                movies = movies.Where(m => m.ReleaseYear >= yearFromFilter);
            }

            if (yearToFilter.HasValue)
            {
                movies = movies.Where(m => m.ReleaseYear <= yearToFilter);
            }

            if (durationFrom.HasValue)
            {
                movies = movies.Where(m => m.Duration >= durationFrom);
            }

            if (durationTo.HasValue)
            {
                movies = movies.Where(m => m.Duration <= durationTo);
            }

            movies = sortOrder switch
            {
                "title" => movies.OrderBy(m => m.Title),
                "title_desc" => movies.OrderByDescending(m => m.Title),
                "genre" => movies.OrderBy(m => m.Genre),
                "genre_desc" => movies.OrderByDescending(m => m.Genre),
                "duration" => movies.OrderBy(m => m.Duration),
                "duration_desc" => movies.OrderByDescending(m => m.Duration),
                "distributor" => movies.OrderBy(m => m.Distributor),
                "distributor_desc" => movies.OrderByDescending(m => m.Distributor),
                "country" => movies.OrderBy(m => m.CountryOrigin),
                "country_desc" => movies.OrderByDescending(m => m.CountryOrigin),
                "year" => movies.OrderBy(m => m.ReleaseYear),
                "year_desc" => movies.OrderByDescending(m => m.ReleaseYear),
                _ => movies.OrderBy(m => m.Title),
            };

            return await movies.Where(m => !m.IsDeleted).ToListAsync();
        }

        public async Task<Movie?> GetByIdAsync(int id)
        {
            return await _context.Movies.FindAsync(id);
        }

        public async Task AddAsync(Movie movie)
        {
            await _context.Movies.AddAsync(movie);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Movie movie)
        {
            _context.Movies.Update(movie);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Movie movie)
        {
            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> HasProjectionsAsync(int movieId)
        {
            return await _context.Projections.AnyAsync(p => p.MovieId == movieId);
        }

        public async Task LogicalDeleteAsync(Movie movie)
        {
            movie.IsDeleted = true;
            _context.Movies.Update(movie);
            await _context.SaveChangesAsync();
        }
    }
}
