using FinalProject.Core.Models.Ticket;
using FinalProject.Infrastructure.Data;
using FinalProject.Models;

namespace FinalProject.Core.Contracts
{
    public interface ITicketService
    {
        Task ReserveTicket(TicketModel model, string userId, Guid eventId);

        Task AddTicketToCollection(string userId, Ticket newTicket);

        Task<IEnumerable<TicketViewModel>> GetUserTickets(string userId);
    }
}
