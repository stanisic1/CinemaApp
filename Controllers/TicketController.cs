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
        public IActionResult BuyTicket([FromBody] TicketDTO request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Retrieve the current user
            var userId = _userManager.GetUserId(User);
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }

            // Set the authenticated user's ID in the ticket
            var ticket = new Ticket
            {
                ProjectionId = request.ProjectionId,
                SeatId = request.SeatId,
                UserId = userId,
                SaleDateTime = DateTime.Now
            };

            var (success, error) = _ticketRepository.BuyTicket(ticket);

            if (!success)
            {
                return BadRequest(error);
            }

            return Ok(ticket);
        }

        [HttpGet]
        [Route("api/tickets/{id}")]
        public IActionResult GetTicket(int id)
        {
            var ticket = _ticketRepository.GetById(id);
            if (ticket == null)
            {
                return NotFound();
            }

            return Ok(ticket);
        }

        [Authorize(Roles = "User")]
        [HttpGet("api/tickets/mytickets")]
        public  IActionResult GetMyTickets()
        {
            // Get the user's ID from the claims in the token
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                return Unauthorized();
            }

            var tickets = _ticketRepository.GetTicketsByUserId(userId);

            var ticketsDto = _mapper.Map<IEnumerable<UserTicketsDTO>>(tickets);

            return Ok(new { values = ticketsDto });
        }

    }
}
