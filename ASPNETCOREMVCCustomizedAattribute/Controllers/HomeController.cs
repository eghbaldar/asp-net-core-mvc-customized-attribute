using ASPNETCOREMVCCustomizedAattribute.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASPNETCOREMVCCustomizedAattribute.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [CustomAccess]
        public IActionResult ProtectedPage1()
        {
            return View();
        }
        [HttpGet]
        [CookieAccess]
        public IActionResult ProtectedPage2()
        {
            return View();
        }
        public IActionResult SetAccessCookie()
        {
            Response.Cookies.Append("HasAccess", "true", new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                Expires = DateTimeOffset.UtcNow.AddHours(1)
            });

            return RedirectToAction("ProtectedPage2");
        }

    }
}
