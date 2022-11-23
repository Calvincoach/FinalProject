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

        //public async Task<IActionResult> MyEvent()
        //{
        //    var model = new EventsModel();

        //    return View(model);
        //}

        [AllowAnonymous]
        public async Task<IActionResult> Details(Guid eventId)
        {
            var currentEvent = _eventService.FindEvent(eventId).Result;
            if (currentEvent is null)
            {
                return RedirectToAction(nameof(All));
            }

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

        //[HttpGet]
        //public async Task<IActionResult> Edit(Guid eventId)
        //{
        //    //var currentEvent = _eventService.FindEvent(eventId).Result;
        //    //if (currentEvent is null)
        //    //{
        //    //    return RedirectToAction(nameof(All));
        //    //}
        //    //var eventCategory = _eventService.GetCategoriesAsync().Result.FirstOrDefault(c => c.Id == currentEvent.CategoryId).Name;
        //    //var eventVenue = _eventService.GetVenuesAsync().Result.FirstOrDefault(v => v.Id == currentEvent.VenueId).Name;
        //    //var model = new EventModel()
        //    //{
        //    //    Id = currentEvent.Id,
        //    //    Name = currentEvent.Name,
        //    //    EventOrganiser = currentEvent.EventOrganiser,
        //    //    ImageUrl = currentEvent.ImageUrl,
        //    //    Price = currentEvent.Price,
        //    //    Date = currentEvent.Date,
        //    //    Description = currentEvent.Description,
        //    //    Likes = currentEvent.Likes,
        //    //    Interested = currentEvent.Interested,
        //    //    Category = eventCategory,
        //    //    Venue = eventVenue,

        //    //};

        //    //return View(model);
        //}

        [HttpPost]
        public async Task<IActionResult> Edit(Guid eventId, EventModel model)
        {
            //if (id != model.Id)
            //{
            //    return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            //}
            var existingEvent = _eventService.FindEvent(model.Id).Result;
            if (existingEvent is null)
            {
                ModelState.AddModelError("", "Event doesn't exist");
                return View(model);
            }
            if (!ModelState.IsValid)
            {
                model.Categories = await _eventService.GetCategoriesAsync();
                model.Venues = await _eventService.GetVenuesAsync();
                return View(model);
            }
            await _eventService.Edit(model.Id, model);

            return RedirectToAction(nameof(Details));
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
