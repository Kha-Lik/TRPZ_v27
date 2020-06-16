using BLL.Models;

namespace BLL
{
    public interface ITicketService
    {
        public Ticket TakeTicket(Ticket ticket);
    }
}