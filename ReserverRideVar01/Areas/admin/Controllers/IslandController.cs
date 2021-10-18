using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReserverRideVar01.DbContext;
using ReserverRideVar01.Models;
using ReserverRideVar01.ViewModel;
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
        private List<Island> GetIsland()
        {
            List<Island> island = new List<Island>();
            var islands = _db.Island;
            foreach (var item in islands)
            {
                island.Add(new Island()
                {
                    IslandId = item.IslandId,
                    IslandName = item.IslandName,
                    IslandPhoto = item.IslandPhoto
                });
            }
            return island;
        }

        public IActionResult Index()
        {
            ProductViewModel productView = new ProductViewModel();

            productView.Islands = GetIsland();
            return View(productView);
        }
        [Authorize(Roles = "manager")]
        [HttpGet, Area("admin"), ActionName("create")]
        public ActionResult create()
        {
            return View();
        }
        [Authorize(Roles = "manager")]
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

            return View();
        }
        [Authorize(Roles = "manager")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Island island = _db.Island.FirstOrDefault(i => i.IslandId == id);
            if (island == null)
            {
                return RedirectToAction("Index");
            }
            return View(island);

        }
        [Authorize(Roles = "manager")]
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

            return RedirectToAction("Index");
        }
        [Authorize(Roles = "manager")]
        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                Island island = _db.Island.FirstOrDefault(i => i.IslandId == id);
                if (island != null)
                {
                    _db.Island.Remove(island);
                    _db.SaveChanges();
                }
            }
            return RedirectToAction("index");
        }
    }
}
