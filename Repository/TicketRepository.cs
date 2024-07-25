using CinemaApp.Interfaces;
using CinemaApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CinemaApp.Repository
{
    public class TicketRepository: ITicketRepository
    {
        private readonly AppDbContext _context;

        public TicketRepository(AppDbContext context)
        {
            _context = context;
        }

        public (bool success, string error) BuyTicket(Ticket ticket)
        {
            var seat = _context.Seats.Find(ticket.SeatId);

            if (seat == null || !seat.IsAvailable)
            {
                return (false, "Seat is not available");
            }

            seat.IsAvailable = false;
            _context.Seats.Update(seat);

            _context.Tickets.Add(ticket);
            _context.SaveChanges();

            return (true, null);
        }

        public Ticket GetById(int id)
        {
            return _context.Tickets.Include(p => p.Projection).Include(p => p.Seat).Include(p => p.User).FirstOrDefault(p => p.Id == id);
        }

        public IQueryable<Ticket> GetTicketsByUserId(string userId)
        {
            return _context.Tickets
                .Include(t => t.Projection)
                .ThenInclude(p => p.Movie)
                .Include(t => t.Projection)
                .ThenInclude(p => p.ProjectionType)
                .Include(t => t.Projection)
                .ThenInclude(p => p.Theater)
                .Include(t => t.Seat)
                .Include(t => t.User)
                .Where(t => t.UserId == userId)
                .AsQueryable();
        }

        public void DeleteTicketsByUserId(string userId)
        {
            var tickets = _context.Tickets.Where(t => t.UserId == userId).ToList();
            _context.Tickets.RemoveRange(tickets);
            _context.SaveChanges();
        }
    }
}
