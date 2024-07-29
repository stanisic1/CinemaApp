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

        public async Task<(bool success, string? error)> BuyTicketAsync(Ticket ticket)
        {
            var seat = await _context.Seats.FindAsync(ticket.SeatId);
            if (seat == null || !seat.IsAvailable)
            {
                return (false, "Seat is not available");
            }
            
            seat.IsAvailable = false;

            await _context.Tickets.AddAsync(ticket);
            await _context.SaveChangesAsync();

            return (true, null);
        }

        public async Task<Ticket?> GetByIdAsync(int id)
        {
            return await _context.Tickets.Include(p => p.Projection).Include(p => p.Seat).Include(p => p.User).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Ticket>> GetTicketsByUserIdAsync(string userId)
        {
            return await _context.Tickets
                .Include(t => t.Projection)
                 .ThenInclude(p => p.Movie)
                 .Include(t => t.Projection)
                 .ThenInclude(p => p.ProjectionType)
                 .Include(t => t.Projection)
                 .ThenInclude(p => p.Theater)
                 .Include(t => t.Seat)
                 .Include(t => t.User)
                 .Where(t => t.UserId == userId)
                 .ToListAsync();
        }

        public async Task DeleteTicketsByUserIdAsync(string userId)
        {
            var tickets = await _context.Tickets.Where(t => t.UserId == userId).ToListAsync();
            _context.Tickets.RemoveRange(tickets);
            await _context.SaveChangesAsync();
        }
    }
}
