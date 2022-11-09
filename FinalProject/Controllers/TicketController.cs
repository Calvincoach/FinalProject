using FinalProject.Core.Models.Event;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    [Authorize]
    public class TicketController : Controller
    {
        public async Task<IActionResult> MyTicket()
        {
            var model = new TicketsModel();

            return View(model);
        }

        [HttpGet]
        public IActionResult Buy() => View();

        [HttpPost]
        public async Task<IActionResult> Buy(TicketModel model)
        { 
            return RedirectToAction(nameof(MyTicket));
        }
    }
}
