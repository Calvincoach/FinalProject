using FinalProject.Contracts;
using FinalProject.Core.Models.Event;
using FinalProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

        //[AllowAnonymous]
        //public async Task<IActionResult> Details(Guid id)
        //{
        //    var model = new EventDetailsModel();

        //    return View(model);
        //}

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new AddEventViewModel()
            {
                Categories = await _eventService.GetCategoriesAsync(),
                Venues = await _eventService.GetVenuesAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddEventViewModel model)
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
        //public async Task<IActionResult> Edit(Guid id)
        //{
        //    var model = new EventModel();

        //    return View(model);
        //}

        //[HttpPost]
        //public async Task<IActionResult> Edit(Guid id, EventModel model)
        //{
        //    return RedirectToAction(nameof(Details), new { id });
        //}

        //[HttpPost]
        //public async Task<IActionResult> Delete(Guid id)
        //{
        //    return RedirectToAction(nameof(All));
        //}
    }
}
