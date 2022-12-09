using FinalProject.Core.Models.Ticket;
using FinalProject.Infrastructure.Data;
using FinalProject.Models;

namespace FinalProject.Core.Contracts
{
    public interface ITicketService
    {
        Task ReserveTicketAsync(TicketModel model, string userId, Guid eventId);

        Task AddTicketToUserAsync(string userId, Ticket newTicket);

        Task<IEnumerable<TicketViewModel>> GetUserTicketsAsync(string userId);
    }
}
