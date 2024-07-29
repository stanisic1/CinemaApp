using AutoMapper;
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
    public class TicketController : ControllerBase
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public TicketController(ITicketRepository ticketRepository, UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _ticketRepository = ticketRepository;
            _userManager = userManager;
            _mapper = mapper;
        }

        [Authorize(Roles = "User")]
        [HttpPost]
        [Route("api/tickets/buy")]
        public async Task<IActionResult> BuyTicketAsync([FromBody] TicketDTO request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Unauthorized();
            }

            var ticket = new Ticket
            {
                ProjectionId = request.ProjectionId,
                SeatId = request.SeatId,
                UserId = user.Id,
                SaleDateTime = DateTime.Now
            };

            var (success, error) = await _ticketRepository.BuyTicketAsync(ticket);

            if (!success)
            {
                return BadRequest(error);
            }

            return Ok(ticket);
        }

        [HttpGet]
        [Route("api/tickets/{id}")]
        public async Task<IActionResult> GetTicketAsync(int id)
        {
            var ticket = await _ticketRepository.GetByIdAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }

            return Ok(ticket);
        }

        [Authorize(Roles = "User")]
        [HttpGet("api/tickets/mytickets")]
        public async Task<IActionResult> GetMyTicketsAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Unauthorized();
            }

            var tickets = await _ticketRepository.GetTicketsByUserIdAsync(user.Id);
            var ticketsDto = _mapper.Map<IEnumerable<UserTicketsDTO>>(tickets);

            return Ok(new { values = ticketsDto });
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("api/tickets/usertickets/{id}")]
        public async Task<IActionResult> GetUserTicketsAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("User ID cannot be null or empty");
            }

            var tickets = await _ticketRepository.GetTicketsByUserIdAsync(id);
            if (tickets == null || !tickets.Any())
            {
                return Ok(new { values = new List<UserTicketsDTO>() });
            }

            var ticketsDto = _mapper.Map<IEnumerable<UserTicketsDTO>>(tickets);
            return Ok(new { values = ticketsDto });
        }

    }
}
