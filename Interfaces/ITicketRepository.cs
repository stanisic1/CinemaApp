using CinemaApp.Models;

namespace CinemaApp.Interfaces
{
    public interface ITicketRepository
    {
        Task<(bool success, string? error)> BuyTicketAsync(Ticket ticket);
        Task<Ticket?> GetByIdAsync(int id);
        Task<IEnumerable<Ticket>> GetTicketsByUserIdAsync(string userId);
        Task DeleteTicketsByUserIdAsync(string userId);
    }
}
