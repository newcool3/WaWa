using Microsoft.AspNetCore.Mvc;
using ReserverRideVar01.DbContext;
using ReserverRideVar01.Models;
using ReserverRideVar01.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReserverRideVar01.Controllers
{
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
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("List", "product");
            }

            Island island= _db.Island.FirstOrDefault(i => i.IslandId == id);
            if (island == null)
            {
                return RedirectToAction("List", "product");
            }
            return View(island);

        }
        [HttpPost]
        public ActionResult Edit(IslandViewModel i)
        {
            Island island = _db.Island.FirstOrDefault(t => t.IslandId == i.IslandId);
            if (i.IslandPhoto != null)
            {
                using var fileStream = i.IslandPhoto.OpenReadStream();  //iformfile
                island.IslandPhoto = new byte[(int)i.IslandPhoto.Length];
                fileStream.Read(island.IslandPhoto, 0, (int)i.IslandPhoto.Length);
            }
            island.IslandName = i.IslandName;
            _db.SaveChanges();

            return RedirectToAction("List", "product");
        }
    }
}
