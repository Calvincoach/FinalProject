using FinalProject.Contracts;
using FinalProject.Core.Contracts;
using FinalProject.Core.Models.Ticket;
using FinalProject.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FinalProject.Controllers
{
    [Authorize]
    public class TicketController : Controller
    {
        private readonly ITicketService _ticketService;
        private readonly IEventService _eventService;

        public TicketController(ITicketService ticketService, IEventService eventService)
        {
            _ticketService = ticketService;
            _eventService = eventService;
        }

        [Authorize(Roles = "guest")]
        [HttpGet]
        public async Task<IActionResult> ReserveTicket(Guid eventId)
        {
            if (await _eventService.FindEventAsync(eventId) == false)
            {
                ModelState.AddModelError("", "Event doesn't exist");
                return RedirectToAction(nameof(EventController.All));
            }

            var currentEvent = await _eventService.GetEventAsync(eventId);

            Random rndm = new Random();
            var ticketReferenceNumber = rndm.Next();

            var model = new TicketModel()
            {
                Id = Guid.NewGuid(),
                EventName = currentEvent.Name,
                TicketHolder = "",
                TicketReference = $"{currentEvent.Date.ToString("MMddyyyy.HHmm")}_{ticketReferenceNumber}",
                ImageUrl = currentEvent.ImageUrl,
                Date = currentEvent.Date,
                Price = currentEvent.Price
            };

            return View(model);
        }

        [Authorize(Roles = "guest")]
        [HttpPost]
        public async Task<IActionResult> ReserveTicket(Guid eventId, TicketModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                await _ticketService.ReserveTicket(model, userId, eventId);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("TicketHolder", e.Message);
                return View(model);
            }

            return RedirectToAction("All", "Event");
        }

        [Authorize(Roles = "guest")]
        [HttpGet]
        public async Task<IActionResult> MyTickets()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var model = await _ticketService.GetUserTickets(userId);

            return View("MyTickets", model);
        }
    }
}
