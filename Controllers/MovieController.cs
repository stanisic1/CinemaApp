using CinemaApp.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CinemaApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> GetMovies(string? titleFilter,
            string? genreFilter,
            string? distributorFilter,
            string? countryFilter,
            int? durationFrom,
            int? durationTo,
            int? yearFromFilter,
            int? yearToFilter,
            string? sortOrder)
        {
            var movies = await _movieRepository.GetAllAsync(titleFilter, genreFilter, distributorFilter, countryFilter, durationFrom, durationTo, yearFromFilter, yearToFilter, sortOrder);
            return Ok(movies.ToList());
            
        }

        [HttpGet]
        [Route("api/movies/{id}")]
        public async Task<IActionResult> GetMovie(int id)
        {
            var movie = await _movieRepository.GetByIdAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("api/movies")]
        public async Task<IActionResult> PostMovie(Movie movie)
        {
            if (!ModelState.IsValid)
            {

                var errors = ModelState.Values.SelectMany(v => v.Errors)
                                      .Select(e => e.ErrorMessage)
                                      .ToList();
                return BadRequest(new { Message = "Invalid model state.", Errors = errors });
            }

            await _movieRepository.AddAsync(movie);
            return CreatedAtAction("GetMovie", new { id = movie.Id }, movie);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        [Route("api/movies/{id}")]
        public async Task<IActionResult> PutMovie(int id, Movie movie)
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
                await _movieRepository.UpdateAsync(movie);   
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
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var movie = await _movieRepository.GetByIdAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            if ( await _movieRepository.HasProjectionsAsync(id))
            {
                await _movieRepository.LogicalDeleteAsync(movie);
            }
            else { 

                await _movieRepository.DeleteAsync(movie);
            }
            return NoContent();
        }
    }
}
