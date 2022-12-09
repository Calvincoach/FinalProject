using FinalProject.Core.Contracts;
using FinalProject.Core.Models.Ticket;
using FinalProject.Infrastructure.Data;
using FinalProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace FinalProject.Core.Services
{
    public class TicketService:ITicketService
    {
        private readonly ApplicationDbContext _context;

        public TicketService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task ReserveTicketAsync(TicketModel model, string userId, Guid eventId)
        {
            var existingTicket = await _context.Tickets.FirstOrDefaultAsync(t => t.TicketHolder == model.TicketHolder && t.EventId == eventId);
            var existingEvent = await _context.Events.FirstOrDefaultAsync(e => e.Id == eventId);

            if (existingEvent is null)
            {
                throw new Exception("Event doesn't exist");
            }
            if (existingTicket is not null)
            {
                throw new Exception($"A ticket with ticket holder: {model.TicketHolder} already exists");
            }

            var newTicket = new Ticket()
            {
                Id = model.Id,
                EventName = model.EventName,
                Date = model.Date,
                TicketHolder = model.TicketHolder,
                TicketReference = model.TicketReference,
                ImageUrl = model.ImageUrl,
                Price = model.Price,
                EventId = eventId,
            };

            await _context.Tickets.AddAsync(newTicket);
            await AddTicketToUserAsync(userId, newTicket);
            await _context.SaveChangesAsync();
        }

        public async Task AddTicketToUserAsync(string userId, Ticket newTicket)
        {
            
            var user = await _context.Users
                .Where(u => u.Id == userId)
                .Include(u => u.UserTickets)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid user ID");
            }

            user.UserTickets.Add(new UserTicket()
            {
                TicketId = newTicket.Id,
                UserId = user.Id,
                Ticket = newTicket,
                User = user
            });

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TicketViewModel>> GetUserTicketsAsync(string userId)
        {
            var user = await _context.Users
               .Where(u => u.Id == userId)
               .Include(u => u.UserTickets)
               .ThenInclude(ut => ut.Ticket)
               .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid user ID");
            }

            var testTicket = await _context.Tickets.FirstOrDefaultAsync(x => x.Id == Guid.Parse("2DD5B346-8858-4885-8845-E26A5CA7CC25"));

            var result = user.UserTickets
                .Select(t => new TicketViewModel()
                {
                    Id = t.TicketId,
                    EventName = t.Ticket.EventName,
                    ImageUrl = t.Ticket.ImageUrl,
                    Date = t.Ticket.Date,
                    TicketHolder = t.Ticket.TicketHolder,
                    TicketReference = t.Ticket.TicketReference,
                    EventId = t.Ticket.EventId,
                });

            return result;
        }
    }
}
