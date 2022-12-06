using FinalProject.Contracts;
using FinalProject.Core.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class VenueController : Controller
    {
        private readonly IVenueService _venueService;

        public VenueController(IVenueService venueService)
        {
            _venueService = venueService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> AllVenues()
        {
            var model = await _venueService.GetAllVenues();

            return View(model);
        }
    }
}
