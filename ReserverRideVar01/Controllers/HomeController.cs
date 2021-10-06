using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReserverRideVar01.DbContext;
using ReserverRideVar01.Models;
using ReserverRideVar01.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ReserverRideVar01.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(CLoginViewModel model)
        {
            MSITDbcontext db = new MSITDbcontext();
            Member mem = db.Members.FirstOrDefault(
               c => c.MemberName.Equals(model.txtAccount) && c.MemberPassword.Equals(model.txtPassword));

            if (mem != null && mem.MemberPassword.Equals(model.txtPassword))
            {
                string json = JsonSerializer.Serialize(mem);
                HttpContext.Session.SetString(Dictionary.SK_LOGIN_USER, json);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Index()
        {
            if (!HttpContext.Session.Keys.Contains(Dictionary.SK_LOGIN_USER))
                return RedirectToAction("Login");
            string json = HttpContext.Session.GetString(Dictionary.SK_LOGIN_USER);
            Member user = JsonSerializer.Deserialize<Member>(json);
            ViewBag.USERNAME = user.MemberName;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
