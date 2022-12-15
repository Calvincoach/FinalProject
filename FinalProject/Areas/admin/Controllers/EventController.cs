using FinalProject.Contracts;
using FinalProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace FinalProject.Areas.admin.Controllers
{
    [Area("admin")]
    [Route("admin/[controller]/[Action]/{id?}")]
    [Authorize(Roles = "admin")]
    public class EventController : Controller
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
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
                return RedirectToAction("All", "Event", new { area = "" });
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
                ModelState.AddModelError("", "Event doesn't exist");
                return RedirectToAction("All", "Event", new { area = "" });
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
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await _eventService.EditAsync(model.Id, model);

            return RedirectToRoute(new { controller = "Event", action = "Details", area = "", id = eventId});
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
                return RedirectToAction("All", "Event", new { area = "" });
            }

            return RedirectToAction("All", "Event", new { area = "" });
        }
    }
}
