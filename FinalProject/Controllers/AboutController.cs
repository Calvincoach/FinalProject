using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult About()
        {
            return View();
        }
    }
}
