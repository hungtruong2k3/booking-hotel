using Microsoft.AspNetCore.Mvc;

namespace Booking_Hotel.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
