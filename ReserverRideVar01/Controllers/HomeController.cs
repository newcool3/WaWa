using JWT.Services;
using Microsoft.AspNetCore.Authorization;
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
        MSITDbContext _db;

        public HomeController(ILogger<HomeController> logger, MSITDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(CLoginViewModel model)
        {
            Member mem = _db.Members.FirstOrDefault(
               c => c.MemberEmail.Equals(model.txtAccount) && c.MemberPassword.Equals(model.txtPassword));

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
            
            //if (!HttpContext.Session.Keys.Contains(Dictionary.SK_LOGIN_USER))
            //    return RedirectToAction("Login");
            //string json = HttpContext.Session.GetString(Dictionary.SK_LOGIN_USER);
            //Member user = JsonSerializer.Deserialize<Member>(json);
            //ViewBag.USERNAME = user.MemberName;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult<dynamic> Authenticate([FromBody] CLoginViewModel model)
        {
            //var user = UserRepository.Get(model.Username, model.Password);
            var user = _db.Members.FirstOrDefault(c => c.MemberEmail.Equals(model.txtAccount) && c.MemberPassword.Equals(model.txtPassword));

            if (user == null)
                return NotFound(new { message = "User or password invalid" });

            var token = TokenService.CreateToken(user);
            user.MemberPassword = "";
            return new
            {
                user = user,
                token = token
            };

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
