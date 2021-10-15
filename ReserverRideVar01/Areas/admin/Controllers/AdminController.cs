using JWT.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReserverRideVar01.DbContext;
using ReserverRideVar01.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ReserverRideVar01.Areas.admin.Controllers
{
    [Area("admin")]
    public class AdminController : Controller
    {
        MSITDbContext _db;

        public AdminController( MSITDbContext db)
        {
            _db = db;
        }
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Login(CLoginViewModel model)
        {
            //var user = UserRepository.Get(model.Username, model.Password);
            var user = _db.Members.FirstOrDefault(c => c.MemberEmail.Equals(model.txtAccount) && c.MemberPassword.Equals(model.txtPassword));

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid password");
                return View();
            }
                

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.MemberEmail),
                new Claim(ClaimTypes.Name, user.MemberName),
                new Claim(ClaimTypes.NameIdentifier, user.MemberID.ToString()),
                new Claim(ClaimTypes.Role, user.Role)
            };

            // Identity object
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            // Create the cookie
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

            // Redirect to home page
            return RedirectToAction("index", "admin", new { area = "admin" });
        }

        [HttpGet]
        [Authorize(Roles = "manager")]
        public string Manager() => "Manager";


        [AllowAnonymous]
        public ActionResult Deined()
        {
            return View();
        }
    }
}
