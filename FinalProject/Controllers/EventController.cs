using FinalProject.Contracts;
using FinalProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FinalProject.Controllers
{
    [Authorize]
    public class EventController : Controller
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            var model = await _eventService.GetAllEventsAsync();

            return View(model);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(Guid eventId)
        {
            if (await _eventService.FindEventAsync(eventId) == false)
            {
                return RedirectToAction(nameof(All));
            }
            var currentEvent = await _eventService.GetEventAsync(eventId);
            var model = await _eventService.EventDetailsAsync(currentEvent);

            return View(model);
        }

        [Authorize(Roles = "guest")]
        [HttpPost]
        public async Task <IActionResult> Interested(Guid eventId)
        {
            try
            {
                var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
                await _eventService.AddEventToCollectionAsync(eventId, userId);
            }
            catch (Exception)
            {
                throw;
            }

            return RedirectToAction(nameof(All));
        }

        [Authorize(Roles = "guest")]
        [HttpPost]
        public async Task<IActionResult> NotInterested(Guid eventId)
        {
            string userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
            await _eventService.RemoveInterestedEventsAsync(eventId, userId);

            return RedirectToAction(nameof(MyEvents));
        }

        [Authorize(Roles = "guest")]
        [HttpGet]
        public async Task<IActionResult> MyEvents()
        {
            string userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
            var model = await _eventService.GetInterestedEventsAsync(userId);

            return View("MyEvents", model);
        }

    }
}
