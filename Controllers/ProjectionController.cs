using AutoMapper;
using AutoMapper.QueryableExtensions;
using CinemaApp.Interfaces;
using CinemaApp.Models;
using CinemaApp.Models.DTO;
using CinemaApp.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CinemaApp.Controllers
{
    
    [ApiController]
    public class ProjectionController : ControllerBase
    {
        private readonly IProjectionTypeRepository _projectionTypeRepository;
        private readonly ITheaterRepository _theaterRepository;
        private readonly IMovieRepository _movieRepository;
        private readonly IProjectionRepository _projectionRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProjectionController(IProjectionTypeRepository projectionTypeRepository, ITheaterRepository theaterRepository, IMovieRepository movieRepository, IProjectionRepository projectionRepository, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _projectionTypeRepository = projectionTypeRepository;
            _theaterRepository = theaterRepository;
            _movieRepository = movieRepository;;
            _projectionRepository = projectionRepository;
            _mapper = mapper;
            _userManager = userManager;

        }

        [Authorize(Roles = "User")]
        [HttpGet]
        [Route("api/projections/movies/{id}")]
        public async Task<IActionResult> GetMovieProjections(int id)
        {
            var projections = _projectionRepository.GetProjectionsOfMovie(id);

            if (projections == null)
            {
                return NotFound();
            }

            var projectionsDto = await projections
                .ProjectTo<ProjectionDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return Ok(projectionsDto);
        }

        [HttpGet]
        [Route("api/projections")]
        public async Task<IActionResult> GetProjections(
            [FromQuery] string? movieTitle,
            [FromQuery] DateTime? dateFrom,
            [FromQuery] DateTime? dateTo,
            [FromQuery] int? projectionTypeId,
            [FromQuery] int? theaterId,
            [FromQuery] decimal? priceFrom,
            [FromQuery] decimal? priceTo,
            [FromQuery] string sortBy = "movie",
            [FromQuery] bool sortDescending = false)
        {
            var projections = await _projectionRepository.GetAllAsync(
                movieTitle,
                dateFrom,
                dateTo,
                projectionTypeId,
                theaterId,
                priceFrom,
                priceTo,
                sortBy,
                sortDescending);

            var projectionsDto = _mapper.Map<IEnumerable<ProjectionDTO>>(projections);
            return Ok(projectionsDto);
        }

        [HttpGet]
        [Route("api/projections/{projectionId}/seats")]
        public async Task<IActionResult> GetAvailableSeats(int projectionId)
        {
            var seats = await _projectionRepository.GetSeatsAsync(projectionId);

            if (seats == null)
            {
                return NotFound();
            }

            var seatsDto = _mapper.Map<IEnumerable<SeatDTO>>(seats);
            return Ok(seatsDto);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("api/projections")]
        public async Task<IActionResult> PostProjection([FromBody] AddProjectionDTO projectionDto)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                                              .Select(e => e.ErrorMessage)
                                              .ToList();
                return BadRequest(new { Message = "Invalid model state.", Errors = errors });
            }

            if (projectionDto.DateTime <= DateTime.Now)
            {
                return BadRequest(new { Message = "Projection time must be in the future." });
            }

            var movie = await _movieRepository.GetByIdAsync(projectionDto.MovieId);
            if (movie == null)
            {
                return BadRequest(new { Message = $"Movie with ID {projectionDto.MovieId} not found." });
            }

            var theater = await _theaterRepository.GetByIdAsync(projectionDto.TheaterId);
            if (theater == null)
            {
                return BadRequest(new { Message = $"Theater with ID {projectionDto.TheaterId} not found." });
            }

            var projectionType = await _projectionTypeRepository.GetByIdAsync(projectionDto.ProjectionTypeId);
            if (projectionType == null)
            {
                return BadRequest(new { Message = $"ProjectionType with ID {projectionDto.ProjectionTypeId} not found." });
            }

            var administratorId = _userManager.GetUserId(User);
            if (administratorId == null)
            {
                return BadRequest(new { Message = "Administrator ID not found for the current user." });
            }

            var administrator = await _userManager.FindByIdAsync(administratorId);
            if (administrator == null)
            {
                return BadRequest(new { Message = $"Administrator with ID {administratorId} not found." });
            }

            var projection = new Projection
            {
                MovieId = projectionDto.MovieId,
                Movie = movie,
                ProjectionTypeId = projectionDto.ProjectionTypeId,
                ProjectionType = projectionType,
                TheaterId = projectionDto.TheaterId,
                Theater = theater,
                DateTime = projectionDto.DateTime,
                Price = projectionDto.Price,
                AdministratorId = administratorId,
                Administrator = administrator,
                Tickets = new List<Ticket>()
            };

            await _projectionRepository.AddAsync(projection);

            await AddSeatsForProjectionAsync(projection);

            return CreatedAtAction("GetProjection", new { id = projection.Id }, projection);
        }

        private async Task AddSeatsForProjectionAsync(Projection projection)
        {
            var theater = await _theaterRepository.GetByIdAsync(projection.TheaterId);
            if (theater == null)
            {
                throw new Exception("Theater not found");
            }

            var seats = new List<Seat>();
            for (int seatNumber = 1; seatNumber <= theater.Capacity; seatNumber++)
            {
                seats.Add(new Seat
                {
                    Number = seatNumber,
                    TheaterId = theater.Id,
                    ProjectionId = projection.Id,
                    IsAvailable = true
                });
            }

            await _projectionRepository.AddSeatsAsync(seats);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        [Route("api/projections/{id}")]
        public async Task<IActionResult> PutProjection(int id, Projection projection)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != projection.Id)
            {
                return BadRequest();
            }

            try
            {
                await _projectionRepository.UpdateAsync(projection);
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to update projection. Error: {ex.Message}");
            }

            return Ok(projection);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("api/projections/{id}")]
        public async Task<IActionResult> DeleteProjection(int id)
        {
            var projection = await _projectionRepository.GetByIdAsync(id);
            if (projection == null)
            {
                return NotFound();
            }

            bool isLogicalDelete = false;

            if (await _projectionRepository.HasSoldTicketsAsync(id))
            {
                await _projectionRepository.LogicalDeleteAsync(projection);
                isLogicalDelete = true;
            }
            else
            {
                var relatedSeats = await _projectionRepository.GetSeatsByProjectionIdAsync(id);
                if (relatedSeats.Any())
                {
                    foreach (var seat in relatedSeats)
                    {
                        await _projectionRepository.DeleteSeatAsync(seat);
                    }
                }

                await _projectionRepository.DeleteAsync(projection);
            }

            var response = new
            {
                IsLogicalDelete = isLogicalDelete,
                Message = isLogicalDelete ? "Logical deletion occurred." : "Projection deleted successfully."
            };
            return Ok(response);
        }

        [HttpGet]
        [Route("api/projections/{id}")]
        public async Task<IActionResult> GetProjection(int id)
        {
            var projection = await _projectionRepository.GetByIdAsync(id);
            if (projection == null)
            {
                return NotFound();
            }
            var projectionDto = _mapper.Map<ProjectionDTO>(projection);
            return Ok(projectionDto);
        }

    }
}
