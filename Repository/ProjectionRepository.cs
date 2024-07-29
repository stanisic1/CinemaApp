using CinemaApp.Interfaces;
using CinemaApp.Models;
using CinemaApp.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace CinemaApp.Repository
{
    public class ProjectionRepository : IProjectionRepository
    {
        private readonly AppDbContext _context;

        public ProjectionRepository(AppDbContext context)
        {
            this._context = context;
        }

        public IQueryable<Projection> GetProjectionsOfMovie(int movieId)
        {
            return _context.Projections.Where(p => p.MovieId == movieId).AsQueryable();
        }

        public async Task<IEnumerable<Projection>> GetAllAsync(
       string? movieTitle,
       DateTime? dateFrom = null,
       DateTime? dateTo = null,
       int? projectionTypeId = null,
       int? theaterId = null,
       decimal? priceFrom = null,
       decimal? priceTo = null,
       string sortBy = "movie",
       bool sortDescending = false)
        {
            var query = _context.Projections
                .Include(p => p.Movie)
                .Include(p => p.Theater)
                .Include(p => p.ProjectionType)
                .Include(p => p.Tickets)
                .AsQueryable();


            if (!string.IsNullOrEmpty(movieTitle))
            {
                query = query.Where(p => p.Movie.Title.Contains(movieTitle));
            }

            if (dateFrom.HasValue)
            {
                query = query.Where(p => p.DateTime >= dateFrom);
            }

            if (dateTo.HasValue)
            {
                query = query.Where(p => p.DateTime <= dateTo);
            }

            if (projectionTypeId.HasValue)
            {
                query = query.Where(p => p.ProjectionTypeId == projectionTypeId);
            }

            if (theaterId.HasValue)
            {
                query = query.Where(p => p.TheaterId == theaterId);
            }

            if (priceFrom.HasValue)
            {
                query = query.Where(p => p.Price >= priceFrom);
            }

            if (priceTo.HasValue)
            {
                query = query.Where(p => p.Price <= priceTo);
            }

            query = sortBy.ToLower() switch
            {
                "date" => sortDescending ? query.OrderByDescending(p => p.DateTime) : query.OrderBy(p => p.DateTime),
                "projectiontype" => sortDescending ? query.OrderByDescending(p => p.ProjectionType.Type) : query.OrderBy(p => p.ProjectionType.Type),
                "theater" => sortDescending ? query.OrderByDescending(p => p.Theater.Type) : query.OrderBy(p => p.Theater.Type),
                "price" => sortDescending ? query.OrderByDescending(p => p.Price) : query.OrderBy(p => p.Price),
                _ => sortDescending ? query.OrderByDescending(p => p.Movie.Title).ThenByDescending(p => p.DateTime) : query.OrderBy(p => p.Movie.Title).ThenBy(p => p.DateTime)
            };

            return await query.ToListAsync();
        }

        public async Task<Projection?> GetByIdAsync(int id)
        {
            return await _context.Projections.
                Include(p => p.Movie)
               .Include(p => p.Theater)
               .Include(p => p.ProjectionType)
               .Include(p => p.Tickets).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Seat>> GetSeatsAsync(int projectionId)
        {
            var projectionExists = await _context.Projections.Include(p => p.Theater).AnyAsync(p => p.Id == projectionId);
            if (!projectionExists)
            {
                throw new KeyNotFoundException($"Projection with ID {projectionId} not found.");
            }
            return await _context.Seats.Where(s => s.ProjectionId == projectionId).ToListAsync();
        }

        public async Task AddAsync(Projection projection)
        {
            await _context.Projections.AddAsync(projection);
            await _context.SaveChangesAsync();
        }

        public async Task AddSeatsAsync(IEnumerable<Seat> seats)
        {
            await _context.Seats.AddRangeAsync(seats);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Seat>> GetSeatsByProjectionIdAsync(int projectionId)
        {
            return await _context.Seats.Where(s => s.ProjectionId == projectionId).ToListAsync();
        }

        public async Task UpdateAsync(Projection projection)
        {
            _context.Projections.Update(projection);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSeatAsync(Seat seat)
        {
            _context.Seats.Remove(seat);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Projection projection)
        {
            _context.Projections.Remove(projection);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> HasSoldTicketsAsync(int projectionId)
        {
            return await _context.Tickets.AnyAsync(ticket => ticket.ProjectionId == projectionId);
        }

        public async Task LogicalDeleteAsync(Projection projection)
        {
            projection.IsDeleted = true;
            _context.Projections.Update(projection);
            await _context.SaveChangesAsync();
        }

    }
}
