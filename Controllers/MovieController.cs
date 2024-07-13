using CinemaApp.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CinemaApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace CinemaApp.Controllers
{
    
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieRepository _movieRepository;

        public MovieController (IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        [HttpGet]
        [Route("api/movies")]
        public IActionResult GetMovies(string? titleFilter,
            string? genreFilter,
            string? distributorFilter,
            string? countryFilter,
            int? durationFrom,
            int? durationTo,
            int? yearFromFilter,
            int? yearToFilter,
            string? sortOrder)
        {
            return Ok(_movieRepository.GetAll(titleFilter, genreFilter, distributorFilter, countryFilter, durationFrom, durationTo, yearFromFilter, yearToFilter, sortOrder).ToList());
        }

        [HttpGet]
        [Route("api/movies/{id}")]
        public IActionResult GetMovie(int id)
        {
            var movie = _movieRepository.GetById(id);
            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("api/movies")]
        public IActionResult PostMovie(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                //return BadRequest(ModelState);

                var errors = ModelState.Values.SelectMany(v => v.Errors)
                                      .Select(e => e.ErrorMessage)
                                      .ToList();
                return BadRequest(new { Message = "Invalid model state.", Errors = errors });
            }

            _movieRepository.Add(movie);
            return CreatedAtAction("GetMovie", new { id = movie.Id }, movie);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        [Route("api/movies/{id}")]
        public IActionResult PutMovie(int id, Movie movie)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != movie.Id)
            {
                return BadRequest();
            }

            try
            {
                _movieRepository.Update(movie);   
            }

            catch (Exception ex)
            {
                return BadRequest($"Failed to update telephone. Error: {ex.Message}");
            }

            return Ok(movie);
            
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("api/movies/{id}")]
        public IActionResult DeleteMovie(int id)
        {
            var movie = _movieRepository.GetById(id);
            if (movie == null)
            {
                return NotFound();
            }

            if (_movieRepository.HasProjections(id))
            {
                _movieRepository.LogicalDelete(movie);
            }
            else { 

                _movieRepository.Delete(movie);
            }
            return NoContent();
        }
    }
}
