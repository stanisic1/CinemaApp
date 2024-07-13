using CinemaApp.Interfaces;
using CinemaApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CinemaApp.Controllers
{
    [ApiController]
    public class TheaterController : ControllerBase
    {
        private readonly ITheaterRepository _theaterRepository;

        public TheaterController(ITheaterRepository theaterRepository)
        {
            _theaterRepository = theaterRepository;
        }


        [HttpGet]
        [Route("api/theaters")]
        public IActionResult GetProjectionTypes()
        {
            var theaters = _theaterRepository.GetAll()
                .Select(t => new
                {
                    t.Id,
                    t.Capacity,
                    Type = t.Type.GetDisplayName()
                });

            return Ok(theaters);
        }
    }
}
