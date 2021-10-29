using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReserverRideVar01.DbContext;
using ReserverRideVar01.Models;
using ReserverRideVar01.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ReserverRideVar01.Areas.admin.Controllers
{
    [Area("Admin")]
    [Route("admin/[controller]/[action]")]
    public class ActivityController : Controller
    {
        MSITDbContext _db ;
        public ActivityController(MSITDbContext db)
        {
            _db = db;
        }

        public IActionResult List(string txtKeyword)
        {
            var act = _db.Activities.Include(i => i.Island).ToList();

            IEnumerable<Activity> activity = null;

            if (string.IsNullOrEmpty(txtKeyword))
            {
                activity = _db.Activities.OrderByDescending(p => p.ActivityId).ToList();
            }
            else
            {
                activity = _db.Activities.Where(s => s.ActivityName.Contains(txtKeyword)).ToList();
            }

            return View(activity);

        }

        public IActionResult Create()
        {
            //ViewBag.minDate = DateTime.Today;

            return View();
        }

       
        [HttpGet]

        public IActionResult islandRead()
        {
            var island = _db.Island.Select((i) => new { i.IslandId, i.IslandName });

            return Ok(island);
        }

        [HttpPost]
        public IActionResult Create(ActivityViewModel actvm)
        {
            try
            {
                Activity act = new Activity();
                if (actvm.ActivityPhoto != null)
                {
                    using var fileStream = actvm.ActivityPhoto.OpenReadStream();
                    act.ActivityPhoto = new byte[(int)actvm.ActivityPhoto.Length];
                    fileStream.Read(act.ActivityPhoto, 0, (int)actvm.ActivityPhoto.Length);
                }

                act.ActivityName = actvm.ActivityName;
                act.ActivityType = actvm.ActivityType;
                act.ActivityStartDate = actvm.ActivityStartDate;
                act.ActivityEndDate = actvm.ActivityEndDate;
                act.ActivityTimezone = actvm.ActivityTimezone;
                act.ActivityPrice = actvm.ActivityPrice;
                act.ActivityLocation = actvm.ActivityLocation;
                act.ActivityState = actvm.ActivityState;
                act.ActivityNumberLimit = actvm.ActivityNumberLimit;
                act.ActivityDeadline = actvm.ActivityDeadline;
                act.ActivityDescription = actvm.ActivityDescription;
                act.IslandId = actvm.IslandId;

                _db.Activities.Add(act);
                _db.SaveChanges();
                
                return RedirectToAction("List");
                
            }
            catch (Exception ex)
            { 
                return RedirectToAction("Create");
            }
           
          

        }

        
        public IActionResult Edit(int? id)
        {
          
            if (id == null)
                return RedirectToAction("List");
            Activity act = _db.Activities.Include(i => i.Island).FirstOrDefault(p => p.ActivityId == id);
            if (act == null)
                return RedirectToAction("List");
            return View(act);
        }

   
        [HttpPost]
        public IActionResult Edit(ActivityViewModel actvm)
        {
            Activity act = _db.Activities.FirstOrDefault(p => p.ActivityId == actvm.ActivityId);

            if (act != null)
            {
                if (actvm.ActivityPhoto != null)
                {
                    using var fileStream = actvm.ActivityPhoto.OpenReadStream();
                    act.ActivityPhoto = new byte[(int)actvm.ActivityPhoto.Length];
                    fileStream.Read(act.ActivityPhoto, 0, (int)actvm.ActivityPhoto.Length);

                }
                act.ActivityName = actvm.ActivityName;
                act.ActivityType = actvm.ActivityType;
                act.ActivityStartDate = actvm.ActivityStartDate;
                act.ActivityEndDate = actvm.ActivityEndDate;
                act.ActivityTimezone = actvm.ActivityTimezone;
                act.ActivityPrice = actvm.ActivityPrice;
                act.ActivityLocation = actvm.ActivityLocation;
                act.ActivityState = actvm.ActivityState;
                act.ActivityNumberLimit = actvm.ActivityNumberLimit;
                act.ActivityDeadline = actvm.ActivityDeadline;
                act.ActivityDescription = actvm.ActivityDescription;
                act.IslandId = actvm.IslandId;

                _db.Activities.Update(act);
                _db.SaveChanges();
            }

            return RedirectToAction("List");
        }

      
        public IActionResult Delete(int? id)
        {

            if (id != null)
            {
                Activity act = _db.Activities.FirstOrDefault(p => p.ActivityId == id);
                if (act != null)
                {
                    _db.Activities.Remove(act);
                    _db.SaveChanges();
                }

            }
            return RedirectToAction("List");
        }
        public IActionResult ajaxSearch(string txtKeyword)
        {
            IEnumerable<Activity> activity = null;

            if (string.IsNullOrEmpty(txtKeyword))
            {
                activity = _db.Activities.OrderByDescending(p => p.ActivityId).ToList();
            }
            else
            {
                activity = _db.Activities.Where(s => s.ActivityName.Contains(txtKeyword)).ToList();
            }
            return Json(activity);
        }

    }
}

