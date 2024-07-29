using CinemaApp.Models;
using CinemaApp.Models.DTO;
using System.Collections.Generic;

namespace CinemaApp.Interfaces
{
    public interface IProjectionRepository
    {
        IQueryable<Projection> GetProjectionsOfMovie(int movieId);
        Task<IEnumerable<Projection>> GetAllAsync(string? movieTitle, DateTime? dateFrom = null, DateTime? dateTo = null, int? projectionTypeId = null, int? theaterId = null, decimal? priceFrom = null, decimal? priceTo = null, string sortBy = "movie", bool sortDescending = false);
        Task<Projection?> GetByIdAsync(int id);
        Task AddAsync(Projection projection);
        Task AddSeatsAsync(IEnumerable<Seat> seats);
        Task<IEnumerable<Seat>> GetSeatsByProjectionIdAsync(int projectionId);
        Task DeleteSeatAsync(Seat seat);
        Task UpdateAsync(Projection projection);
        Task DeleteAsync(Projection projection);
        Task<bool> HasSoldTicketsAsync(int projectionId);
        Task LogicalDeleteAsync(Projection projection);
        Task<IEnumerable<Seat>> GetSeatsAsync(int projectionId);
        //void ClearProjectionsAdmin(string adminId);

    }
}
