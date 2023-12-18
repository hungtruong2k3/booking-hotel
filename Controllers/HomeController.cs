using Booking_Hotel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Booking_Hotel.Data;
using Booking_Hotel.Models;
namespace Booking_Hotel.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly Booking_HotelContext _context;
        public int PageSize = 3;
        public HomeController(Booking_HotelContext context)
        {
            _context = context;
        }

    

        public IActionResult Index()
        {
            var _product = _context.Product.ToList();
            return View(_product);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult IndexProduct()
        {
            var _product = _context.Product.Include(p => p.levelHotel);
            return View(_product.ToList());

			
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}