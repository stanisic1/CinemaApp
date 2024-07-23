﻿using CinemaApp.Models;
using CinemaApp.Models.DTO;

namespace CinemaApp.Interfaces
{
    public interface IProjectionRepository
    {
        IQueryable<Projection> GetProjectionsOfMovie(int movieId);
        IQueryable<Projection> GetAll(
          string? movieTitle,
        DateTime? dateFrom = null,
        DateTime? dateTo = null,
        int? projectionTypeId = null,
        int? theaterId = null,
        decimal? priceFrom = null,
        decimal? priceTo = null,
        string sortBy = "movie",
        bool sortDescending = false);
        Projection GetById(int id);
        void Add(Projection projection);
        void AddSeats(IEnumerable<Seat> seats);
        void Update(Projection projection);
        void Delete(Projection projection);
        bool HasProjections(int projectionId);
        void LogicalDelete(Projection projection);
        List<SeatDTO> GetSeats(int projectionId);
    }
}
