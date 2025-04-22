using ASPNETCOREMVCCustomizedAattribute.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using static ASPNETCOREMVCCustomizedAattribute.ParaAccessAttributeEnum;

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
                Expires = DateTimeOffset.UtcNow.AddMinutes(1)
            });

            return RedirectToAction("ProtectedPage2");
        }

        [ParaAccess(UserRole.Admin)]
        public IActionResult ParaPage()
        {
            return View();
        }
    }
}
