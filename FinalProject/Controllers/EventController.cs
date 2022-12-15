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

        //[Authorize(Roles = "admin")]
        //[HttpGet]
        //public async Task<IActionResult> Add()
        //{
        //    var model = new EventModel()
        //    {
        //        Categories = await _eventService.GetCategoriesAsync(),
        //        Venues = await _eventService.GetVenuesAsync()
        //    };

        //    return View(model);
        //}

        //[Authorize(Roles = "admin")]
        //[HttpPost]
        //public async Task<IActionResult> Add(EventModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(model);
        //    }

        //    try
        //    {
        //        await _eventService.AddEventAsync(model);
        //        ModelState.Clear();
        //        return RedirectToAction(nameof(All), "Event");
        //    }
        //    catch (Exception e)
        //    {
        //        ModelState.AddModelError("Date", e.Message);
        //        model.Categories = await _eventService.GetCategoriesAsync();
        //        model.Venues = await _eventService.GetVenuesAsync();
        //        return View(model);
        //    }
        //}

        //[Authorize(Roles = "admin")]
        //[HttpGet]
        //public async Task<IActionResult> Edit(Guid eventId)
        //{
        //    if (await _eventService.FindEventAsync(eventId) == false)
        //    {
        //        ModelState.AddModelError("", "Event doesn't exist");
        //        return RedirectToAction(nameof(All));
        //    }

        //    var existingEvent = await _eventService.GetEventAsync(eventId);

        //    var model = new EventModel()
        //    {
        //        Id = existingEvent.Id,
        //        Name = existingEvent.Name,
        //        EventOrganiser = existingEvent.EventOrganiser,
        //        ImageUrl = existingEvent.ImageUrl,
        //        Price = existingEvent.Price,
        //        Date = existingEvent.Date,
        //        Description = existingEvent.Description,
        //        Interested = existingEvent.Interested,
        //        CategoryId = existingEvent.CategoryId,
        //        VenueId = existingEvent.VenueId,
        //        Categories = await _eventService.GetCategoriesAsync(),
        //        Venues = await _eventService.GetVenuesAsync()

        //    };

        //    return View(model);
        //}

        //[Authorize(Roles = "admin")]
        //[HttpPost]
        //public async Task<IActionResult> Edit(Guid eventId, EventModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(model);
        //    }
        //    await _eventService.EditAsync(model.Id, model);

        //    return RedirectToAction(nameof(Details), new { eventId });
        //}

        //[Authorize(Roles = "admin")]
        //[HttpPost]
        //public async Task<IActionResult> Delete(Guid eventId)
        //{
        //    try
        //    {
        //        await _eventService.DeleteEventAsync(eventId);
        //    }
        //    catch (Exception e)
        //    {
        //        ModelState.AddModelError("", e.Message);
        //        return RedirectToAction(nameof(All));
        //    }

        //    return RedirectToAction(nameof(All));
        //}

        [Authorize(Roles = "guest")]
        [HttpPost]
        public async Task <IActionResult> Interested(Guid eventId)
        {
            try
            {
                var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
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
            string userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            await _eventService.RemoveInterestedEventsAsync(eventId, userId);

            return RedirectToAction(nameof(MyEvents));
        }

        [Authorize(Roles = "guest")]
        [HttpGet]
        public async Task<IActionResult> MyEvents()
        {
            string userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var model = await _eventService.GetInterestedEventsAsync(userId);

            return View("MyEvents", model);
        }

    }
}
