using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using cms_admin.Models;
using Microsoft.AspNetCore.Http;

namespace cms_admin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.Message = this.HttpContext.Session.GetString("Administrador");
            return View();
        }
        
        public IActionResult Privacy()
        {
            this.HttpContext.Response.Cookies.Append("Administrador", "Seja bem-vindo!", new CookieOptions()
            {
                Expires = DateTimeOffset.UtcNow.AddSeconds(3),
                HttpOnly = true
            });
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
