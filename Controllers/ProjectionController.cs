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
        public IActionResult GetMovieProjections (int id)
        {
            var projections = _projectionRepository.GetProjectionsOfMovie(id);

            if (projections == null)
            {
                return NotFound();
            }

            var projectionsDto = _mapper.Map<IEnumerable<ProjectionDTO>>(projections);
            return Ok(projectionsDto);
        }

        [HttpGet]
        [Route("api/projections")]
        public IActionResult GetProjections(
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
            var projections = _projectionRepository.GetAll(
            movieTitle,
            dateFrom,
            dateTo,
            projectionTypeId,
            theaterId,
            priceFrom,
            priceTo,
            sortBy,
            sortDescending);

           /* var projectionsDto = projections.Select(p => new ProjectionDTO
            {
                Id = p.Id,
                MovieId = p.Movie.Id,
                MovieTitle = p.Movie.Title,
                ProjectionType = p.ProjectionType.Type.ToString(),
                Theater = p.Theater.Type.ToString(),
                DateTime = p.DateTime,
                Price = p.Price,
                UnsoldTicketsCount = p.Theater.Capacity - p.Tickets.Count()
            }).ToList();*/

            var projectionsDto = _mapper.Map<IEnumerable<ProjectionDTO>>(projections);
            return Ok(projectionsDto);
            
        }
        [HttpGet]
        [Route("api/projections/{projectionId}/seats")]
        public IActionResult GetAvailableSeats (int projectionId)
        {
            var seats = _projectionRepository.GetSeats(projectionId);

            if(seats == null)
            {
                return NotFound();
            }

            /*var availableSeats = seats.Where(s => s.IsAvailable);

            var availableSeatsDTO = _mapper.Map<IEnumerable<SeatDTO>>(availableSeats);
            return Ok(availableSeatsDTO);*/

            var seatsDTO = _mapper.Map<IEnumerable<SeatDTO>>(seats);
            return Ok(seatsDTO);

        }

       

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("api/projections")]
        public IActionResult PostProjection([FromBody] AddProjectionDTO projectionDto)
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

            var movie = _movieRepository.GetById(projectionDto.MovieId);
            if (movie == null)
            {
                return BadRequest(new { Message = $"Movie with ID {projectionDto.MovieId} not found." });
            }

            var theater = _theaterRepository.GetById(projectionDto.TheaterId);
            if (theater == null)
            {
                return BadRequest(new { Message = $"Theater with ID {projectionDto.TheaterId} not found." });
            }

            var projectionType = _projectionTypeRepository.GetById(projectionDto.ProjectionTypeId);
            if (projectionType == null)
            {
                return BadRequest(new { Message = $"ProjectionType with ID {projectionDto.ProjectionTypeId} not found." });
            }

            var administratorId = _userManager.GetUserId(User);
            if (administratorId == null)
            {
                return BadRequest(new { Message = "Administrator ID not found for the current user." });
            }

            var administrator = _userManager.FindByIdAsync(administratorId).Result;
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

            _projectionRepository.Add(projection);
            return CreatedAtAction("GetProjection", new { id = projection.Id }, projection);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        [Route("api/projections/{id}")]
        public IActionResult PutProjection(int id, Projection projection)
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
                _projectionRepository.Update(projection);
            }

            catch (Exception ex)
            {
                return BadRequest($"Failed to update telephone. Error: {ex.Message}");
            }

            return Ok(projection);

        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("api/projections/{id}")]
        public IActionResult DeleteProjection(int id)
        {
            var projection = _projectionRepository.GetById(id);
            if (projection == null)
            {
                return NotFound();
            }

            if (_projectionRepository.HasProjections(id))
            {
                _projectionRepository.LogicalDelete(projection);
            }
            else
            {

                _projectionRepository.Delete(projection);
            }
            return NoContent();
        }

        [HttpGet]
        [Route("api/projections/{id}")]
        public IActionResult GetProjection(int id)
        {
            var projection = _projectionRepository.GetById(id);
            if (projection == null)
            {
                return NotFound();
            }
            var projectionDto = _mapper.Map<ProjectionDTO>(projection);
            return Ok(projectionDto);
            
        }

    }
}
