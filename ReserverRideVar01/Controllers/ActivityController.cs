using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReserverRideVar01.DbContext;
using ReserverRideVar01.Models;
using ReserverRideVar01.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Http;

namespace ReserverRideVar01.Controllers
{
    public class ActivityController : Controller
    {
        MSITDbContext _db;
        public ActivityController(MSITDbContext db)
        {
            _db = db;
        }
        public IActionResult List(string txtKeyword)
        {
            IEnumerable<Activity> activity = null;

            if (string.IsNullOrEmpty(txtKeyword))
            {
                activity = _db.Activities.Where(p => p.ActivityState == "已通過").OrderByDescending(p => p.ActivityId).ToList();
            }
            else
            {
                activity = _db.Activities.Where(s => s.ActivityName.Contains(txtKeyword) && s.ActivityState == "已通過").ToList();
            }

            return View(activity);
        }

        public IActionResult Detail(int id)
        {
            var actor = _db.Activities.Include(i => i.Island).ToList();
            var Activity = _db.Activities
                .Where(p => p.ActivityId == id).FirstOrDefault();
            return View(Activity);
        }
        public IActionResult AddToCart(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("List");
            }
            Activity act = _db.Activities.FirstOrDefault(p => p.ActivityId == id);
            if (act == null)
            {
                return RedirectToAction("List");
            }
            return View(act);
        }

        [HttpPost]
        public IActionResult AddToCart(AAddToCartViewModel actvm)
        {
            Activity ac = _db.Activities.FirstOrDefault(p => p.ActivityId == actvm.txtFId);
            int totalprice = Convert.ToInt32(actvm.txtCount) * Convert.ToInt32(ac.ActivityPrice);
            if (ac != null)
            {
                ActivityOrder item = new ActivityOrder();
                item.OrderGuid = ac.ActivityId;
                item.OrderName = actvm.txtName;
                item.OrderPhone = actvm.txtPhone;
                item.OrderDate = actvm.txtDay;
                item.OrderTimezone = ac.ActivityTimezone;
                item.OrderTotalPrice = totalprice;
                item.OrderCheck = "否";
                item.OrderUpdatetime = DateTime.Now;
                item.OrderCustom = actvm.txtCount;
                item.ActivityId = ac.ActivityId;
                _db.ActivityOrders.Add(item);

                _db.SaveChanges();

            }
            return RedirectToAction("ViewCart", "Activity");
        }

        public IActionResult ViewCart()
        {
            var actor = _db.ActivityOrders.Include(i => i.Activity).ToList();
            IEnumerable<ActivityOrder> activityOrders = _db.ActivityOrders.OrderByDescending(p => p.ActivityId).ToList();
            if (activityOrders == null)
            {
                return RedirectToAction("List","Activity");
            }


            return View(actor.ToList());
        }

        public IActionResult EditCart(int? id)
        {
            if (id == null)
                return RedirectToAction("ViewCart", "Activity");
            ActivityOrder actor = _db.ActivityOrders.Include(a => a.Activity).FirstOrDefault(p => p.OrderId == id);
            if (actor == null)
                return RedirectToAction("ViewCart", "Activity");
            return View(actor);
        }
        [HttpPost]
        public IActionResult EditCart(AShoppingCartViewModel cartvm)
        {
            ActivityOrder actor = _db.ActivityOrders.FirstOrDefault(p => p.OrderId == cartvm.OrderId);
            if (cartvm != null)
            {
                actor.OrderName = cartvm.OrderName;
                actor.OrderPhone = cartvm.OrderPhone;
                actor.OrderCustom = cartvm.OrderCustom;
                actor.OrderTotalPrice = cartvm.OrderTotalPrice;
                _db.ActivityOrders.Update(actor);
                _db.SaveChanges();
            }
            return RedirectToAction("ViewCart", "Activity");

        }
        public IActionResult Delete(int? id)
        {

            if (id != null)
            {
                ActivityOrder act = _db.ActivityOrders.FirstOrDefault(p => p.OrderId == id);
                if (act != null)
                {
                    _db.ActivityOrders.Remove(act);
                    _db.SaveChanges();
                }

            }

            return RedirectToAction("ViewCart", "Activity");
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

        public IActionResult CalOrderNum(int? id)
        {

            int sum = 0;
            if (id != null)
            {
                var calsum = (from o in _db.ActivityOrders
                              where o.ActivityId == id
                              select o.OrderCustom).ToList();
                for (int i = 0; i < calsum.Count; i++)
                {
                    sum += calsum[i];
                }

            }
            return Json(sum);

        }

    }
}

