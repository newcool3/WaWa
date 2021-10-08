using Microsoft.AspNetCore.Mvc;
using ReserverRideVar01.DbContext;
using ReserverRideVar01.Models;
using ReserverRideVar01.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReserverRideVar01.Areas.admin.Controllers
{
    [Area("admin")]
    public class IslandController : Controller
    {
        MSITDbContext _db;
        public IslandController(MSITDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }
        public ActionResult create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult create(IslandViewModel i)
        {
            Island island = new Island();
            if (i.IslandPhoto != null)
            {
                using var fileStream = i.IslandPhoto.OpenReadStream();  //iformfile
                island.IslandPhoto = new byte[(int)i.IslandPhoto.Length];
                fileStream.Read(island.IslandPhoto, 0, (int)i.IslandPhoto.Length);
            }
            island.IslandName = i.IslandName;

            _db.Island.Add(island);
            _db.SaveChanges();

            return RedirectToAction("List", "product");
        }
    }
}
