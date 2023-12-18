using Booking_Hotel.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using Booking_Hotel.Models;

namespace Booking_Hotel.Controllers
{
    public class AccountController : Controller
    {
        private readonly Booking_HotelContext _context;

        public AccountController(Booking_HotelContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
     
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User userFormPage)
        {
            var user = _context.User.FirstOrDefault(m => m.UserEmail == userFormPage.UserEmail && m.UserPassword == userFormPage.UserPassword);
            if (user != null)
            {
                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.UserEmail),
            new Claim("FullName", user.UserName),
            new Claim(ClaimTypes.Role,user.UserRole),
        };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties { };


                HttpContext.SignInAsync(
                     CookieAuthenticationDefaults.AuthenticationScheme,
                     new ClaimsPrincipal(claimsIdentity),
                     authProperties);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.LoginStatus = 0;

            }

            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(
       CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login", "Account");
        }

    }
}


