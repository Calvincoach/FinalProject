using FinalProject.Contracts;
using FinalProject.Core.Models.Event;
using FinalProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net.WebSockets;

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
            var model = await _eventService.EventDetails(currentEvent);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new EventModel()
            {
                Categories = await _eventService.GetCategoriesAsync(),
                Venues = await _eventService.GetVenuesAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(EventModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await _eventService.AddEventAsync(model);
                ModelState.Clear();
                return RedirectToAction(nameof(All), "Event");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("Date", e.Message);
                model.Categories = await _eventService.GetCategoriesAsync();
                model.Venues = await _eventService.GetVenuesAsync();
                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid eventId)
        {
            if (await _eventService.FindEventAsync(eventId) == false)
            {
                return RedirectToAction(nameof(All));
            }

            var existingEvent = await _eventService.GetEventAsync(eventId);

            var model = new EventModel()
            {
                Id = existingEvent.Id,
                Name = existingEvent.Name,
                EventOrganiser = existingEvent.EventOrganiser,
                ImageUrl = existingEvent.ImageUrl,
                Price = existingEvent.Price,
                Date = existingEvent.Date,
                Description = existingEvent.Description,
                Likes = existingEvent.Likes,
                Interested = existingEvent.Interested,
                CategoryId = existingEvent.CategoryId,
                VenueId = existingEvent.VenueId,
                Categories = await _eventService.GetCategoriesAsync(),
                Venues = await _eventService.GetVenuesAsync()

            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid eventId, EventModel model)
        {
            //if (id != model.Id)
            //{
            //    return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            //}
            if (await _eventService.FindEventAsync(model.Id) == false)
            {
                ModelState.AddModelError("", "Event doesn't exist");
                return View(model);
            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await _eventService.Edit(model.Id, model);

            return RedirectToAction(nameof(Details), new { eventId });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid eventId)
        {
            try
            {
                await _eventService.DeleteEventAsync(eventId);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return RedirectToAction(nameof(All));
            }

            return RedirectToAction(nameof(All));
        }
    }
}
