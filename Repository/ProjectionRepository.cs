using CinemaApp.Interfaces;
using CinemaApp.Models;
using CinemaApp.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace CinemaApp.Repository
{
    public class ProjectionRepository: IProjectionRepository
    {
        private readonly AppDbContext _context;

        public ProjectionRepository(AppDbContext context)
        {
            this._context = context;
        }

        public IQueryable<Projection> GetProjectionsOfMovie(int movieId)
        {
            var query = _context.Projections
                .Include(p => p.Movie)
                .Include(p => p.Theater)
                .Include(p => p.ProjectionType)
                .Include(p => p.Tickets)
                .Where(p => p.MovieId == movieId)
                .AsQueryable();

            return query;
        }

        public IQueryable<Projection> GetAll(
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

            return query;
        }

        public Projection GetById(int id)
        {
            var query = _context.Projections
               .Include(p => p.Movie)
               .Include(p => p.Theater)
               .Include(p => p.ProjectionType)
               .Include(p => p.Tickets)
               .FirstOrDefault(p => p.Id == id);
            return query;
            
        }

        public List<SeatDTO> GetSeats(int projectionId)
        {
            var projection = _context.Projections
                .Include(p => p.Theater)
                .FirstOrDefault(p => p.Id == projectionId);

            if (projection == null)
            {
                return null; 
            }
            
            var seats = _context.Seats
                .Where(s => s.ProjectionId == projection.Id)
                .Select(s => new SeatDTO
                {
                    Id = s.Id,
                    Number = s.Number,
                    IsAvailable = s.IsAvailable,
                    Theater = projection.Theater.Type.ToString() 
                }).ToList();

            return seats;
        }

        public void Add(Projection projection)
        {
            _context.Projections.Add(projection);
            _context.SaveChanges();
        }

        public void AddSeats(IEnumerable<Seat> seats)
        {
            _context.Seats.AddRange(seats);
            _context.SaveChanges();
        }

        public IEnumerable<Seat> GetSeatsByProjectionId(int projectionId)
        {
            return _context.Seats.Where(s => s.ProjectionId == projectionId).ToList();
        }


        public void Update(Projection projection)
        {
            _context.Entry(projection).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public void Delete(Projection projection)
        {
            _context.Projections.Remove(projection);
            _context.SaveChanges();
        }

        public void Delete(Seat seat)
        {
            _context.Seats.Remove(seat);
            _context.SaveChanges();
        }

        public bool HasProjections(int projectionId)
        {
            return _context.Tickets.Any(p => p.ProjectionId == projectionId);
        }

        public void LogicalDelete(Projection projection)
        {
            projection.IsDeleted = true;
            _context.Projections.Update(projection);
            _context.SaveChanges();
        }


    }
}
