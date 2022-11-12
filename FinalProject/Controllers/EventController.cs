using FinalProject.Contracts;
using FinalProject.Core.Models.Event;
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

        //[HttpGet]
        //public IActionResult Add() => View();

        //[HttpPost]
        //public async Task<IActionResult> Add(EventModel model)
        //{
        //    Guid id = Guid.NewGuid();

        //    return RedirectToAction(nameof(Details), new { id });
        //}

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
