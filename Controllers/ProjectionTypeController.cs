using CinemaApp.Interfaces;
using CinemaApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CinemaApp.Controllers
{
   
    [ApiController]
    public class ProjectionTypeController : ControllerBase
    {
        private readonly IProjectionTypeRepository _projectionTypeRepository;

        public ProjectionTypeController(IProjectionTypeRepository projectionTypeRepository)
        {
            _projectionTypeRepository = projectionTypeRepository;
        }


        [HttpGet]
        [Route("api/projectiontypes")]
        public IActionResult GetProjectionTypes()
        {
            var projectionTypes = _projectionTypeRepository.GetAll()
                .Select(pt => new
                {
                    pt.Id,
                    Type = pt.Type.GetDisplayName()
                });

            return Ok(projectionTypes);
        }
    }
}
