using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Principal;
using URLShort.Models;

namespace URLShort.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            System.Diagnostics.Debug.WriteLine("A developer message for the console.");
            // Works in ASP.NET Core
            return View("~/Views/Account/Login.cshtml");
        }
    }
}
