using CinemaApp.Models;

namespace CinemaApp.Interfaces
{
    public interface ITicketRepository
    {
        public (bool success, string error) BuyTicket(Ticket ticket);
        Ticket GetById(int id);
        IQueryable<Ticket> GetTicketsByUserId(string userId);
    }
}
